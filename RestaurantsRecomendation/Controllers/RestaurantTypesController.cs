using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Data;
using Model;

namespace RestaurantsRecomendation.Controllers
{
    public class RestaurantTypesController : ApiController
    {
        private RestaurantsContext db = new RestaurantsContext();

        // GET: api/RestaurantTypes
        public IQueryable<RestaurantType> GetRestaurantTypes()
        {
            return db.RestaurantTypes;
        }

        // GET: api/RestaurantTypes/5
        [ResponseType(typeof(RestaurantType))]
        public async Task<IHttpActionResult> GetRestaurantType(int id)
        {
            RestaurantType restaurantType = await db.RestaurantTypes.FindAsync(id);
            if (restaurantType == null)
            {
                return NotFound();
            }

            return Ok(restaurantType);
        }

        // PUT: api/RestaurantTypes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRestaurantType(int id, RestaurantType restaurantType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != restaurantType.Id)
            {
                return BadRequest();
            }

            db.Entry(restaurantType).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/RestaurantTypes
        [ResponseType(typeof(RestaurantType))]
        public async Task<IHttpActionResult> PostRestaurantType(RestaurantType restaurantType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RestaurantTypes.Add(restaurantType);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = restaurantType.Id }, restaurantType);
        }

        // DELETE: api/RestaurantTypes/5
        [ResponseType(typeof(RestaurantType))]
        public async Task<IHttpActionResult> DeleteRestaurantType(int id)
        {
            RestaurantType restaurantType = await db.RestaurantTypes.FindAsync(id);
            if (restaurantType == null)
            {
                return NotFound();
            }

            db.RestaurantTypes.Remove(restaurantType);
            await db.SaveChangesAsync();

            return Ok(restaurantType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RestaurantTypeExists(int id)
        {
            return db.RestaurantTypes.Count(e => e.Id == id) > 0;
        }
    }
}