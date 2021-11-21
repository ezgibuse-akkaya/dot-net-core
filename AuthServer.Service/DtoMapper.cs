using AuthServer.Core.DTOs;
using AuthServer.Core.Models;
using AutoMapper;

namespace AuthServer.Service
{
    internal class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<UserAppDto, UserApp>().ReverseMap();
        }
    }
}
