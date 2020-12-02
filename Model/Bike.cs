using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TKXDPM_API.Model
{
    public class Bike
    {
        [Key] public int BikeId { get; set; }
        [Column(TypeName = "varchar(255)")] public string BikeName { get; set; }
        [Column(TypeName = "varchar(255)")] public string Description { get; set; }
        public int StartingRent { get; set; }
        public int HourlyRent { get; set; }
        public BikeType Type { get; set; }
        [Column(TypeName = "varchar(255)")] public string LicensePlates { get; set; }
        public int BatterCapacity { get; set; }
        public float PowerDrain { get; set; }
        public int Deposit { get; set; }
    }

    public class BikeResponse
    {
        public BikeResponse()
        {
            BikeName = "BikeName";
            Description = "Address";
            StartingRent = 10;
            HourlyRent = 11;
            Type = BikeType.Double;
            LicensePlates = "Address";
            BatterCapacity = 10;
            PowerDrain = 0.6F;
            Deposit = 100000;
        }
        public string BikeName { get; set; }
        public string Description { get; set; }
        public int StartingRent { get; set; }
        public int HourlyRent { get; set; }
        public BikeType Type { get; set; }
        public string LicensePlates { get; set; }
        public int BatterCapacity { get; set; }
        public float PowerDrain { get; set; }
        public int Deposit { get; set; }
    }

    public enum BikeType
    {
        Single = 1,
        Double = 2,
        Electric = 3,
    }
}