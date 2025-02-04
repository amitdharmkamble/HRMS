using System.ComponentModel.DataAnnotations;

namespace HRMS.Core.Entities
{
    public class EmployeeDocument
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

        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
