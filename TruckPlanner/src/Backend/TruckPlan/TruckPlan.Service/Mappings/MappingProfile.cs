using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckPlan.Data.Models;
using TruckPlan.Service.DTOs;
using TruckPlan.Service.Services;

namespace TruckPlan.Service.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Driver, DriverDto>()
            .ForMember(dest => dest.Age, opt => opt.MapFrom(src => TruckPlanService.CalculateAge(src.BirthDate)));

            CreateMap<Truck, TruckDto>()
             .ForMember(dest => dest.Vin, opt => opt.MapFrom(src => src.Vin))
             .ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.ModelName));


            CreateMap<TripPlan, TripPlanDto>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.TripStartLatitude, opt => opt.MapFrom(src => src.TripStartLatitude))
              .ForMember(dest => dest.TripStartLongitude, opt => opt.MapFrom(src => src.TripStartLongitude))
              .ForMember(dest => dest.TripEndLatitude, opt => opt.MapFrom(src => src.TripEndLatitude))
              .ForMember(dest => dest.TripEndLongitude, opt => opt.MapFrom(src => src.TripEndLongitude))
              .ForMember(dest => dest.TripStartDate, opt => opt.MapFrom(src => src.TripStartDate))
              .ForMember(dest => dest.TripEndDate, opt => opt.MapFrom(src => src.TripEndDate));
        }

    }
}
