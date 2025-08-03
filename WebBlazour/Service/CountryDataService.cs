using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using SharedLibrary.Model;

namespace WebBlazour.Service
{
    public class CountryDataService : ICountryDataService
    {
        private readonly HttpClient _httpClient;
        public CountryDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Country>> GetAllCountry()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Country>>
            (
                                       await _httpClient.GetStreamAsync("api/country"),
                                       new JsonSerializerOptions
                                       {
                                           PropertyNameCaseInsensitive = true
                                       }
                                      );
        }

        public async Task<Country> GetCountryById(int countryid)
        {
            return await _httpClient.GetFromJsonAsync<Country>($"api/country/{countryid}");
        }
    }
}
