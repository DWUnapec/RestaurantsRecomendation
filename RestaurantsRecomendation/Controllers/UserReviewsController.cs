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
    public class UserReviewsController : ApiController
    {
        private RestaurantsContext db = new RestaurantsContext();

        // GET: api/UserReviews
        public IQueryable<UserReview> GetUserReviews()
        {
            return db.UserReviews;
        }

        // GET: api/UserReviews/5
        [ResponseType(typeof(UserReview))]
        public async Task<IHttpActionResult> GetUserReview(int id)
        {
            UserReview userReview = await db.UserReviews.FindAsync(id);
            if (userReview == null)
            {
                return NotFound();
            }

            return Ok(userReview);
        }

        // PUT: api/UserReviews/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUserReview(int id, UserReview userReview)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userReview.Id)
            {
                return BadRequest();
            }

            db.Entry(userReview).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserReviewExists(id))
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

        // POST: api/UserReviews
        [ResponseType(typeof(UserReview))]
        public async Task<IHttpActionResult> PostUserReview(UserReview userReview)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserReviews.Add(userReview);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = userReview.Id }, userReview);
        }

        // DELETE: api/UserReviews/5
        [ResponseType(typeof(UserReview))]
        public async Task<IHttpActionResult> DeleteUserReview(int id)
        {
            UserReview userReview = await db.UserReviews.FindAsync(id);
            if (userReview == null)
            {
                return NotFound();
            }

            db.UserReviews.Remove(userReview);
            await db.SaveChangesAsync();

            return Ok(userReview);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserReviewExists(int id)
        {
            return db.UserReviews.Count(e => e.Id == id) > 0;
        }
    }
}