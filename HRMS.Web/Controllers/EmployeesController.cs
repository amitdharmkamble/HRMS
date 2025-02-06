using HRMS.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;
        private readonly IDesignationService _designationService;

        public EmployeesController(IEmployeeService employeeService, IDepartmentService departmentService, IDesignationService designationService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
            _designationService = designationService;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await _employeeService.GetEmployeesAsync();
            return View(employees);
        }

        public async Task<IActionResult> Create()
        {
            var departments = await _departmentService.GetAllAsync();
            var designations = await _designationService.GetAllAsync();
            ViewBag.Departments = departments;
            ViewBag.Designations = designations;
            return View();
        }
    }
}
