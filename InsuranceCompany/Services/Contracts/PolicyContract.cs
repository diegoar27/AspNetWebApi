using InsuranceCompany.API.Domain.Models;
using System.Collections.Generic;

namespace InsuranceCompany.API.Services.Contracts
{
    public class PolicyContract : BaseContract
    {
        public PolicyContract(string message) : base(message)
        {
            this.Success = false;
        }

        public PolicyContract(IEnumerable<Policy> resoruce) : base(string.Empty)
        {
            this.Success = true;
            this.Resource = resoruce;
        }

        public IEnumerable<Policy> Resource { get; set; }
    }
}
