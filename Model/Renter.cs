using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TKXDPM_API.Model
{
    public class Renter
    {
        public Renter()
        {
            RenterId = "1011-5004";
            Name = "Nguyen Van Cao";
        }
        [Column(TypeName = "varchar(255)")]
        [Key] public string RenterId { get; set; }
        public string Name { get; set; }
        public Rental Rental { get; set; }
    }

}