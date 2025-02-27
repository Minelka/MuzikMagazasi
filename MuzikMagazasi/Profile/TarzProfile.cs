using AutoMapper;
using MuzikMagazasi.Context.Entities;
using MuzikMagazasi.Models;

namespace MuzikMagazasi.MapperProfiles
{
    public class TarzProfile : Profile
    {
        public TarzProfile()
        {
            CreateMap<TarzViewModel, Tarz>()
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.Status))
            .ReverseMap();
        }
    }
}
