using HRMS.Application.Interfaces.Repositories;
using HRMS.Core.Entities;
using HRMS.Infrastructure.Persistence;

namespace HRMS.Infrastructure.Repositories
{
    public class DesignationRepository : BaseRepository<Designation>, IDesignationRepository
    {
        public DesignationRepository(HRMSDbContext hRMSDbContext) : base(hRMSDbContext) { }
    }
}
