using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TKXDPM_API.Model
{
    public class Transaction
    {
        [Key] public int TransactionId { get; set; }
        public int RentalId { get; set; }
        public Rental Rental { get; set; }
        [Column(TypeName = "varchar(255)")] public bool PaymentStatus { get; set; }
        public DateTime BookedStartDateTime { get; set; } = DateTime.MinValue;
        public DateTime BookedEndDateTime { get; set; } = DateTime.MinValue;
        public DateTime ActualStartDateTime { get; set; } = DateTime.MinValue;
        public DateTime ActualEndDateTime { get; set; } = DateTime.MinValue;
    }

    public class TransactionResponse
    {
        public TransactionResponse()
        {
            TransactionId = 1;
            PaymentStatus = false;
            BookedStartDateTime = new DateTime(2020, 10, 20).ToShortDateString();
            BookedEndDateTime = BookedStartDateTime;
            ActualStartDateTime = BookedStartDateTime;
            ActualEndDateTime = BookedStartDateTime;
        }

        [Key] public int TransactionId { get; set; }
        public Rental Rental { get; set; }
        [Column(TypeName = "varchar(255)")] public bool PaymentStatus { get; set; }
        public string BookedStartDateTime { get; set; }
        public string BookedEndDateTime { get; set; }
        public string ActualStartDateTime { get; set; }
        public string ActualEndDateTime { get; set; }
    }
}