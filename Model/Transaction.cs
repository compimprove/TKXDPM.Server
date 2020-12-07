using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TKXDPM_API.Model
{
    public class Transaction
    {
        [Key] public int TransactionId { get; set; }
        public int RentalId { get; set; }
        public Rental Rental { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public DateTime BookedStartDateTime { get; set; } = DateTime.MinValue;
        public DateTime BookedEndDateTime { get; set; } = DateTime.MinValue;
        public DateTime ActualStartDateTime { get; set; } = DateTime.MinValue;
        public DateTime ActualEndDateTime { get; set; } = DateTime.MinValue;

        public static List<Transaction> GetSeederData()
        {
            return new List<Transaction>
            {
                new Transaction()
                {
                    TransactionId = 100001, RentalId = 100001,
                    PaymentStatus = PaymentStatus.Deposit,
                    BookedStartDateTime = new DateTime(2020, 12, 3), BookedEndDateTime = new DateTime(2020, 12, 3),
                    ActualStartDateTime = new DateTime(2020, 12, 3, 8, 32, 54),
                    ActualEndDateTime = new DateTime(2020, 12, 3, 10, 14, 54),
                },
                new Transaction()
                {
                    TransactionId = 100002, RentalId = 100001,
                    PaymentStatus = PaymentStatus.Paid,
                    BookedStartDateTime = new DateTime(2020, 12, 5), BookedEndDateTime = new DateTime(2020, 12, 5),
                    ActualStartDateTime = new DateTime(2020, 12, 3, 8, 32, 54),
                    ActualEndDateTime = new DateTime(2020, 12, 3, 10, 14, 54),
                },
                new Transaction()
                {
                    TransactionId = 100003, RentalId = 100001,
                    PaymentStatus = PaymentStatus.NotPay,
                    BookedStartDateTime = new DateTime(2020, 12, 6), BookedEndDateTime = new DateTime(2020, 12, 6),
                    ActualStartDateTime = new DateTime(2020, 12, 3, 8, 32, 54),
                    ActualEndDateTime = new DateTime(2020, 12, 3, 10, 14, 54),
                },
                new Transaction()
                {
                    TransactionId = 100004, RentalId = 100002,
                    PaymentStatus = PaymentStatus.Paid,
                    BookedStartDateTime = new DateTime(2020, 12, 3), BookedEndDateTime = new DateTime(2020, 12, 3),
                    ActualStartDateTime = new DateTime(2020, 12, 3, 8, 32, 54),
                    ActualEndDateTime = new DateTime(2020, 12, 3, 10, 14, 54),
                }
            };
        }
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

    public enum PaymentStatus
    {
        NotPay = 1,
        Deposit = 2,
        Paid = 3
    }
}