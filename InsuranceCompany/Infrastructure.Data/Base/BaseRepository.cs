using System.Net;

namespace InsuranceCompany.API.Infrastructure.Data
{
    public abstract class BaseRepository
    {
        protected readonly string _urlSourceData;
        public BaseRepository(string urlSourceData)
        {
            this._urlSourceData = urlSourceData;
        }

        protected string GetData()
        {
            using (var wc = new WebClient())
            {
                return wc.DownloadString(_urlSourceData);
            }
        }
    }
}
