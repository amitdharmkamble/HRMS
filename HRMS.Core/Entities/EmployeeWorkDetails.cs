using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Core.Entities
{
    public class EmployeeWorkDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }

        public Guid ShiftId { get; set; }
        public Guid WorkLocationId { get; set; }

        [Required, EmailAddress]
        public string WorkEmail { get; set; }
        public string? WorkPhoneNumber { get; set; }

        [RegularExpression(@"^(?:[0-9]{1,3}\.){3}[0-9]{1,3}$", ErrorMessage = "Invalid IP Address")]
        public string? IPAddress { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; }
        public int ProbationPeriodInMonths { get; set; } = 6;
        public int NoticePeriodInMonths { get; set; } = 3;
        public bool IsConfirmed { get; set; }
        public DateTime? ReleivingDate { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
