using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAPI.Models;
using SharedLibrary.Model;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly EmployeeDbContext _context;
        public CountryController(EmployeeDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<Country> Get()
        {
            return _context.Countries.ToList();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public Country Get(int id)
        {
            return _context.Countries.FirstOrDefault(e => e.CountryId == id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public void Post([FromBody] Country emp)
        {
            if (emp != null)
            {
                _context.Countries.Add(emp);
                _context.SaveChanges();
            }
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Country emp)
        {
            var editEmp = _context.Countries.FirstOrDefault(e => e.CountryId == id);
            _context.Countries.Update(editEmp);
            _context.SaveChanges();

        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var delteemp = _context.Countries.FirstOrDefault(e => e.CountryId == id);
            _context.Countries.Remove(delteemp);
            _context.SaveChanges();
        }
    }
}
