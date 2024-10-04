using AutoMapper;
using Landing.DAL.Models;
using Landing.PL.Areas.Dashbord.ViewModels;

namespace Landing.PL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Service, ServiceFormVM>().ReverseMap();
            CreateMap<ServiceDetails, Service>().ReverseMap();
            CreateMap<Service, ServiceVM>().ReverseMap();
        }
    }
}
