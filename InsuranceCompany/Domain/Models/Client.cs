using System;
using System.Collections.Generic;

namespace InsuranceCompany.API.Domain.Models
{
    public class ClientList
    {
        public IEnumerable<Client> Clients { get; set; }
    }

    public class Client
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
