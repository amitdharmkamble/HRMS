using AutoMapper;
using HRMS.Application.DTOs.Employee;
using HRMS.Application.Interfaces;
using HRMS.Application.Interfaces.Repositories;
using HRMS.Core.Entities;

namespace HRMS.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IDesignationRepository _designationRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepo, IDesignationRepository designationRepo, IDepartmentRepository departmentRepo, IMapper mapper)
        {
            _employeeRepo = employeeRepo;
            _mapper = mapper;
            _departmentRepository = departmentRepo;
            _designationRepository = designationRepo;
        }

        public async Task<EmployeeServiceModel> AddEmployeeAsync(EmployeeServiceModel model)
        {
            var employee = _mapper.Map<Employee>(model);

            // Attach existing department & designation instead of creating new ones
            if (model.DepartmentId != Guid.Empty)
            {
                employee.Department = await _departmentRepository.GetByIdAsync(model.DepartmentId);
            }

            if (model.DesignationId != Guid.Empty)
            {
                employee.Designation = await _designationRepository.GetByIdAsync(model.DesignationId);
            }
            employee = await _employeeRepo.AddEmployeeAsync(employee);
            return _mapper.Map<EmployeeServiceModel>(employee);
        }

        public async Task<List<EmployeeServiceModel>> GetEmployeesAsync()
        {
            var employees = await _employeeRepo.GetEmployeesAsync();

            if (employees == null || !employees.Any())
                return new List<EmployeeServiceModel>();

            var employeeServiceModels = _mapper.Map<List<EmployeeServiceModel>>(employees);

            foreach (var employee in employeeServiceModels)
            {
                employee.DepartmentName = await _departmentRepository.GetNameByIdAsync(employee.DepartmentId);
                employee.DesignationName = await _designationRepository.GetNameByIdAsync(employee.DesignationId);
            }

            return employeeServiceModels;
        }


    }
}
