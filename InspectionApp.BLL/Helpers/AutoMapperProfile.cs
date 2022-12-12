using AutoMapper;
using InspectionApp.BLL.DTOs;
using InspectionApp.DAL.Entities;

namespace InspectionApp.BLL.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Inspection, InspectionDto>().ReverseMap();
            CreateMap<InspectionType, InspectionTypeDto>().ReverseMap();
            CreateMap<Status, StatusDto>().ReverseMap();
            CreateMap<Inspector, InspectorDto>().ReverseMap();

        }
    }
}