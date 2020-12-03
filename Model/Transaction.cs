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
        [Column(TypeName = "varchar(255)")]
        public string PaymentStatus { get; set; }
        public DateTime BookedStartDateTime { get; set; }
        public DateTime BookedEndDateTime { get; set; }
        public DateTime ActualStartDateTime { get; set; }
        public DateTime ActualEndDateTime { get; set; }
    }
}