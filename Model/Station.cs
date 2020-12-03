using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TKXDPM_API.Model
{
    public class Station
    {
        [Key] public int StationId { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }
        [Column(TypeName = "varchar(255)")] public string ContactName { get; set; }
        [Column(TypeName = "varchar(255)")] public string Email { get; set; }
        [Column(TypeName = "varchar(255)")] public string Phone { get; set; }
        public float Area { get; set; }
    }

    public class StationResponse
    {
        public StationResponse()
        {
            ContactName = "ContactName";
            Email = "Email";
            Phone = "Phone";
            Address = new AddressResponse();
            ListBike = new List<BikeResponse>()
            {
                new BikeResponse(),
                new BikeResponse(),
                new BikeResponse()
            };
            Area = 10;
        }
        public string ContactName { get; set; }
        public string Email { get; set; } 
        public string Phone { get; set; }
        public float Area { get; set; }
        public AddressResponse Address { get; set; }
        public List<BikeResponse> ListBike { get; set; }
    }
}