using HRMS.Application.Interfaces.Repositories;
using HRMS.Core.Entities;
using HRMS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly HRMSDbContext _context;

        public EmployeeRepository(HRMSDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            await using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // Step 1: Save Employee Header First (ID gets generated here)
                employee.Name = string.Join(" ", new[] { employee.FirstName, employee.MiddleName, employee.LastName }
                                        .Where(name => !string.IsNullOrWhiteSpace(name)));
                var createdEmployee = (await _context.Employees.AddAsync(employee)).Entity;
                await _context.SaveChangesAsync(); // Ensures ID is generated

                // Step 2: Create related models using generated EmployeeId
                var salary = new EmployeeSalary
                {
                    EmployeeId = createdEmployee.Id,
                    BasicSalary = 0,
                    HRA = 0,
                    OtherAllowances = 0
                };

                var contact = new EmployeeContact
                {
                    EmployeeId = createdEmployee.Id,
                    Address = string.Empty,
                    Email = string.Empty,
                    Facebook = string.Empty,
                    Instagram = string.Empty,
                    LinkedIn = string.Empty,
                    OtherSocialMedia = string.Empty,
                    PersonalEmail = string.Empty,
                    PersonalPhone = string.Empty,
                    Phone = string.Empty,
                    Skype = string.Empty,
                    Twitter = string.Empty,
                    WorkEmail = string.Empty,
                    WorkPhone = string.Empty
                };

                var defaultContactPerson = new EmployeeContactPerson
                {
                    EmployeeId = createdEmployee.Id,
                    WorkPhone = "N/A",
                    Relationship = "N/A",
                    WorkEmail = "N/A",
                    Phone = "N/A",
                    Address = "N/A",
                    Email = "N/A",
                    FirstName = "N/A",
                    LastName = "N/A",
                    Id = Guid.NewGuid(),
                };

                var defaultDocument = new EmployeeDocument
                {
                    EmployeeId = createdEmployee.Id,
                    DocumentType = "N/A",
                    DocumentName = "N/A",
                    DocumentNumber = "N/A",
                    DocumentPath = "N/A",
                    Id = Guid.NewGuid(),
                };

                // Step 3: Add related entities
                await _context.EmployeeSalaries.AddAsync(salary);
                await _context.EmployeeContacts.AddAsync(contact);
                await _context.EmployeeContactPersons.AddAsync(defaultContactPerson);
                await _context.EmployeeDocuments.AddAsync(defaultDocument);

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return createdEmployee; // Return the full employee object with ID
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> UpdateEmployeePersonalDetails(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            await using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var existingEmployee = await _context.Employees.FindAsync(employee.Id);
                if (existingEmployee == null)
                    return false;

                existingEmployee.FirstName = employee.FirstName;
                existingEmployee.MiddleName = employee.MiddleName;
                existingEmployee.LastName = employee.LastName;
                existingEmployee.DepartmentId = employee.DepartmentId;
                existingEmployee.DesignationId = employee.DesignationId;
                existingEmployee.DateOfBirth = employee.DateOfBirth;
                existingEmployee.DateOfJoining = employee.DateOfJoining;

                _context.Employees.Update(existingEmployee);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

    }
}
