namespace InsuranceCompany.API.Services.Contracts
{
    public class BaseContract
    {
        public BaseContract(string message)
        {
            this.Message = message;
        }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
