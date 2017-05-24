using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Address
    {
        [Key]
        [ForeignKey("Restaurant")]
        public int Id { get; set; }
        public Restaurant Restaurant { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }
    }
}