using System;
using System.Collections.Generic;
using System.Linq;
using InsuranceCompany.API.Domain.Models;
using InsuranceCompany.API.Domain.Repositories;

namespace InsuranceCompany.API.Test.Services
{
    public class ClientRepositoryFake : IClientRepository
    {
        private readonly List<Client> _clients;

        public ClientRepositoryFake()
        {
            this._clients = new List<Client>()
            {
                new Client
                {
                     Id = new Guid("a0ece5db-cd14-4f21-812f-966633e7be86"),
                     Name = "Test 1",
                     Email = "test1@test.com",
                     Role = "admin"
                },
                new Client
                {
                     Id = new Guid("a3b8d425-2b60-4ad7-becc-bedf2ef860bd"),
                     Name = "Test 2",
                     Email = "test2@test.com",
                     Role = "user"
                },
                new Client
                {
                     Id = new Guid("44e44268-dce8-4902-b662-1b34d2c10b8e"),
                     Name = "Test 3",
                     Email = "test3@test.com",
                     Role = "admin"
                },
                new Client
                {
                     Id = new Guid("0178914c-548b-4a4c-b918-47d6a391530c"),
                     Name = "Test 4",
                     Email = "test4@test.com",
                     Role = "user"
                },
            };
        }

        public Client FindById(Guid id)
        {
            return this._clients.FirstOrDefault(x => x.Id == id);
        }

        public Client FindByName(string name)
        {
            return this._clients.FirstOrDefault(x => string.Compare(x.Name, name, true) == 0);
        }
    }
}
