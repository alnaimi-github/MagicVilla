using AutoMapper;
using MagicVilla_VillaAPI.Dto.LoginDto;
using MagicVilla_VillaAPI.Dto.Villa;
using MagicVilla_VillaAPI.Dto.VillaNumber;
using MagicVilla_VillaAPI.Models;

namespace MagicVilla_VillaAPI.Mappers
{
    public class MappingConfig:Profile
    {
        public MappingConfig()
        {
            //Villa
            CreateMap<Villa, VillaDto>().ReverseMap();
            CreateMap<VillaCreateDto, Villa>().ReverseMap();
            CreateMap<VillaUpdateDto, Villa>().ReverseMap();
            //VillaNumber
            CreateMap<VillaNumber, VillaNumberDto>().ReverseMap();
            CreateMap<VillaNumber, VillaNumberUpdateDto>().ReverseMap();
            CreateMap<VillaNumber, VillaNumberCreateDto>().ReverseMap();

            //UserIdentity
            CreateMap<ApplicationUser, UserDto>().ReverseMap();



        }
    }
}
