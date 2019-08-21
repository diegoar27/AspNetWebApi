using System;

namespace InsuranceCompany.API.Helper
{
    public static class PolicyHelper
    {
        public static Guid FormatNumber(string number)
        {
            return new Guid(number);
        }
    }
}
