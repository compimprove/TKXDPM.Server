using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TKXDPM_API.Model
{
    public class Rental
    {
        [Key] public int RentalId { get; set; }
        [Column(TypeName = "varchar(255)")] public string RateContent { get; set; }
        public int RateNumber { get; set; }

        public int BikeId { get; set; }
        public Bike Bike { get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }
        public int RenterId { get; set; }
        public Renter Renter { get; set; }
        public Transaction Transaction { get; set; }
    }

    public class RentalResponse
    {
        public RentalResponse()
        {
            Renter = new RenterResponse();
            Bike = new BikeResponse();
            Card = new CardResponse();
            Transaction = new TransactionResponse();
            RateContent = "Good";
            RateNumber = 5;
        }

        public RenterResponse Renter { get; set; }
        public BikeResponse Bike { get; set; }
        public CardResponse Card { get; set; }
        public TransactionResponse Transaction { get; set; }
        public string RateContent { get; set; }
        public int RateNumber { get; set; }
    }
}