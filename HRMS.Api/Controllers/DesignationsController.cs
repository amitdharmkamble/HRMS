using HRMS.Application.Interfaces;
using HRMS.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Api.Controllers
{
    public class DesignationsController : BaseApiMasterController<Designation>
    {
        public DesignationsController(IBaseService<Designation> service) : base(service) { } 
    }
}
