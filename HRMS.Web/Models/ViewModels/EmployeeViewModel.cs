using System.ComponentModel.DataAnnotations;

namespace HRMS.Web.Models.ViewModels
{
    public class EmployeeViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(20)]
        public string EmpCode { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [StringLength(50)]
        public string MiddleName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Gender { get; set; } = string.Empty;

        [Required]
        public string MaritalStatus { get; set; } = string.Empty;

        [Required]
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; } = string.Empty;

        public EmployeeContactViewModel Contact { get; set; } = new EmployeeContactViewModel();
        public EmployeeSalaryViewModel Salary { get; set; } = new EmployeeSalaryViewModel();

        public List<EmployeeDocumentViewModel> Documents { get; set; } = new List<EmployeeDocumentViewModel>();
        public List<EmployeeContactPersonViewModel> ContactPersons { get; set; } = new List<EmployeeContactPersonViewModel>();
    }

    public class EmployeeContactViewModel
    {
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }

    public class EmployeeSalaryViewModel
    {
        public decimal BasicSalary { get; set; }
        public decimal Allowances { get; set; }
        public decimal Deductions { get; set; }
        public decimal NetSalary => BasicSalary + Allowances - Deductions;
    }

    public class EmployeeDocumentViewModel
    {
        public Guid DocumentId { get; set; }
        public string DocumentName { get; set; } = string.Empty;
        public string DocumentType { get; set; } = string.Empty;
    }

    public class EmployeeContactPersonViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Relationship { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}
