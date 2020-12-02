using System;

namespace TKXDPM_API.Model
{
    public class Card
    {
        
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