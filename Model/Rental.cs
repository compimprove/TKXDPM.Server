using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TKXDPM_API.Model
{
    public class Rental
    {
        [Key] public int RentalId { get; set; }
        public int BikeId { get; set; }
        public Bike Bike { get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }
        public int RenterId { get; set; }
        public Renter Renter { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string RateContent { get; set; }
        public int RateNumber { get; set; }
    }

    public class RentalResponse
    {
        public RentalResponse()
        {
            Renter = new Renter();
            Bike = new BikeResponse();
            RateContent = "Good";
            RateNumber = 5;
        }

        public Renter Renter { get; set; }
        public BikeResponse Bike { get; set; }
        public string RateContent { get; set; }
        public int RateNumber { get; set; }
    }
}