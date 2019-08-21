using System;
using System.Collections.Generic;
using System.Linq;
using InsuranceCompany.API.Domain.Models;
using InsuranceCompany.API.Domain.Repositories;
using InsuranceCompany.API.Helper;
using Newtonsoft.Json;

namespace InsuranceCompany.API.Infrastructure.Data
{
    public class PolicyRepository : BaseRepository, IPolicyRepository
    {
        public PolicyRepository() 
            : base("http://www.mocky.io/v2/580891a4100000e8242b75c5")
        {
        }

        public IEnumerable<Policy> FilterByClientId(Guid clientId)
        {
            return JsonConvert.DeserializeObject<PolicyList>(this.GetData()).Policies.Where(x => x.ClientId == clientId).ToList();
        }

        public Policy GetByNumber(string number)
        {
            return JsonConvert.DeserializeObject<PolicyList>(this.GetData()).Policies.FirstOrDefault(x => x.Id == PolicyHelper.FormatNumber(number));
        }
    }
}
