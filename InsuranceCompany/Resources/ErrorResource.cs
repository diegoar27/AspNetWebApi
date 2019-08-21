namespace InsuranceCompany.API.Resources
{
    public class ErrorResource
    {
        public bool Success => false;
        public string Message { get; }
        
        public ErrorResource(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                this.Message = message;
            }
        }
    }
}
