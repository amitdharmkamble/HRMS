using HRMS.Application.Interfaces;
using HRMS.Core.Entities;
using HRMS.Web.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Web.Controllers
{
    public class DepartmentsController : BaseController<Department>
    {
        public DepartmentsController(IBaseService<Department> service) : base(service) { }
    }
}
