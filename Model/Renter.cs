using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TKXDPM_API.Model
{
    public class Renter
    {
        public Renter()
        {
            RenterId = 20175004;
            Name = "Nguyen Van Cao";
        }
        
        [Key] public int RenterId { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }

        public static List<Renter> GetSeederData()
        {
            return new List<Renter>
            {
                new Renter() {Name ="Group 4",RenterId = 100001},
                new Renter() {Name ="Nguyễn Văn Linh",RenterId = 100002},
                new Renter() {Name ="Phạm Huy Hoàng",RenterId = 100003},
                new Renter() {Name ="Trần Đình Đức",RenterId = 100004},
                new Renter() {Name ="Vũ Duy Tiến",RenterId = 100005},
                new Renter() {Name ="Phạm Mạnh Cường",RenterId = 100006},
                new Renter() {Name ="Trần Văn Tâm",RenterId = 100007},
                new Renter() {Name ="Khổng Hoàng Phong",RenterId = 100008}
                
            };
        }
        [Column(TypeName = "varchar(255)")]
        public string DeviceCode { get; set; }
        public Rental Rental { get; set; }
    }

    public class RenterResponse
    {
        public RenterResponse()
        {
            RenterId = 1;
            DeviceCode = "1011-5004";
            Name = "Nguyen Van Cao";
        }
        public int RenterId { get; set; }
        public string Name { get; set; }
        public string DeviceCode { get; set; }
    }

}