using Microsoft.AspNetCore.Mvc;
using TruckPlan.Service.DTOs;
using TruckPlan.Service.Services;

namespace TruckPlan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        [HttpGet("drivers", Name = "GetDrivers")] 
        public async Task<IEnumerable<DriverDto>> Get([FromServices] ITruckPlanService truckPlanService)
        {
            return await truckPlanService.GetDriversAsync();
        }

        [HttpGet("drivers/{driverId}", Name = "GetDriverDetails")]
        public async Task<DriverDto> Get([FromServices] ITruckPlanService truckPlanService,int driverId)
        {
            return await truckPlanService.GetDriverDetailsAsync(driverId);
        }

        [HttpGet("drivers/{month}/{year}/{age}/{country}", Name = "GetTripsByDateAndCountryAndDriverAge")]
        public async Task<double> Get([FromServices] ITruckPlanService truckPlanService,
            int month = 2,
            int year = 2018,
            int age = 50,
            string country = "Germany")
        {
            return await truckPlanService.GetTripPlansByDateAndDriverAgeAsync(month,
                year,
                age,
                country);
        }
    }
}
