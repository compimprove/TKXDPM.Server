using System.ComponentModel.DataAnnotations;

namespace TKXDPM_API.Model
{
    public class Renter
    {
        public Renter()
        {
            RenterId = "1011-5004";
            Name = "Nguyen Van Cao";
        }
        [Key] public string RenterId { get; set; }
        public string Name { get; set; }
    }

}