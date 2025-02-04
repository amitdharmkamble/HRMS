namespace HRMS.Core.Entities
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public Guid DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public Guid DesignationId { get; set; }
        public virtual Designation Designation { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string MaritalStatus { get; set; } = string.Empty;

        public virtual EmployeeContact Contact { get; set; }
        public virtual EmployeeSalary Salary { get; set; }

        public virtual ICollection<EmployeeDocument> Documents { get; set; } = new List<EmployeeDocument>();

        public virtual ICollection<EmployeeContactPerson> ContactPersons { get; set; } = new List<EmployeeContactPerson>();
    }

}
