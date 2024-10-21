using AutoMapper;
using Web_api_1.Domain.DTOS;
using Web_api_1.Domain.Model.EmployeeAggregate;

namespace Web_api_1.Application.Mapping
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping() 
        {
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(dest =>dest.NameEmployee, m => m.MapFrom(orig => orig.name));        
        }

    }
}
