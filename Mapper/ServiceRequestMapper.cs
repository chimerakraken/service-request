using service_request.Dtos;
using service_request.Models;
using AutoMapper;

namespace service_request.Mapper
{
    public class ServiceRequestMapper : Profile
    {
        public ServiceRequestMapper()
        {
            CreateMap<UpdateServiceRequestDto, ServiceRequest>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
