using AutoMapper;
using HRMS.Application.DTOs.Employee;
using HRMS.Application.Interfaces;
using HRMS.Application.Interfaces.Repositories;

namespace HRMS.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepo, IMapper mapper)
        {
            _employeeRepo = employeeRepo;
            _mapper = mapper;
        }

        public async Task<List<EmployeeServiceModel>> GetEmployeesAsync()
        {
            var employees = await _employeeRepo.GetEmployeesAsync();
            return _mapper.Map<List<EmployeeServiceModel>>(employees);
        }
    }
}
