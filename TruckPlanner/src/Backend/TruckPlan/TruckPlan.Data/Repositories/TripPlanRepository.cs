using Microsoft.EntityFrameworkCore;
using TruckPlan.Data.Models;

namespace TruckPlan.Data.Repositories
{
    public class TripPlanRepository : ITripPlanRepository
    {
        private readonly TruckPlanContext _context;

        public TripPlanRepository(TruckPlanContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<List<TripPlan>>? GetTripPlansByDateAndDriverAgeAsync(DateTime tripStart,
            DateTime tripEnd,
            DateTime driverMinAge,
            DateTime driverMaxAge)
        {
            return _context.TripPlans
                        .Where(trip => trip.TripStartDate >= tripStart &&
                        trip.TripStartDate < tripEnd &&
                        trip.Driver.BirthDate >= driverMinAge &&
                          trip.Driver.BirthDate <= driverMaxAge).ToListAsync();
        }
    }
}
