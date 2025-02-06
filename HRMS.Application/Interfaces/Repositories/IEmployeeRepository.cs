using HRMS.Core.Entities;

namespace HRMS.Application.Interfaces.Repositories
{
    public interface IEmployeeRepository
    {
        public Task<List<Employee>> GetEmployeesAsync();
    }
}
