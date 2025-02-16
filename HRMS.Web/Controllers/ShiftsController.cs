using HRMS.Application.Interfaces;
using HRMS.Core.Entities;
using HRMS.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Web.Controllers
{
    public class ShiftsController : BaseController<Shift>
    {
        public ShiftsController(IBaseService<Shift> shiftService) : base(shiftService)
        {
         
        }
        public override IActionResult Create()
        {
            ShiftViewModel shiftViewModel = new ShiftViewModel();
            return View(shiftViewModel);
        }
    }
}
