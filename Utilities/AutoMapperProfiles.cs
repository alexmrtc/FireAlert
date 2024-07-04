using AutoMapper;
using FireAlert.DTOs;
using FireAlert.DTOs.Create;
using FireAlert.DTOs.Update;
using FireAlert.Models;

namespace FireAlert.Utilities;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Models.FireAlert, FireAlertDto>();
        CreateMap<CreateFireAlertDto, Models.FireAlert>();
        CreateMap<UpdateFireAlertDto, Models.FireAlert>();

        CreateMap<User, UserDto>();
        CreateMap<CreateUserDto, User>();
        CreateMap<UpdateUserDto, User>();
    }
}