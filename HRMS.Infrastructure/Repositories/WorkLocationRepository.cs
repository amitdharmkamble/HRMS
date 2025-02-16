using HRMS.Application.Interfaces.Repositories;
using HRMS.Core.Entities;
using HRMS.Infrastructure.Persistence;

namespace HRMS.Infrastructure.Repositories
{
    public class WorkLocationRepository : BaseRepository<WorkLocation>, IWorkLocationRepository
    {
        public WorkLocationRepository(HRMSDbContext context) : base(context) { }
    }
}
