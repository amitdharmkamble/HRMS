using HRMS.Core.Entities;

namespace HRMS.Application.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync(bool includeDeleted = false);
        Task<T?> GetByIdAsync(Guid id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task SoftDeleteAsync(Guid id);
        Task RestoreAsync(Guid id);
        Task<string> GetNameByIdAsync(Guid id);
    }
}
