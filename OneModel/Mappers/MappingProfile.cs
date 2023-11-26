using AutoMapper;
using OneModel.DTOs;
using OneModel.Entities;

namespace OneModel.Mappers;

public class MappingProfile : Profile
{
    //Users
    public MappingProfile()
    {
        CreateMap<User, UserCreationDto>().ReverseMap();
        CreateMap<UserUpdateDto, User>().ReverseMap();
        CreateMap<UserResultDto, User>().ReverseMap();
    }
}
