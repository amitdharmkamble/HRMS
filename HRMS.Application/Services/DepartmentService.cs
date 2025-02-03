using HRMS.Application.Interfaces;
using HRMS.Application.Interfaces.Repositories;
using HRMS.Core.Entities;

namespace HRMS.Application.Services
{
    public class DepartmentService : BaseService<Department>, IDepartmentService
    {
        public DepartmentService(IBaseRepository<Department> repository) : base(repository) { }
    }
}
