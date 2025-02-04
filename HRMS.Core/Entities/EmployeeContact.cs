using System.ComponentModel.DataAnnotations;

namespace HRMS.Core.Entities
{
    public class EmployeeContact
    {
        [Key]
        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

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
}
