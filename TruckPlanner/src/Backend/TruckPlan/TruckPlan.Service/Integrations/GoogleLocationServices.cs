using Newtonsoft.Json;
using TruckPlan.Service.Models;

namespace TruckPlan.Service.Integrations
{
    public class GoogleLocationServices : IGoogleLocationServices
    {
        private const string ApiBaseUri = "https://maps.googleapis.com/maps/api";
        private const string ApiKey = "";
        private readonly HttpClient _httpClient;
        public GoogleLocationServices(
            IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("GoogleApiClient");
        }

        public async Task<GoogleGeocodeResponse?> GetCountryByCoordinates(double latitude, double longitude)
        {
            GoogleGeocodeResponse? googleGeocodeResponse = null;
            var response = await _httpClient.GetAsync($"{ApiBaseUri}/geocode/json?latlng={latitude},{longitude}&key={ApiKey}");
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                googleGeocodeResponse = JsonConvert.DeserializeObject<GoogleGeocodeResponse>(responseContent);
            }
            else if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
            return googleGeocodeResponse;
        }

        public async Task<GoogleDistanceMatrixResponse?> CalculateDistance(double originLatitude,
            double originLongitude, double destinationLatitude, double destinationLongitude)
        {
            GoogleDistanceMatrixResponse? googleDistanceMatrixResponse = null;
            var response = await _httpClient.GetAsync($"{ApiBaseUri}/distancematrix/json?origins={originLatitude},{originLongitude}&destinations={destinationLatitude},{destinationLongitude}&key={ApiKey}");
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                googleDistanceMatrixResponse = JsonConvert.DeserializeObject<GoogleDistanceMatrixResponse>(responseContent);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
            return googleDistanceMatrixResponse;
        }

    }
}
