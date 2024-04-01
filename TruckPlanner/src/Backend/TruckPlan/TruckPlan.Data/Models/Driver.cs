namespace TruckPlan.Data.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int DrivingLicenseNumber { get; set; }
        public Truck Truck { get; set; }
        public List<TripPlan> TripPlans { get; set; }
    }
}
