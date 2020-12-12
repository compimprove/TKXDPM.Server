using System.Collections.Generic;
using TKXDPM_API.Model;

namespace TKXDPM_API.Seeder
{
    public static class StationSeeder
    {
         public static List<Station> GetSeederData()
        {
            return new List<Station>
            {
                new Station()
                {
                    StationId = 1001,
                    AddressId = 1001,
                    ContactName = "Hạ Đình",
                    Email = "ecohadinh@gmail.ccom",
                    Phone = "0906232138",
                    Area = 500
                },
                new Station()
                {
                    StationId = 1002,
                    AddressId = 1002,
                    ContactName = "Lê Trọng Tấn",
                    Email = "ecoletrongtan@gmail.com",
                    Phone = "0962610374",
                    Area = 500
                },
                new Station()
                {
                    StationId = 1003,
                    AddressId = 1003,
                    ContactName = "Lương Thế Vinh",
                    Email = "ecoluongthevinh@gmail.com",
                    Phone = "0936656669",
                    Area = 500
                },
                new Station()
                {
                    StationId = 1004,
                    AddressId = 1004,
                    ContactName = "Khuất Duy Tiến",
                    Email = "ecokhuatduytien@gmail.com",
                    Phone = "0466519528",
                    Area = 500
                },
                new Station()
                {
                    StationId = 1005,
                    AddressId = 1005,
                    ContactName = "Nguyễn Trãi",
                    Email = "econguyentrai@gmail.com",
                    Phone = "0987866389",
                    Area = 500
                },
                new Station()
                {
                    StationId = 1006,
                    AddressId = 1006,
                    ContactName = "Trường Chinh",
                    Email = "ecotruongchinh@gmail.com",
                    Phone = "0987866389",
                    Area = 500
                },
            };
        }
    }
}