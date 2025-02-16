using HRMS.Application.Interfaces;
using HRMS.Application.Interfaces.Repositories;
using HRMS.Core.Entities;

namespace HRMS.Application.Services
{
    public class WorkLocationService : BaseService<WorkLocation>, IWorkLocationService
    {
        public WorkLocationService(IWorkLocationRepository repository) : base(repository)
        {
        }
    }
}
