using SharedLibrary.Model;

namespace WebBlazour.Service
{
    public interface IDepartmentDataService
    {
        Task<IEnumerable<Department>> GetAllDepartment();
        Task<Department> GetDepartmentById(int DepartmentId);
        Task AddDepartment(Department Dept);
        Task UpdateDepartment(Department Dept);
        Task DeleteDepartment(int departmentid);
    }
}
