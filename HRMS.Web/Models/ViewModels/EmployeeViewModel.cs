using HRMS.Core.Entities;
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
        public string Gender { get; set; } = string.Empty;

        public string MaritalStatus { get; set; } = string.Empty;

        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; } = string.Empty;

        public Guid DesignationId { get; set; }
        public string DesignationName { get; set; } = string.Empty;

        public EmployeeContactViewModel? Contact { get; set; }
        public EmployeeSalaryViewModel? Salary { get; set; }

        public List<EmployeeDocumentViewModel>? Documents { get; set; }
        public List<EmployeeContactPersonViewModel>? ContactPersons { get; set; }
    }

    public class EmployeeContactViewModel
    {
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public string PersonalPhone { get; set; } = string.Empty;
        public string PersonalEmail { get; set; } = string.Empty;

        public string WorkPhone { get; set; } = string.Empty;
        public string WorkEmail { get; set; } = string.Empty;

        public string Skype { get; set; } = string.Empty;
        public string LinkedIn { get; set; } = string.Empty;
        public string Facebook { get; set; } = string.Empty;
        public string Twitter { get; set; } = string.Empty;
        public string Instagram { get; set; } = string.Empty;
        public string OtherSocialMedia { get; set; } = string.Empty;
    }

    public class EmployeeSalaryViewModel
    {
        public decimal BasicSalary { get; set; }
        public decimal HRA { get; set; }
        public decimal OtherAllowances { get; set; }
    }

    public class EmployeeDocumentViewModel
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string DocumentName { get; set; } = string.Empty;

        [Required]
        public string DocumentPath { get; set; } = string.Empty;

        [Required]
        public string DocumentType { get; set; } = string.Empty;

        public string DocumentNumber { get; set; } = string.Empty;
    }

    public class EmployeeContactPersonViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Relationship { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}
