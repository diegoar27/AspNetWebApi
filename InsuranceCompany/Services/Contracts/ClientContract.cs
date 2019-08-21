using InsuranceCompany.API.Domain.Models;

namespace InsuranceCompany.API.Services.Contracts
{
    public class ClientContract : BaseContract
    {
        public ClientContract(string message) : base(message)
        {
            this.Success = false;
        }

        public ClientContract(Client resource) : base(string.Empty)
        {
            this.Success = true;
            this.Resource = resource;
        }

        public Client Resource { get; set; }
    }
}
