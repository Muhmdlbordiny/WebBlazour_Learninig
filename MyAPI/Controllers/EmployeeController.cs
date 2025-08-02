using Microsoft.AspNetCore.Mvc;
using MyAPI.Models;
using SharedLibrary.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDbContext _context;
        public EmployeeController(EmployeeDbContext context)
        {
            _context = context;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _context.Employees.ToList();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return _context.Employees.FirstOrDefault(e=>e.EmployeeId==id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public void Post([FromBody] Employee emp)
        {
            if (emp != null)
            {
                _context.Employees.Add(emp);
                _context.SaveChanges();
            }
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee emp)
        {
            var editEmp = _context.Employees.FirstOrDefault(e=>e.EmployeeId==id);
            _context.Employees.Update(editEmp);
            _context.SaveChanges();
            
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var delteemp = _context.Employees.FirstOrDefault(e=>e.EmployeeId== id);
            _context.Employees.Remove(delteemp);
            _context.SaveChanges();
        }
    }
}
