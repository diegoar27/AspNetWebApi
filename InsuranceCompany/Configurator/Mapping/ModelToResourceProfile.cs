using AutoMapper;
using InsuranceCompany.API.Domain.Models;
using InsuranceCompany.API.Resources;

namespace InsuranceCompany.API.Configurator.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Client, ClientResource>();
            CreateMap<Policy, PolicyResource>();
        }
    }
}
