using TruckPlan.Service.Models;

namespace TruckPlan.Service.Integrations
{
    public interface IGoogleLocationServices
    {
        Task<GoogleGeocodeResponse?> GetCountryByCoordinates(double latitude, double longitude);
        Task<GoogleDistanceMatrixResponse?> CalculateDistance(double originLatitude,
            double originLongitude, double destinationLatitude, double destinationLongitude);
    }
}
