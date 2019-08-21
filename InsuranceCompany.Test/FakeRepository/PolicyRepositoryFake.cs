using System;
using System.Collections.Generic;
using System.Linq;
using InsuranceCompany.API.Domain.Models;
using InsuranceCompany.API.Domain.Repositories;
using InsuranceCompany.API.Helper;

namespace InsuranceCompany.API.Test.FakeRepository
{
    public class PolicyRepositoryFake : IPolicyRepository
    {
        private readonly List<Client> _clients;
        private readonly List<Policy> _policies;

        public PolicyRepositoryFake()
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
            this._policies = new List<Policy>()
            {
                new Policy
                {
                     Id = new Guid("35a0d2f7-37cd-4c21-8dac-fe91b29bd22b"),
                     AmountInsured = 3878.41m,
                     Email = "test1@test.com",
                     InceptionDate = new DateTime(2015,02,20),
                     InstallmentPayment = true,
                     ClientId = new Guid("a0ece5db-cd14-4f21-812f-966633e7be86"),
                },
                new Policy
                {
                     Id = new Guid("1c6180b9-78b4-464d-b488-1efe9cdf84b1"),
                     AmountInsured = 3878.41m,
                     Email = "test2@test.com",
                     InceptionDate = new DateTime(2015,01,20),
                     InstallmentPayment = true,
                     ClientId = new Guid("a3b8d425-2b60-4ad7-becc-bedf2ef860bd"),
                },
                new Policy
                {
                     Id = new Guid("3e00473f-3cbe-42ff-81a7-1d85c88e65ff"),
                     AmountInsured = 3878.41m,
                     Email = "test3@test.com",
                     InceptionDate = new DateTime(2015,03,20),
                     InstallmentPayment = true,
                     ClientId = new Guid("44e44268-dce8-4902-b662-1b34d2c10b8e"),
                },
                new Policy
                {
                     Id = new Guid("8a53d72e-c802-42ae-849b-11c6cf550a0d"),
                     AmountInsured = 3878.41m,
                     Email = "test4@test.com",
                     InceptionDate = new DateTime(2015,05,20),
                     InstallmentPayment = true,
                     ClientId = new Guid("44e44268-dce8-4902-b662-1b34d2c10b8e"),
                },
            };
        }

        public IEnumerable<Policy> FilterByClientId(Guid clientId)
        {
            return this._policies.Where(x => x.ClientId == clientId).ToList();
        }

        public Policy GetByNumber(string number)
        {
            return this._policies.FirstOrDefault(x => x.Id == PolicyHelper.FormatNumber(number));
        }
    }
}
;