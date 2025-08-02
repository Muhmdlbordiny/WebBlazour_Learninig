using Microsoft.AspNetCore.Components;
using SharedLibrary.Model;

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
        List<Employee> Employees;
        List<Country> Countries;
        protected override Task OnInitializedAsync()
        {
            Employees = new List<Employee>
        {
            new Employee { EmployeeId = 1,PhoneNumber="01276738534",ExitDate=null,BirthDate=new DateTime(1999,2,8),JoinedDate=new DateTime(2008,7,13),Gender = Gender.Male,MaritalStatus=MaritalStatus.Single ,Email="mohamed@gmail.com", FirstName = "mohamed ",LastName="ashraf", CountryId = 1 },
            new Employee { EmployeeId = 2,PhoneNumber="01276738534",ExitDate=null,BirthDate=new DateTime(1993,3,21),JoinedDate=new DateTime(2008,7,10),Gender = Gender.Male,MaritalStatus=MaritalStatus.Married ,Email="ahmed@gmail.com", FirstName = "ahmed ",LastName="ashraf", CountryId = 2 },
            new Employee { EmployeeId = 3,PhoneNumber="01276738534",ExitDate=null,BirthDate=new DateTime(2001,2,5),JoinedDate=new DateTime(2009,8,15),Gender = Gender.Female,MaritalStatus=MaritalStatus.Single ,Email="aya@gmail.com", FirstName = "aya ",LastName="halim", CountryId = 1 }
        };
            Countries = new List<Country>
        {
            new Country { CountryId = 1, Name = "Egypt" },
            new Country { CountryId = 2, Name = "USA" },
            new Country { CountryId = 3, Name = "UK" }
        };
            CurEmp = Employees.FirstOrDefault(e => e.EmployeeId == EmployeeId);
            return base.OnInitializedAsync();
        }
        protected void HandlevaildSubmit()
        {
            Saved = false;
            if (CurEmp.EmployeeId == 0)
            {
                Employees.Add(CurEmp);
            }
            else
            {
                var editEmp = Employees.FirstOrDefault(e => e.EmployeeId == EmployeeId);
                if (editEmp != null)
                {
                    editEmp.FirstName = CurEmp.FirstName;
                    editEmp.LastName = CurEmp.LastName;
                    editEmp.MaritalStatus = CurEmp.MaritalStatus;
                }
                Myclass = "alert alert-success";
                Message = "Employee Updated Successfully";
                Saved = true;
            }
        }
        protected void HandleInvaildSubmit()
        {
            Myclass = "alert alert-danger";
            Message = " Please  Check Vaildation fill all required fields correctly. plz try Again ";

        }
    }
}
