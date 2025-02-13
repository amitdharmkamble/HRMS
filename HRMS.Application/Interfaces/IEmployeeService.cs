using HRMS.Application.DTOs.Employee;

namespace HRMS.Application.Interfaces
{
    public interface IEmployeeService
    {
        public Task<List<EmployeeServiceModel>> GetEmployeesAsync();

        public Task<EmployeeServiceModel> AddEmployeeAsync(EmployeeServiceModel model);
        public Task<bool> UpdateEmployeePersonalDetailsAsync(EmployeeServiceModel model);
    }
}
