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
    public class FoodTypesController : ApiController
    {
        private RestaurantsContext db = new RestaurantsContext();

        // GET: api/FoodTypes
        public IQueryable<FoodType> GetFoodTypes()
        {
            return db.FoodTypes;
        }

        // GET: api/FoodTypes/5
        [ResponseType(typeof(FoodType))]
        public async Task<IHttpActionResult> GetFoodType(int id)
        {
            FoodType foodType = await db.FoodTypes.FindAsync(id);
            if (foodType == null)
            {
                return NotFound();
            }

            return Ok(foodType);
        }

        // PUT: api/FoodTypes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFoodType(int id, FoodType foodType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != foodType.Id)
            {
                return BadRequest();
            }

            db.Entry(foodType).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodTypeExists(id))
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

        // POST: api/FoodTypes
        [ResponseType(typeof(FoodType))]
        public async Task<IHttpActionResult> PostFoodType(FoodType foodType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FoodTypes.Add(foodType);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = foodType.Id }, foodType);
        }

        // DELETE: api/FoodTypes/5
        [ResponseType(typeof(FoodType))]
        public async Task<IHttpActionResult> DeleteFoodType(int id)
        {
            FoodType foodType = await db.FoodTypes.FindAsync(id);
            if (foodType == null)
            {
                return NotFound();
            }

            db.FoodTypes.Remove(foodType);
            await db.SaveChangesAsync();

            return Ok(foodType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FoodTypeExists(int id)
        {
            return db.FoodTypes.Count(e => e.Id == id) > 0;
        }
    }
}