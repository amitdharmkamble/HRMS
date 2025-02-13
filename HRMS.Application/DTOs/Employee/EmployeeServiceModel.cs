using System.ComponentModel.DataAnnotations;

namespace HRMS.Application.DTOs.Employee
{
    public class EmployeeServiceModel
    {
        public Guid Id { get; set; }
        [MaxLength(10)]
        public string EmpCode { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;
        [MaxLength(100)]
        public string MiddleName { get; set; } = string.Empty;
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public Guid DepartmentId { get; set; }
        [Required]
        public Guid DesignationId { get; set; }
        public string DesignationName { get; set; } = string.Empty;
        public string DepartmentName { get; set; } = string.Empty;

        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Gender { get; set; } = string.Empty;
        [Required]
        public string MaritalStatus { get; set; } = string.Empty;
        public DateTime DateOfJoining { get; set; }
    }
}
