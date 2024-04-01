namespace TruckPlan.Service.DTOs
{
    public class DriverDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int DrivingLicenseNumber { get; set; }
        public int Age { get; set; }
        public TruckDto Truck { get; set; }
        public List<TripPlanDto> TripPlans { get; set; }
    }
}
