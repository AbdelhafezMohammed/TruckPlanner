using TruckPlan.Data.Models;

namespace TruckPlan.Data.Repositories
{
    public interface ITripPlanRepository
    {
        Task<List<TripPlan>?> GetTripPlansByDateAndDriverAgeAsync(DateTime tripStart,
            DateTime tripEnd,
            DateTime driverMinAge,
            DateTime driverMaxAge);
    }
}
