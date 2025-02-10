using HRMS.Application.DTOs.Employee;
using HRMS.Application.Interfaces;
using HRMS.Core.Entities;
using HRMS.Web.Models.ViewModels;
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

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                EmployeeServiceModel serviceModel = new EmployeeServiceModel
                {
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName,
                    EmpCode = model.EmpCode,
                    DepartmentId = model.DepartmentId,
                    DesignationId = model.DesignationId,
                };
                var employee = await _employeeService.AddEmployeeAsync(serviceModel);
                return PartialView("Create", model);
            }
            return View(model);
        }
    }
}
