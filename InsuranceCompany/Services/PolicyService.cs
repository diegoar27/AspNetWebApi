using System;
using System.Linq;
using InsuranceCompany.API.Domain.Repositories;
using InsuranceCompany.API.Domain.Services;
using InsuranceCompany.API.Services.Contracts;

namespace InsuranceCompany.API.Services
{
    public class PolicyService : IPolicyService
    {
        private IPolicyRepository PolicyRepository { get; set; }
        private IClientRepository ClientRepository { get; set; }
        public PolicyService(IPolicyRepository policyRepository, IClientRepository clientRepository)
        {
            this.PolicyRepository = policyRepository;
            this.ClientRepository = clientRepository;
        }

        public PolicyContract GetByUserName(string userName)
        {
            try
            {
                var client = this.ClientRepository.FindByName(userName);
                if (client == null)
                {
                    return new PolicyContract(Messages.ClientNotFound);
                }

                var policies = this.PolicyRepository.FilterByClientId(client.Id);
                if (!policies.Any())
                {
                    return new PolicyContract(string.Format(Messages.ClientWithouPolicies, userName));
                }

                return new PolicyContract(policies);
            }
            catch (Exception ex)
            {
                return new PolicyContract(ex.Message);
            }
        }
    }
}
