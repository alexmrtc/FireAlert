using AutoMapper;
using FireAlert.DTOs;

namespace FireAlert.Utilities;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Models.FireAlert, FireAlertDto>();
    }
}