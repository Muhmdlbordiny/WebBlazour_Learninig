using SharedLibrary.Model;

namespace WebBlazour.Service
{
    public interface IEmployeeDataService
    {
       Task< IEnumerable<Employee> >GetAllEmployees();
       Task< Employee> GetEmployeeById(int employeeid);
       Task< Employee> GetEmployeeDetails(int employeeid);
        Task AddEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);
        Task DeleteEmployee(int employeeid);

    }
}
