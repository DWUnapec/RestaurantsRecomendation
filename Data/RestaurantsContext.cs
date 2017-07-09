using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().Property(a => a.Latitude).HasPrecision(18, 9);
            modelBuilder.Entity<Address>().Property(a => a.Longitude).HasPrecision(18, 9);

            modelBuilder.Entity<Restaurant>()
             .Property(e => e.Id)
             .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<User>()
           .Property(e => e.Id)
           .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            base.OnModelCreating(modelBuilder);
         }
        
    }


}
