using SharedLibrary.Model;

namespace WebBlazour.Service
{
    public class CountryDataService : ICountryDataService
    {
        public Task<IEnumerable<Country>> GetAllCountry()
        {
            throw new NotImplementedException();
        }

        public Task<Country> GetCountryById(int countryid)
        {
            throw new NotImplementedException();
        }
    }
}
