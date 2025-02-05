using System.ComponentModel.DataAnnotations;

namespace HRMS.Core.Entities
{
    public class Employee : BaseEntity
    {
        [MaxLength(10)]
        public string EmpCode { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;
        [MaxLength(100)]
        public string MiddleName { get; set; } = string.Empty;
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Gender { get; set; } = string.Empty;
        [Required]
        public string MaritalStatus { get; set; } = string.Empty;

        [Required]
        public Guid DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        [Required]
        public Guid DesignationId { get; set; }
        public virtual Designation Designation { get; set; }
        public virtual EmployeeContact Contact { get; set; }
        public virtual EmployeeSalary Salary { get; set; }

        public virtual ICollection<EmployeeDocument> Documents { get; set; } = new List<EmployeeDocument>();

        public virtual ICollection<EmployeeContactPerson> ContactPersons { get; set; } = new List<EmployeeContactPerson>();
    }

}
