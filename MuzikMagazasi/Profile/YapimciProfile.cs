using AutoMapper;
using MuzikMagazasi.Context.Entities;
using MuzikMagazasi.Models;

namespace MuzikMagazasi.MapperProfiles
{
    public class YapimciProfile : Profile
    {
        public YapimciProfile()
        {
            CreateMap<YapimciViewModel, Yapimci>()
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.Status))
            .ReverseMap();
        }
    }
}
