using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TKXDPM_API.Model
{
    public class Address
    {
        [Key] public int AddressId { get; set; }
        [Column(TypeName = "varchar(255)")] public string AddressName { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }

        public static List<Address> GetSeederData()
        {
            return new List<Address>
            {
                new Address() {AddressId = 1, AddressName = "Duong Lang, Ha Noi", Latitude = 100, Longitude = 99},
                new Address() {AddressId = 2, AddressName = "Truong Chinh, Ha Noi", Latitude = 100, Longitude = 99}
            };
        }
    }

    public class AddressResponse
    {
        public AddressResponse()
        {
            AddressName = "AddressName";
            Longitude = 10;
            Latitude = 10;
        }

        public string AddressName { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
    }
}