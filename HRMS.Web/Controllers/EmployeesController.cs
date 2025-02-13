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
            IEnumerable<Department> departments = await GetDepartments();
            IEnumerable<Designation> designations = await GetDesingations();
            ViewBag.Departments = departments;
            ViewBag.Designations = designations;
            return View();
        }

        private async Task<IEnumerable<Designation>> GetDesingations()
        {
            return await _designationService.GetAllAsync();
        }

        private async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _departmentService.GetAllAsync();
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
                ViewBag.Departments = await GetDepartments();
                ViewBag.Designations = await GetDesingations();
                var employee = await _employeeService.AddEmployeeAsync(serviceModel);
                return PartialView("_EmployeeDetailsNavigation", model);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditEmployeePersonalDetails(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                EmployeeServiceModel serviceModel = new EmployeeServiceModel
                {
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName,
                    DepartmentId = model.DepartmentId,
                    DesignationId = model.DesignationId,
                    DateOfBirth = model.DateOfBirth,
                    DateOfJoining = model.DateOfJoining,
                    Gender = model.Gender,
                    MaritalStatus = model.MaritalStatus
                };
                try
                {
                    await _employeeService.UpdateEmployeePersonalDetailsAsync(serviceModel);
                    return PartialView("_EmployeeDetailsNavigation", model);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                return View(model);
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult TestToastMessage(ToastViewModel model)
        {
            try
            {
                int i = 0 / 10;
                model.Title = "Success";
                model.Message = "Toast message test successful";
                model.Type = "success";
                model.ResponseCode = 200;
                return View("_ToastMessage", model);
            }
            catch (Exception ex)
            {
                model.Title = "Error";
                model.Message = ex.Message;
                model.Type = "error";
                model.ResponseCode = 500;
                return View("_ToastMessage", model);
            }
        }
    }
}
