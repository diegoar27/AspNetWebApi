using System;
using System.Collections.Generic;
using InsuranceCompany.API.Domain.Models;

namespace InsuranceCompany.API.Domain.Repositories
{
    public interface IPolicyRepository
    {
        Policy GetByNumber(string number);
        IEnumerable<Policy> FilterByClientId(Guid clientId);
    }
}
