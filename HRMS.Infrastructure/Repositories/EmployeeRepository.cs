using HRMS.Application.Interfaces.Repositories;
using HRMS.Infrastructure.Persistence;

namespace HRMS.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly HRMSDbContext _context;

        public EmployeeRepository(HRMSDbContext context)
        {
            _context = context;
        }


    }
}
