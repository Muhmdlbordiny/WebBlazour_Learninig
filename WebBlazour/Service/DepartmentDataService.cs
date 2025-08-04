using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using SharedLibrary.Model;

namespace WebBlazour.Service
{
    public class DepartmentDataService : IDepartmentDataService
    {
        private readonly HttpClient _httpClient;

        public DepartmentDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddDepartment(Department Dept)
        {
            var embSer = new StringContent(JsonSerializer.Serialize(Dept)
                                   , Encoding.UTF8, "application/json");

            var res = await _httpClient.PostAsync($"api/department", embSer);
            res.EnsureSuccessStatusCode();
        }

        public async Task DeleteDepartment(int departmentid)
        {
           var response = await _httpClient.DeleteAsync($"api/department/{departmentid}");

            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<Department>> GetAllDepartment()
        {

            return await JsonSerializer.DeserializeAsync<IEnumerable<Department>>
            (
                                       await _httpClient.GetStreamAsync("api/department"),
                                       new JsonSerializerOptions
                                       {
                                           PropertyNameCaseInsensitive = true
                                       }
                                      );
        }        

        public async Task<Department> GetDepartmentById(int DepartmentId)
        {
            return await _httpClient.GetFromJsonAsync<Department>($"api/department/{DepartmentId}");
        }

        public async Task UpdateDepartment(Department Dept)
        {
            Console.WriteLine($"Updating Department with ID: {Dept.Id}");

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Converters = { new JsonStringEnumConverter() }
            };
            var json = JsonSerializer.Serialize(Dept, options);
            Console.WriteLine(json);

            var embSer = new StringContent(json
                                   , Encoding.UTF8, "application/json");

            var res = await _httpClient.PutAsync($"api/department/{Dept.Id}", embSer);
            Console.WriteLine($"Response Status Code: {res.StatusCode}");
        }
    }
}
