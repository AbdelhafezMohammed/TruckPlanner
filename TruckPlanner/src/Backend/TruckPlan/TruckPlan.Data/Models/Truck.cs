namespace TruckPlan.Data.Models
{
    public class Truck
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public string Vin { get; set; }
        public Driver Driver { get; set; }
        public int DriverId { get; set; }
    }
}
