﻿using System;

namespace InsuranceCompany.API.Resources
{
    public class PolicyResource
    {
        public Guid Id { get; set; }
        public decimal AmountInsured { get; set; }
        public string Email { get; set; }
        public DateTime InceptionDate { get; set; }
        public bool InstallmentPayment { get; set; }
        public Guid ClientId { get; set; }
    }
}
