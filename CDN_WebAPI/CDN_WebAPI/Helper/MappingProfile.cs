using AutoMapper;
using CDN_WebAPI.Dto;
using CDN_WebAPI.Models;

namespace CDN_WebAPI.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserModel, UserDto>().ReverseMap();
            CreateMap<SkillSetModel, SkillSetDto>().ReverseMap();
            CreateMap<HobbyModel, HobbyDto>().ReverseMap();
        }
    }
}
