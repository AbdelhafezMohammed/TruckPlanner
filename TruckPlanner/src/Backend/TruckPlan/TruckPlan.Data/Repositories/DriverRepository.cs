using Microsoft.EntityFrameworkCore;
using TruckPlan.Data.Models;

namespace TruckPlan.Data.Repositories
{
    public class DriverRepository : IDriverRepository
    {
        private readonly TruckPlanContext _context;

        public DriverRepository(TruckPlanContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Driver>> GetAsync()
        {
            return await _context.Drivers.ToListAsync();
        }

        public async Task<Driver?> GetByIdAsync(int driverId)
        {
            return await _context.Drivers
                .Include(x => x.Truck)
                .Include(x => x.TripPlans)
                .FirstOrDefaultAsync(x => x.Id == driverId);
        }
    }
}
