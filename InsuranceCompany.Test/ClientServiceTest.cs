using InsuranceCompany.API.Domain.Services;
using InsuranceCompany.API.Services;
using InsuranceCompany.API.Test.FakeRepository;
using InsuranceCompany.API.Test.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace InsuranceCompany.Test
{
    [TestClass]
    public class ClientServiceTest
    {
        private IPolicyService PolicyService { get; set; } 
        private IClientService ClientService { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            this.ClientService = new ClientService(new ClientRepositoryFake(), new PolicyRepositoryFake());
        }

        [TestMethod]
        public void ClientService_GetById_Success()
        {
            var result = this.ClientService.GetById(new Guid("a0ece5db-cd14-4f21-812f-966633e7be86"));
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);
        }

        [TestMethod]
        public void ClientService_GetById_Fail()
        {
            var result = this.ClientService.GetById(new Guid("a0eae5db-cd14-4f21-812f-966633e7be86"));
            Assert.IsNotNull(result);
            Assert.IsFalse(result.Success);
        }

        [TestMethod]
        public void ClientService_GetById_NewGuid()
        {
            var result = this.ClientService.GetById(new Guid());
            Assert.IsNotNull(result);
            Assert.IsFalse(result.Success);
        }

        [TestMethod]
        public void ClientService_GetByName_Success()
        {
            var result = this.ClientService.GetByName("Test 1");
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Resource.Name == "Test 1");
        }

        [TestMethod]
        public void ClientService_GetByName_NameNotValid()
        {
            var result = this.ClientService.GetByName("Test 11");
            Assert.IsNotNull(result);
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Message == "Client not found.");
        }

        [TestMethod]
        public void ClientService_GetByPolicyNumber_Success()
        {
            var result = this.ClientService.GetByPolicyNumber("8a53d72ec80242ae849b11c6cf550a0d");
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Resource.Name == "Test 3");
        }

        [TestMethod]
        public void ClientService_GetByName_NumberNotValid()
        {
            var result = this.ClientService.GetByName("8a53d72ec80242ae849b11c6cf550a0a");
            Assert.IsNotNull(result);
            Assert.IsFalse(result.Success);
            Assert.IsTrue(result.Message == "Client not found.");
        }
    }
}
