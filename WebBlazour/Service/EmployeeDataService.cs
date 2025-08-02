using System.Text;
using System.Text.Json;
using SharedLibrary.Model;

namespace WebBlazour.Service
{
    public class EmployeeDataService : IEmployeeDataService
    {
        private readonly HttpClient _httpClient;
        public EmployeeDataService( HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Employee>>
                           (
                            await _httpClient.GetStreamAsync("api/employee"),
                            new JsonSerializerOptions
                            {
                                PropertyNameCaseInsensitive = true
                            }
                           );
        }
        public async Task<Employee> GetEmployeeById(int employeeid)
        {
            return await JsonSerializer.DeserializeAsync<Employee>
                                                  (
                                                   await _httpClient.GetStreamAsync($"api/employee/{employeeid}"),
                                                   new JsonSerializerOptions
                                                   {
                                                       PropertyNameCaseInsensitive = true
                                                   }
                                                  );

        }

        public async Task<Employee> GetEmployeeDetails(int employeeid)
        {
            return await JsonSerializer.DeserializeAsync<Employee>
                                      (
                                       await _httpClient.GetStreamAsync($"api/employee/{employeeid}"),
                                       new JsonSerializerOptions
                                       {
                                           PropertyNameCaseInsensitive = true
                                       }
                                      );
        }
        public async Task AddEmployee(Employee employee)
        {
            var embSer = new StringContent(JsonSerializer.Serialize(employee)
                        , Encoding.UTF8, "application/json");

            await _httpClient.PostAsync($"api/employee", embSer);
                                                   
                                                  
        }

        public Task DeleteEmployee(int employeeid)
        {
            throw new NotImplementedException();
        }

       

        

        public async Task UpdateEmployee(Employee employee)
        {
            var embSer = new StringContent(JsonSerializer.Serialize(employee)
                                   , Encoding.UTF8, "application/json");

            await _httpClient.PutAsync($"api/employee/{employee.EmployeeId}", embSer);
        }
    }
}
