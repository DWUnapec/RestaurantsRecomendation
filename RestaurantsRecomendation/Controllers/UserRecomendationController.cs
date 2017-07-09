using Data;
using NReco.CF.Taste.Impl.Model.File;
using NReco.CF.Taste.Impl.Neighborhood;
using NReco.CF.Taste.Impl.Recommender;
using NReco.CF.Taste.Impl.Similarity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestaurantsRecomendation.Controllers
{
    public class UserRecomendationController : ApiController
    {
        // GET: api/UserRecomendation
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/UserRecomendation/5
        public IHttpActionResult Get(int id, int qty = 5)
        {

            var usersDir = System.Web.Hosting.HostingEnvironment.MapPath("~/DataCsv/userData.csv");
            var model = new FileDataModel(usersDir);
            var similarity = new LogLikelihoodSimilarity(model);
            var neighborhood = new NearestNUserNeighborhood(3, similarity, model);
            var recommender = new GenericUserBasedRecommender(model, neighborhood, similarity);
            var recommendedItems = recommender.Recommend(id, qty);
            using(var ctx = new RestaurantsContext())
            {
               var restaurantsId = recommendedItems.Select(x => x.GetItemID());
               var restaurants = ctx.Restaurants.Where(x => restaurantsId.Contains(x.Id)).ToList();
               return Ok(restaurants);

            }
        }

        // POST: api/UserRecomendation
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/UserRecomendation/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UserRecomendation/5
        public void Delete(int id)
        {
        }
    }
}
