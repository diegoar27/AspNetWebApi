using InsuranceCompany.API.Domain.Services;
using InsuranceCompany.API.Services;
using InsuranceCompany.API.Test.FakeRepository;
using InsuranceCompany.API.Test.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace InsuranceCompany.Test
{
    [TestClass]
    public class PolicyServiceTest
    {
        private IPolicyService PolicyService { get; set; } 
        private IClientService ClientService { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            this.PolicyService = new PolicyService(new PolicyRepositoryFake(), new ClientRepositoryFake());
        }

        [TestMethod]
        public void PolicyService_GetByUserName_Success()
        {
            var result = this.PolicyService.GetByUserName("Test 3");
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.Resource.Count() == 2);
        }

        [TestMethod]
        public void ClientService_GetByUserName_Fail()
        {
            var result = this.PolicyService.GetByUserName("Test not valid");
            Assert.IsNotNull(result);
            Assert.IsFalse(result.Success);
        }
    }
}
