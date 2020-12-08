using System;
using System.Collections.Generic;
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
        [Column(TypeName = "varchar(255)")] public string RateContent { get; set; }
        public Transaction Transaction { get; set; }
        public int RateNumber { get; set; }

        public static List<Rental> GetSeederData()
        {
            return new List<Rental>
            {
                new Rental()
                {
                    RentalId = 100001, BikeId = 100001, CardId = 100001, RateContent = "Mọi thứ đều tốt.",
                    RateNumber = 5, RenterId = 100001
                },
                new Rental()
                {
                    RentalId = 100002, BikeId = 100002, CardId = 100002, RateContent = "Tuyệt vời.", RateNumber = 5,
                    RenterId = 100002
                },
                new Rental()
                {
                    RentalId = 100003, BikeId = 200001, CardId = 100003, RateContent = "Mọi thứ đều tốt.",
                    RateNumber = 5, RenterId = 100003
                },
                new Rental()
                {
                    RentalId = 100004, BikeId = 200002, CardId = 100001, RateContent = "Xe đi rất thoải mái.",
                    RateNumber = 4, RenterId = 100004
                },
                new Rental()
                {
                    RentalId = 100005, BikeId = 300001, CardId = 100001, RateContent = "Mọi thứ đều tốt.",
                    RateNumber = 5, RenterId = 100005
                },
                new Rental()
                {
                    RentalId = 100006, BikeId = 100004, CardId = 100001, RateContent = "Trải nghiệm thú vị.",
                    RateNumber = 5, RenterId = 100006
                },
            };
        }

       
    }

    public class RentalResponse
    {
        public BikeResponse Bike { get; set; }
        public CardResponse Card { get; set; }
        public TransactionResponse Transaction { get; set; }
        public string RateContent { get; set; }
        public int RateNumber { get; set; }
    }
}