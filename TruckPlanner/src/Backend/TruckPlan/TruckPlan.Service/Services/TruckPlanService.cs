using AutoMapper;
using TruckPlan.Data.Repositories;
using TruckPlan.Service.DTOs;
using TruckPlan.Service.Integrations;

namespace TruckPlan.Service.Services
{
    public class TruckPlanService : ITruckPlanService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly ITripPlanRepository _tripPlanRepository;
        private readonly IMapper _mapper;
        private readonly IGoogleLocationServices _googleLocationServices;

        public TruckPlanService(IDriverRepository driverRepository,
            ITripPlanRepository tripPlanRepository,
            IMapper mapper,
            IGoogleLocationServices googleLocationServices)
        {
            _driverRepository = driverRepository;
            _tripPlanRepository = tripPlanRepository;
            _mapper = mapper;
            _googleLocationServices = googleLocationServices;
        }

        public async Task<List<DriverDto>> GetDriversAsync()
        {
            var drivers = await _driverRepository.GetAsync();
            return _mapper.Map<List<DriverDto>>(drivers);
        }

        public async Task<DriverDto> GetDriverDetailsAsync(int driverId)
        {
            var drivers = await _driverRepository.GetByIdAsync(driverId);
            var driverDto = _mapper.Map<DriverDto>(drivers);

            for (int i = 0; i < driverDto.TripPlans.Count; i++)
            {
                var trip = driverDto.TripPlans[i];
                var tripStartResult = await GetCountryAndCityFromCoordinates(trip.TripStartLatitude, trip.TripStartLongitude);
                var tripEndResult = await GetCountryAndCityFromCoordinates(trip.TripEndLatitude, trip.TripEndLongitude);
                var tripDistance = await GetTripDistance(trip.TripStartLatitude, trip.TripStartLongitude, trip.TripEndLatitude, trip.TripEndLongitude);

                driverDto.TripPlans[i].TripStartCountry = tripStartResult.country;
                driverDto.TripPlans[i].TripStartCity = tripStartResult.city;
                driverDto.TripPlans[i].TripEndCountry = tripEndResult.country;
                driverDto.TripPlans[i].TripEndCity = tripEndResult.city;
                driverDto.TripPlans[i].DistanceKm = tripDistance;
            }

            return driverDto;
        }

        private async Task<(string? country, string? city)> GetCountryAndCityFromCoordinates(double latitude, double longitude)
        {
            var result = await _googleLocationServices.GetCountryByCoordinates(latitude, longitude);
            if (result is null)
            {
                return (null, null);
            }
            return (result.results
            .SelectMany(result => result.address_components)
            .FirstOrDefault(addressComponent => addressComponent.types.Contains("country"))?
            .long_name,
            result.results
            .SelectMany(result => result.address_components)
            .FirstOrDefault(addressComponent => addressComponent.types.Contains("locality"))?
            .long_name);
        }

        private async Task<string?> GetTripDistance(double tripStartLatitude,
            double tripStartLongitude,
            double tripEndLatitude,
            double tripEndLongitude)
        {
            var result = await _googleLocationServices.CalculateDistance(tripStartLatitude,
                tripStartLongitude,
                tripEndLatitude,
                tripEndLongitude);
            if (result is null)
            {
                return null;
            }

            return result.rows[0].elements[0].distance?.text;
        }

        public static int CalculateAge(DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            return age;
        }

        public (DateTime minBirthdate, DateTime maxBirthdate) GetBirthDateRangeForAge(int age)
        {
            DateTime today = DateTime.Today;
            DateTime minBirthdate = today.AddYears(-age).AddMonths(-11).AddDays(-30);
            DateTime maxBirthdate = today.AddYears(-age);

            return (minBirthdate, maxBirthdate);
        }

        public async Task<double> GetTripPlansByDateAndDriverAgeAsync(int month,
            int year,
            int age,
            string country)
        {
            double totalkilometers = 0;
            DateTime tripStartDate = new DateTime(year, month, 1);
            DateTime tripEndDate = tripStartDate.AddMonths(1).AddDays(-1);
            var birthdates = GetBirthDateRangeForAge(age);

            var trips = await _tripPlanRepository.GetTripPlansByDateAndDriverAgeAsync(tripStartDate,
                tripEndDate,
               birthdates.minBirthdate,
               birthdates.maxBirthdate);

            if (trips is not null && trips.Any())
            {
                var tripsDto = _mapper.Map<List<TripPlanDto>>(trips);
                foreach (var trip in tripsDto)
                {
                    var tripStartResult = await GetCountryAndCityFromCoordinates(trip.TripStartLatitude, trip.TripStartLongitude);
                    var tripEndResult = await GetCountryAndCityFromCoordinates(trip.TripEndLatitude, trip.TripEndLongitude);

                    if (tripStartResult.country?.ToLower() == country.ToLower() && tripEndResult.country?.ToLower() == country.ToLower())
                    {
                        var distance = await GetTripDistance(trip.TripStartLatitude,
                           trip.TripStartLongitude,
                           trip.TripEndLatitude,
                           trip.TripEndLongitude);
                        totalkilometers += double.Parse(distance.Split(' ')[0]);
                    }

                }
            }
            return totalkilometers;
        }
    }
}
