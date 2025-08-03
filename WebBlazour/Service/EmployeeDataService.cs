using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Options;
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
            //return await JsonSerializer.DeserializeAsync<IEnumerable<Employee>>
            //              (
            //               await _httpClient.GetStreamAsync("api/employee"),
            //               new JsonSerializerOptions
            //               {
            //                   PropertyNameCaseInsensitive = true
            //               }
            //              );
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            options.Converters.Add(new JsonStringEnumConverter());

            return await _httpClient.GetFromJsonAsync<IEnumerable<Employee>>("api/employee", options);
        }
        public async Task<Employee> GetEmployeeById(int employeeid)
        {
           var  options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            options.Converters.Add(new JsonStringEnumConverter());

            return await JsonSerializer.DeserializeAsync<Employee>
                                                  (
                                                   await _httpClient.GetStreamAsync($"api/employee/{employeeid}"),
                                                  options );

        }

        public async Task<Employee> GetEmployeeDetails(int employeeid)
        {
           var  options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            options.Converters.Add(new JsonStringEnumConverter());

            return await JsonSerializer.DeserializeAsync<Employee>
                                      (
                                       await _httpClient.GetStreamAsync($"api/employee/{employeeid}"),
                                        options
                                      );
        }
        public async Task AddEmployee(Employee employee)
        {
            var embSer = new StringContent(JsonSerializer.Serialize(employee)
                        , Encoding.UTF8, "application/json");

          var res=  await _httpClient.PostAsync($"api/employee", embSer);
            res.EnsureSuccessStatusCode();

        }

        public async Task DeleteEmployee(int employeeid)
        {
            var response = await _httpClient.DeleteAsync($"api/employee/{employeeid}");

            response.EnsureSuccessStatusCode();
        }

       

        

        public async Task UpdateEmployee(Employee employee)
        {
            Console.WriteLine($"Updating employee with ID: {employee.EmployeeId}");

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Converters = { new JsonStringEnumConverter() }
            };
            var json = JsonSerializer.Serialize(employee, options);
            Console.WriteLine(json);

            var embSer = new StringContent(json
                                   , Encoding.UTF8, "application/json");

          var res =  await _httpClient.PutAsync($"api/employee/{employee.EmployeeId}", embSer);
            Console.WriteLine($"Response Status Code: {res.StatusCode}");

            res.EnsureSuccessStatusCode();
        }
    }
}
