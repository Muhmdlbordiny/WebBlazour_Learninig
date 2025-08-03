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
        public IActionResult Post([FromBody] Employee emp)
        {
            
            try
            {
                if (emp == null)
                    return BadRequest("Employee is null");
               // emp.Country = null;
                _context.Employees.Add(emp);
                _context.SaveChanges();

                return CreatedAtAction(nameof(Post), new { id = emp.EmployeeId }, emp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee emp)
        {
            var editEmp = _context.Employees.FirstOrDefault(e=>e.EmployeeId==id);
           // _context.Employees.Update(editEmp);
            editEmp.FirstName = emp.FirstName;
            editEmp.LastName = emp.LastName;
            editEmp.Email = emp.Email;
            editEmp.PhoneNumber = emp.PhoneNumber;
            editEmp.BirthDate = emp.BirthDate;
            editEmp.JoinedDate = emp.JoinedDate;
            editEmp.ExitDate = emp.ExitDate;
            editEmp.Gender = emp.Gender;
            editEmp.MaritalStatus = emp.MaritalStatus;
            editEmp.CountryId = emp.CountryId;
            editEmp.Comment = emp.Comment;

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
