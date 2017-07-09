using FileHelpers;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantsRecomendation.Utils
{
    public class DataGenerator
    {

        public static IEnumerable<UserReview> GetUserReviews(string reviewsUri)
        {
            var engine = new FileHelperEngine<ReviewCsv>();

            var res = engine.ReadFile(reviewsUri);
            foreach (ReviewCsv review in res)
            {
                Console.WriteLine("Order Info:");
            }

            return res.Select(x=>new UserReview() { UserId = ParseId(x.userID), RestaurantId = x.placeID, ServiceRating = x.service_rating, Rating = x.rating,FoodRating = x.food_rating, Date = DateTime.Now});
        }

        public static IEnumerable<Restaurant> GetRestaurants(string restaurantUri)
        {
            var engine = new FileHelperEngine<RestaurantCsv>();

            var res = engine.ReadFile(restaurantUri);
            foreach (RestaurantCsv restaurant in res)
            {
                Console.WriteLine("Order Info:");
            }
            return res.Select(x => new Restaurant() { Id = x.placeID, Name = x.name, Address = new Address() {City=x.city,Country = x.country },FoodTypeId =3,RestaurantTypeId=5 });
        }


        public static IEnumerable<User> GetUsers(string usersUri)
        {
            var engine = new FileHelperEngine<UserCsv>();

             var res = engine.ReadFile(usersUri);
            foreach (UserCsv user in res)
            {
                Console.WriteLine("Order Info:");
            }
            return res.Select(x=>new User() {Id = ParseId(x.userId),BirthDate = DateTime.Now });
        }


        public static IEnumerable<FoodType> GetFoodTypes(string cuisineUris)
        {
            var engine = new FileHelperEngine<CuisineCsv>();

            var res = engine.ReadFile(cuisineUris);
            foreach (CuisineCsv cuisine in res)
            {
                Console.WriteLine("Order Info:");
            }
            return res.Select(x => new FoodType() { Id = ParseId(x.Rcuisine) });
        }

        public static List<decimal[]> GetCoords(string coordsDir)
        {
            var coordList = new List<decimal[]>();
            var engine = new FileHelperEngine<Coord>();

            var res = engine.ReadFile(coordsDir);
            foreach (Coord coord in res)
            {
                coordList.Add(new decimal[] { coord.lat, coord.lon });
            }
            return coordList;
        }

        private static int ParseId(string id)
        {
            return Int32.Parse(id.Split('U')[1]);
        }

        [IgnoreFirst(1)]
        [DelimitedRecord(",")]
        class UserCsv
        {
            public string userId;
            public decimal latitude;
            public decimal longitude;
            public string smoker;
            public string drink_level;
            public string dress_preference;
            public string ambience;
            public string transport;
            public string marital_status;
            public string hijos;
            public string birth_year;
            public string interest;
            public string personality;
            public string religion;
            public string activity;
            public string color;
            public string weight;
            public string budget;
            public string height;

        }

        [IgnoreFirst(1)]
        [DelimitedRecord(",")]
        class RestaurantCsv
        {
            public int placeID;
            public decimal latitude;
            public decimal longitude;
            public string the_geom_meter;
            public string name;
            public string address;
            public string city;
            public string state;
            public string country;
            public string fax;
            public string zip;
            public string alcohol;
            public string smoking_area;
            public string dress_code;
            public string accessibility;
            public string price;
            public string url;
            public string Rambience;
            public string franchise;
            public string area;
            public string other_services;
        }

        [IgnoreFirst(1)]
        [DelimitedRecord(",")]
        class ReviewCsv
        {
            public string userID;
            public int placeID;
            public int rating;
            public int food_rating;
            public int service_rating;
        }

        [IgnoreFirst(1)]
        [DelimitedRecord(",")]
        class CuisineCsv
        {
            public int placeID;
            public string Rcuisine;
        }

        [IgnoreFirst(1)]
        [DelimitedRecord(",")]
        class Coord
        {
            public decimal lat;
            public decimal lon;
        }
    }


    [DelimitedRecord(",")]
    class Preference
    {
        public int userID;
        public int itemId;
        public double valueuserId;
    }
}