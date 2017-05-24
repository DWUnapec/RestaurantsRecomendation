using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class RestaurantsContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<FoodType> FoodTypes { get; set; }
        public DbSet<RestaurantType> RestaurantTypes { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserReview> UserReviews { get; set; }

    }
}
