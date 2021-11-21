using AutoMapper;
using MiniApp1.Core.DTOs;
using MiniApp1.Core.Models;

namespace MiniApp1.Service
{
    internal class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<EmployeeDto, Employee>().ReverseMap();
            CreateMap<CourseDto, Course>().ReverseMap();
            CreateMap<AssignmentDto,Assignment>().ReverseMap();
        }
    }
}
