using System;
using InsuranceCompany.API.Services.Contracts;

namespace InsuranceCompany.API.Domain.Services
{
    public interface IClientService
    {
        ClientContract GetById(Guid id);
        ClientContract GetByName(string name);
        ClientContract GetByPolicyNumber(string policyNumber);
    }
}
