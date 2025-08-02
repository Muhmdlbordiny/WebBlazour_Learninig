using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebBlazour.Service;

namespace WebBlazour
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
            builder.Services.AddHttpClient<IEmployeeDataService, EmployeeDataService>(
                client => client.BaseAddress = new Uri("https://localhost:44347/")
                );
            builder.Services.AddHttpClient<ICountryDataService, CountryDataService>(
               client => client.BaseAddress = new Uri("https://localhost:44347/")
               );
            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44347/api/employee") });

            await builder.Build().RunAsync();
        }
    }
}
