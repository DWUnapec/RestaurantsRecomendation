using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserReview
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Restaurant Restaurant { get; set; }
        public double Rating { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }

        public int UserId { get; set; }
        public int RestaurantId { get; set; }
    }
}
