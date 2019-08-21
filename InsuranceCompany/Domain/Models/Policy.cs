using System;
using System.Collections.Generic;

namespace InsuranceCompany.API.Domain.Models
{
    public class PolicyList
    {
        public IEnumerable<Policy> Policies { get; set; }
    }

    public class Policy
    {
        public Guid Id { get; set; }
        public decimal AmountInsured { get; set; }
        public string Email { get; set; }
        public DateTime InceptionDate { get; set; }
        public bool InstallmentPayment { get; set; }
        public Guid ClientId { get; set; }
    }
}
