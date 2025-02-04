using System.ComponentModel.DataAnnotations;

namespace HRMS.Core.Entities
{
    public class EmployeeSalary
    {
        [Key]
        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public decimal BasicSalary { get; set; }
        public decimal HRA { get; set; }
        public decimal OtherAllowances { get; set; }
    }
}
