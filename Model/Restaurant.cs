using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
        public RestaurantType RestaurantType { get; set; }
        public FoodType FoodType { get; set; }
        public Address Address { get; set; }
        public double MinPrice { get; set; }
        public double MaxPrice { get; set; }
        public string PhoneNumber { get; set; }

        public int RestaurantTypeId { get; set; }
        public int FoodTypeId { get; set; }
    }
}
