using AutoMapper;
using HRMS.Application.DTOs.Employee;
using HRMS.Core.Entities;

namespace HRMS.Application.Mappings
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<Employee, EmployeeServiceModel>().ReverseMap();
        }
    }
}
