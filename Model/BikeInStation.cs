using System;

namespace TKXDPM_API.Model
{
    public class BikeInStation
    {
        public int StationId { get; set; }
        public Station Station { get; set; }
        public int BikeId { get; set; }
        public Bike Bike { get; set; }
        public DateTime DateTimeIn { get; set; }
        public DateTime DateTimeOut { get; set; }
    }
}