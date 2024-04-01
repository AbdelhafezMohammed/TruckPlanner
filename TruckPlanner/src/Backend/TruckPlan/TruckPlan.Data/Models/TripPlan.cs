namespace TruckPlan.Data.Models
{
    public class TripPlan
    {
        public int Id { get; set; }
        public double TripStartLatitude { get; set; }
        public double TripStartLongitude { get; set; }
        public double TripEndLatitude { get; set; }
        public double TripEndLongitude { get; set; }
        public DateTime TripStartDate { get; set; }
        public DateTime TripEndDate { get; set; }
        public Driver Driver { get; set; }
        public int DriverId { get; set; }
    }
}
