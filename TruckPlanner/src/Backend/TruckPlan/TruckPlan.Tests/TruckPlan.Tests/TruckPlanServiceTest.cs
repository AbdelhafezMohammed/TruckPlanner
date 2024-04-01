using AutoMapper;
using Moq;
using TruckPlan.Data.Models;
using TruckPlan.Data.Repositories;
using TruckPlan.Service.DTOs;
using TruckPlan.Service.Integrations;
using TruckPlan.Service.Models;
using TruckPlan.Service.Services;

namespace TruckPlan.Tests
{
    [TestClass]
    public class TruckPlanServiceTest
    {
        private Mock<IDriverRepository> _driverRepository;
        private Mock<ITripPlanRepository> _tripPlanRepository;
        private Mock<IMapper> _mapper;
        private Mock<IGoogleLocationServices> _googleLocationServices;

        [TestInitialize]
        public void Setup()
        {
            _driverRepository = new Mock<IDriverRepository>();
            _tripPlanRepository = new Mock<ITripPlanRepository>();
            _mapper = new Mock<IMapper>();
            _googleLocationServices = new Mock<IGoogleLocationServices>();
        }

        [TestMethod]
        public async Task GetTripPlansByDateAndDriverAgeAsync_ReturnsTotalKilometers()
        {
            // Arrange
            var month = 2; // April
            var year = 2018;
            var age = 50;
            var country = "Germany";

            var trips = new List<TripPlan>()
            {
                new TripPlan
                {
                    DriverId =1,
                    
                }
            };

            var tripsDto = new List<TripPlanDto>()
            {

            };

            _tripPlanRepository.Setup(r => r.GetTripPlansByDateAndDriverAgeAsync(It.IsAny<DateTime>(),
                It.IsAny<DateTime>(),
                It.IsAny<DateTime>(),
                It.IsAny<DateTime>()))
                .ReturnsAsync(trips);

            _mapper.Setup(m => m.Map<List<TripPlanDto>>(trips)).Returns(tripsDto);

            _googleLocationServices.Setup(s => s.GetCountryByCoordinates(123.123, 456.456))
                .ReturnsAsync(new GoogleGeocodeResponse
                {
                    results = new List<Result>
                    {

                        new Result
                        {
                            address_components = new List<AddressComponent>
                            {
                                new AddressComponent
                                {
                                    long_name = "Germany",
                                    types = ["locality"]
                                }
                            }
                        }

                    }
                });

            var service = new TruckPlanService(_driverRepository.Object,
                _tripPlanRepository.Object,
                _mapper.Object,
                _googleLocationServices.Object);

            // Act
            var result = await service.GetTripPlansByDateAndDriverAgeAsync(month, year, age, country);

            // Assert
            Assert.AreEqual(3939.4, result); // Assuming the distance calculated is 3939
        }
    }
}