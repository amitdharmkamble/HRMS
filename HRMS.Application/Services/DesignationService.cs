using HRMS.Application.Interfaces;
using HRMS.Application.Interfaces.Repositories;
using HRMS.Core.Entities;

namespace HRMS.Application.Services
{
    public class DesignationService : BaseService<Designation>, IDesignationService
    {
        public DesignationService(IDesignationRepository repository) : base(repository) { }
    }
}
