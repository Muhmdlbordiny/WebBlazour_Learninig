using Microsoft.AspNetCore.Mvc;
using MyAPI.Models;
using SharedLibrary.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly EmployeeDbContext _context;
        public DepartmentController(EmployeeDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<Department> Get()
        {
            return _context.Departments.ToList();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public Department Get(int id)
        {
            return _context.Departments.FirstOrDefault(e => e.Id == id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public void Post([FromBody] Department dep)
        {
            if (dep != null)
            {
                _context.Departments.Add(dep);
                _context.SaveChanges();
            }
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Department dep)
        {
            var editEmp = _context.Departments.FirstOrDefault(e => e.Id == id);
           // _context.Departments.Update(editEmp);
           editEmp.Name = dep.Name;
            _context.SaveChanges();

        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var delteemp = _context.Departments.FirstOrDefault(e => e.Id == id);
            _context.Departments.Remove(delteemp);
            _context.SaveChanges();
        }
    }
}
