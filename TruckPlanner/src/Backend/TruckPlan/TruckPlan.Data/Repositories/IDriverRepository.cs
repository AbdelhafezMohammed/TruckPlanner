using TruckPlan.Data.Models;

namespace TruckPlan.Data.Repositories
{
    public interface IDriverRepository
    {
        Task<List<Driver>> GetAsync();
        Task<Driver?> GetByIdAsync(int driverId);
    }
}
