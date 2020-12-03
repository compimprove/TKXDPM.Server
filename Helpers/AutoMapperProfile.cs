using AutoMapper;
using TKXDPM_API.Model;

namespace TKXDPM_API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CardRequest, Card>();
        }
    }
}