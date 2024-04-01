using Microsoft.EntityFrameworkCore;
using TruckPlan.Data.Models;

namespace TruckPlan.Data
{
    public class TruckPlanContext : DbContext
    {
        public TruckPlanContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Driver> Drivers { get; set; }
        public DbSet<TripPlan> TripPlans { get; set; }
        public DbSet<Truck> Trucks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TripPlan>()
                 .HasOne(tripPlan => tripPlan.Driver)
                 .WithMany(driver => driver.TripPlans)
                 .HasForeignKey(tripPlan => tripPlan.DriverId);

            modelBuilder.Entity<Driver>().HasData(
             new Driver
             {
                 Id = 1,
                 Name = "Michael Lund",
                 BirthDate = new DateTime(1974, 03, 1),
                 DrivingLicenseNumber = 12345,
             },
             new Driver
             {
                 Id = 2,
                 Name = "Jeppe Wilson",
                 BirthDate = new DateTime(1990, 09, 25),
                 DrivingLicenseNumber = 6789,
             },
             new Driver
             {
                 Id = 3,
                 Name = "Sophia Garcia",
                 BirthDate = new DateTime(1984, 6, 1),
                 DrivingLicenseNumber = 76543,
             });
            modelBuilder.Entity<Truck>().HasData(
               new Truck
               {
                   Id = 1,
                   ModelName = "Volvo",
                   Vin = "ABC12345",
                   DriverId = 1
               },
               new Truck
               {
                   Id = 2,
                   ModelName = "Tesla",
                   Vin = "MMO12345",
                   DriverId = 2
               },
                new Truck
                {
                    Id = 3,
                    ModelName = "Scania",
                    Vin = "QWER12345",
                    DriverId = 3
                });
            modelBuilder.Entity<TripPlan>().HasData(
                new TripPlan
                {
                    Id = 1,
                    TripStartDate = new DateTime(2018, 2, 10),
                    TripEndDate = new DateTime(2018, 2, 10),
                    TripStartLatitude = 52.520008, //Berlin
                    TripStartLongitude = 13.404954, //Berlin
                    TripEndLatitude = 53.551086, //Hamburg
                    TripEndLongitude = 9.993682, //Hamburg
                    DriverId = 1
                },
                new TripPlan
                {
                    Id = 2,
                    TripStartDate = new DateTime(2020, 3, 13),
                    TripEndDate = new DateTime(2020, 9, 13),
                    TripStartLatitude = 55.676098, //Copenhagen
                    TripStartLongitude = 12.568337, //Copenhagen
                    TripEndLatitude = 55.396229, //Odense
                    TripEndLongitude = 10.390600, //Odense
                    DriverId = 2
                },
                new TripPlan
                {
                    Id = 3,
                    TripStartDate = new DateTime(2021, 9, 25),
                    TripEndDate = new DateTime(2021, 9, 26),
                    TripStartLatitude = 59.3251172, //Stockholm
                    TripStartLongitude = 18.0710935, //Stockholm
                    TripEndLatitude = 55.6052931, //Malmo
                    TripEndLongitude = 13.0001566, //Malmo
                    DriverId = 3
                },
                new TripPlan
                {
                    Id = 4,
                    TripStartDate = new DateTime(2018, 2, 15),
                    TripEndDate = new DateTime(2018, 2, 15),
                    TripStartLatitude = 50.1106444, //Frankfurt
                    TripStartLongitude = 8.6820917, //Frankfurt
                    TripEndLatitude = 48.7784485, //Stuttgart
                    TripEndLongitude = 9.1800132, //Stuttgart
                    DriverId = 3
                },
                new TripPlan
                {
                    Id = 5,
                    TripStartDate = new DateTime(2019, 2, 28),
                    TripEndDate = new DateTime(2019, 2, 28),
                    TripStartLatitude = 50.938361, //Cologne
                    TripStartLongitude = 6.959974, //Cologne
                    TripEndLatitude = 52.5170365, //Berlin
                    TripEndLongitude = 13.3888599, //Berlin
                    DriverId = 2
                });
        }
    }
}
