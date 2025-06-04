using AutoMapper;
using LeverX.WebAPI.Features.Employees.Dto;
using MusicStore.Core.Data;

namespace LeverX.WebAPI.Mapping
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeReadDto>();
            CreateMap<EmployeeReadDto, Employee>();
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();

        }
    }
}