namespace TKXDPM_API.Model
{
    public class Rental
    {
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