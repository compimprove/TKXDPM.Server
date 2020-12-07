using AutoMapper;
using TKXDPM_API.Model;

namespace TKXDPM_API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CardRequest, Card>();
            CreateMap<Station, StationResponse>();
            CreateMap<Address, AddressResponse>();
            CreateMap<Bike, BikeResponse>();
        }
    }
}