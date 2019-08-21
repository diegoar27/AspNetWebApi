using InsuranceCompany.API.Domain.Repositories;
using InsuranceCompany.API.Domain.Services;
using InsuranceCompany.API.Services.Contracts;
using System;

namespace InsuranceCompany.API.Services
{
    public class ClientService : IClientService
    {
        private IClientRepository ClientRepository { get; set; }
        private IPolicyRepository PolicyRepository { get; set; }
        public ClientService(IClientRepository clientRepository, IPolicyRepository policyRepository)
        {
            this.ClientRepository = clientRepository;
            this.PolicyRepository = policyRepository;
        }

        public ClientContract GetById(Guid id)
        {
            try
            {
                var client = this.ClientRepository.FindById(id);
                if (client == null)
                {
                    return new ClientContract(Messages.ClientNotFound);
                }

                return new ClientContract(client);
            }
            catch (Exception ex)
            {
                return new ClientContract(ex.Message);
            }
        }

        public ClientContract GetByName(string name)
        {
            try
            {
                var client = this.ClientRepository.FindByName(name);
                if (client == null)
                {
                    return new ClientContract(Messages.ClientNotFound);
                }

                return new ClientContract(client);
            }
            catch (Exception ex)
            {
                return new ClientContract(ex.Message);
            }
        }

        public ClientContract GetByPolicyNumber(string policyNumber)
        {
            try
            {
                var policy = this.PolicyRepository.GetByNumber(policyNumber);
                if (policy == null)
                {
                    return new ClientContract(Messages.PolicyNotFound);
                }

                var client = this.ClientRepository.FindById(policy.ClientId);
                if (client == null)
                {
                    return new ClientContract(Messages.ClientNotFound);
                }

                return new ClientContract(client);
            }
            catch (Exception ex)
            {
                return new ClientContract(ex.Message);
            }
        }
    }
}
