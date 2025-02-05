using HRMS.Application.Interfaces;
using HRMS.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Api.Controllers
{
    [ApiController]
    public class DepartmentApiController : BaseApiMasterController<Department>
    {
        public DepartmentApiController(IBaseService<Department> service) : base(service)
        {
        }
    }
}
