using HRMS.Application.Interfaces;
using HRMS.Application.Interfaces.Repositories;
using HRMS.Core.Entities;

namespace HRMS.Application.Services
{
    public class ShiftService : BaseService<Shift>, IShiftService
    {
        public ShiftService(IShiftRepository repository) : base(repository)
        { }
    }
}
