using System;
using System.Collections.Generic;
using InsuranceCompany.API.Domain.Models;

namespace InsuranceCompany.API.Domain.Repositories
{
    public interface IClientRepository
    {
        Client FindById(Guid id);
        Client FindByName(string name);
    }
}
