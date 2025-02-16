using HRMS.Application.Interfaces;
using HRMS.Core.Entities;

namespace HRMS.Web.Controllers
{
    public class WorkLocationsController : BaseController<WorkLocation>
    {
        public WorkLocationsController(IBaseService<WorkLocation> service) : base(service) { }
    }
}
