using System.ComponentModel.DataAnnotations;

namespace HRMS.Core.Entities
{
    public class EmployeeContactPerson
    {
        [Key]
        public Guid Id { get; set; }

        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Relationship { get; set; }
        [Required]
        public string Phone { get; set; }
        public string WorkPhone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string WorkEmail { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

    }
}
