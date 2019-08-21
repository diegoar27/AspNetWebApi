using InsuranceCompany.API.Services.Contracts;

namespace InsuranceCompany.API.Domain.Services
{
    public interface IPolicyService
    {
        PolicyContract GetByUserName(string userName);
    }
}
