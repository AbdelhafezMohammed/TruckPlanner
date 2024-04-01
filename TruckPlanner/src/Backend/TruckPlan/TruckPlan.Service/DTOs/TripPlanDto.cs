namespace TruckPlan.Service.DTOs
{
    public class TripPlanDto
    {
        public int Id { get; set; }
        public double TripStartLatitude { get; set; }
        public double TripStartLongitude { get; set; }
        public double TripEndLatitude { get; set; }
        public double TripEndLongitude { get; set; }
        public DateTime TripStartDate { get; set; }
        public DateTime TripEndDate { get; set; }
        public string? TripStartCountry { get; set; }
        public string? TripStartCity { get; set; }
        public string? TripEndCountry { get; set; }
        public string? TripEndCity { get; set; }
        public string? DistanceKm { get; set; }
    }
}
