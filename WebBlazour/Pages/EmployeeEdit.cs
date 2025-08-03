using System.Text.Json;
using Microsoft.AspNetCore.Components;
using SharedLibrary.Model;
using WebBlazour.Service;

namespace WebBlazour.Pages
{
    public partial class EmployeeEdit
    {
        [Parameter]
        public int EmployeeId { get; set; }
        public Employee CurEmp = new Employee();
        protected bool Saved;
        public string Myclass { get; set; }
        protected string Message = string.Empty;
        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public ICountryDataService CountryDataService { get; set; }
        public IEnumerable <Country> MyCountry { get; set; }
        private bool IsDataLoaded = false;

        //ist<Employee> Employees;
        //ist<Country> Countries;
        protected async override Task OnInitializedAsync()
        {
            CurEmp = await EmployeeDataService.GetEmployeeById(EmployeeId);
            MyCountry = await CountryDataService.GetAllCountry();
            if (CurEmp == null)
            {
                CurEmp = new Employee { CountryId=1 , BirthDate = DateTime.Now,JoinedDate = DateTime.Now};
            }
            IsDataLoaded = true;
        }
        protected async void HandlevaildSubmit()
        {
            Saved = false;
            if (CurEmp.EmployeeId == 0)
            {
                await EmployeeDataService.AddEmployee(CurEmp);    
            }
            else
            {
                //var editEmp = Employees.FirstOrDefault(e => e.EmployeeId == EmployeeId);
                //if (editEmp != null)
                //{
                //    editEmp.FirstName = CurEmp.FirstName;
                //    editEmp.LastName = CurEmp.LastName;
                //    editEmp.MaritalStatus = CurEmp.MaritalStatus;
                //}
               await EmployeeDataService.UpdateEmployee(CurEmp);
                Myclass = "alert alert-success";
                Message = "Employee Updated Successfully";
                Saved = true;
                Console.WriteLine(JsonSerializer.Serialize(CurEmp));
                NavigationManager.NavigateTo("/employeeoverview");


            }
        }
        protected void HandleInvaildSubmit()
        {
            Myclass = "alert alert-danger";
            Message = " Please  Check Vaildation fill all required fields correctly. plz try Again ";

        }
    }
}
