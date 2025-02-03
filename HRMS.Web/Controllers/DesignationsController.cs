using HRMS.Application.Interfaces;
using HRMS.Core.Entities;
using HRMS.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Web.Controllers
{
    public class DesignationsController : BaseController<Designation>
    {
        public DesignationsController(IBaseService<Designation> service) : base(service) { }
    }
}
