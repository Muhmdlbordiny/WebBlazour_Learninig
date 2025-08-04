using Microsoft.AspNetCore.Components;
using SharedLibrary.Model;
using WebBlazour.Service;

namespace WebBlazour.Pages
{
    public partial class EmployeeDetails
    {
        [Parameter]
        public int EmployeeId { get; set; }
        public Employee CurEmp { get; set; }
        //List<Employee> Employees;
        //List<Country> Countries;
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }
        [Inject]
        public ICountryDataService countryDataService { get; set; }
        [Inject]
        public IDepartmentDataService DepartmentDataService { get; set; }
        public Department MyDepartment { get; set; }
        public Country MyCountry { get; set; }
        protected bool IsDataLoaded = false;
        protected override async Task OnInitializedAsync()
        {
            //    Employees = new List<Employee>
            //{
            //    new Employee { EmployeeId = 1,PhoneNumber="01276738534",ExitDate=null,BirthDate=new DateTime(1999,2,8),JoinedDate=new DateTime(2008,7,13),Gender = Gender.Male,MaritalStatus=MaritalStatus.Single ,Email="mohamed@gmail.com", FirstName = "mohamed ",LastName="ashraf", CountryId = 1 },
            //    new Employee { EmployeeId = 2,PhoneNumber="01276738534",ExitDate=null,BirthDate=new DateTime(1993,3,21),JoinedDate=new DateTime(2008,7,10),Gender = Gender.Male,MaritalStatus=MaritalStatus.Married ,Email="ahmed@gmail.com", FirstName = "ahmed ",LastName="ashraf", CountryId = 2 },
            //    new Employee { EmployeeId = 3,PhoneNumber="01276738534",ExitDate=null,BirthDate=new DateTime(2001,2,5),JoinedDate=new DateTime(2009,8,15),Gender = Gender.Female,MaritalStatus=MaritalStatus.Single ,Email="aya@gmail.com", FirstName = "aya ",LastName="halim", CountryId = 1 }
            //};
            //    Countries = new List<Country>
            //{
            //    new Country { CountryId = 1, Name = "Egypt" },
            //    new Country { CountryId = 2, Name = "USA" },
            //    new Country { CountryId = 3, Name = "UK" }
            //};
            //    CurEmp = Employees.FirstOrDefault(e => e.EmployeeId == EmployeeId);
            //    return base.OnInitializedAsync();
            CurEmp = await EmployeeDataService.GetEmployeeDetails(EmployeeId);
            if (CurEmp != null)
            {
                MyCountry = await countryDataService.GetCountryById(CurEmp.CountryId);
                MyDepartment = CurEmp?.DepartmentId is int id
                    ? await DepartmentDataService.GetDepartmentById(id)
                    : null;
            }
            IsDataLoaded = true;
        }
    }
}
