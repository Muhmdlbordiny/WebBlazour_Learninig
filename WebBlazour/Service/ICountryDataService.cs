using SharedLibrary.Model;

namespace WebBlazour.Service
{
    public interface ICountryDataService
    {
        Task<IEnumerable<Country>> GetAllCountry();
        Task<Country> GetCountryById(int countryid);

    }
}
