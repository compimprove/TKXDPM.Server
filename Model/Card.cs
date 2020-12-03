using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TKXDPM_API.Model
{
    public class Card
    {
        [Key] public int CardId { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string RenterId { get; set; }
        public Renter Renter { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string PaymentMethod { get; set; }
        public int Cvv { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string ExpirationDate { get; set; }
    }

    public class CardRequest
    {
        public string RenterId { get; set; }
        public string PaymentMethod { get; set; }
        public int Cvv { get; set; }
        public string ExpirationDate { get; set; }
    }

    public class CardResponse
    {
        public CardResponse()
        {
            PaymentMethod = "PaymentMethod";
            Cvv = 700;
            ExpirationDate = new DateTime(2021,10,10).ToShortDateString();
        }
        public string PaymentMethod { get; set; }
        public int Cvv { get; set; }
        public string ExpirationDate { get; set; }
    }
}