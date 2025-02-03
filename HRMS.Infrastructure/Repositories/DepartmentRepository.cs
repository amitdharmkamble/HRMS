using HRMS.Application.Interfaces.Repositories;
using HRMS.Core.Entities;
using HRMS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Infrastructure.Repositories
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(HRMSDbContext context) : base(context) { }
    }
}
