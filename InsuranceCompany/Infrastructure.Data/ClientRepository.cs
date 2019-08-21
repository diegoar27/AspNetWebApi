using System;
using System.Linq;
using InsuranceCompany.API.Domain.Models;
using InsuranceCompany.API.Domain.Repositories;
using Newtonsoft.Json;

namespace InsuranceCompany.API.Infrastructure.Data
{
    public class ClientRepository : BaseRepository, IClientRepository
    {
        public ClientRepository()
            : base("http://www.mocky.io/v2/5808862710000087232b75ac")
        {
        }

        public Client FindById(Guid id)
        {
            return JsonConvert.DeserializeObject<ClientList>(this.GetData()).Clients.FirstOrDefault(x => x.Id == id);
        }

        public Client FindByName(string name)
        {
            return JsonConvert.DeserializeObject<ClientList>(this.GetData()).Clients.FirstOrDefault(x => string.Compare(x.Name, name, StringComparison.CurrentCultureIgnoreCase) == 0);
        }
    }
}
