using TruckPlan.Service.DTOs;

namespace TruckPlan.Service.Services
{
    public interface ITruckPlanService
    {
        Task<List<DriverDto>> GetDriversAsync();
        Task<DriverDto> GetDriverDetailsAsync(int driverId);
        Task<double> GetTripPlansByDateAndDriverAgeAsync(
            int month,
            int year,
            int age,
            string country);
    }
}
