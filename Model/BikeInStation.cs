using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public static List<BikeInStation> GetSeederData()
        {
            return new List<BikeInStation>
            {
                new BikeInStation()
                {
                    StationId = 1001, BikeId = 100001, DateTimeIn = new DateTime(2020, 11, 10),
                    DateTimeOut = new DateTime(2020, 12, 12)
                },
                new BikeInStation()
                {
                    StationId = 1001, BikeId = 100002, DateTimeIn = new DateTime(2020, 11, 10),
                    DateTimeOut = new DateTime(2020, 12, 12)
                },
                new BikeInStation()
                {
                    StationId = 1001, BikeId = 200001, DateTimeIn = new DateTime(2020, 11, 10),
                    DateTimeOut = new DateTime(2020, 12, 12)
                },
                new BikeInStation()
                {
                    StationId = 1001, BikeId = 300001, DateTimeIn = new DateTime(2020, 11, 10),
                    DateTimeOut = new DateTime(2020, 12, 12)
                },

                new BikeInStation()
                {
                    StationId = 1002, BikeId = 100003, DateTimeIn = new DateTime(2020, 11, 10),
                    DateTimeOut = new DateTime(2020, 12, 12)
                },
                new BikeInStation()
                {
                    StationId = 1002, BikeId = 100004, DateTimeIn = new DateTime(2020, 11, 10),
                    DateTimeOut = new DateTime(2020, 12, 12)
                },
                new BikeInStation()
                {
                    StationId = 1002, BikeId = 200002, DateTimeIn = new DateTime(2020, 11, 10),
                    DateTimeOut = new DateTime(2020, 12, 12)
                },
                new BikeInStation()
                {
                    StationId = 1002, BikeId = 300002, DateTimeIn = new DateTime(2020, 11, 10),
                    DateTimeOut = new DateTime(2020, 12, 12)
                },

                new BikeInStation()
                {
                    StationId = 1003, BikeId = 100005, DateTimeIn = new DateTime(2020, 11, 10),
                    DateTimeOut = new DateTime(2020, 12, 12)
                },
                new BikeInStation()
                {
                    StationId = 1003, BikeId = 100006, DateTimeIn = new DateTime(2020, 11, 10),
                    DateTimeOut = new DateTime(2020, 12, 12)
                },
                new BikeInStation()
                {
                    StationId = 1003, BikeId = 200003, DateTimeIn = new DateTime(2020, 11, 10),
                    DateTimeOut = new DateTime(2020, 12, 12)
                },
                new BikeInStation()
                {
                    StationId = 1003, BikeId = 300003, DateTimeIn = new DateTime(2020, 11, 10),
                    DateTimeOut = new DateTime(2020, 12, 12)
                },

                new BikeInStation()
                {
                    StationId = 1004, BikeId = 200004, DateTimeIn = new DateTime(2020, 11, 10),
                    DateTimeOut = new DateTime(2020, 12, 12)
                },
                new BikeInStation()
                {
                    StationId = 1004, BikeId = 200005, DateTimeIn = new DateTime(2020, 11, 10),
                    DateTimeOut = new DateTime(2020, 12, 12)
                },
                new BikeInStation()
                {
                    StationId = 1004, BikeId = 300004, DateTimeIn = new DateTime(2020, 11, 10),
                    DateTimeOut = new DateTime(2020, 12, 12)
                },
                new BikeInStation()
                {
                    StationId = 1004, BikeId = 300005, DateTimeIn = new DateTime(2020, 11, 10),
                    DateTimeOut = new DateTime(2020, 12, 12)
                },

                new BikeInStation()
                {
                    StationId = 1005, BikeId = 200006, DateTimeIn = new DateTime(2020, 11, 10),
                    DateTimeOut = new DateTime(2020, 12, 12)
                },
                new BikeInStation()
                {
                    StationId = 1005, BikeId = 300006, DateTimeIn = new DateTime(2020, 11, 10),
                    DateTimeOut = new DateTime(2020, 12, 12)
                },
            };
        }
    }
}