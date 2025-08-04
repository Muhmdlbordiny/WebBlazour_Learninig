using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Model
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(20,ErrorMessage ="between 20 char ")]
        public string FirstName { get; set; }
        [StringLength(20, ErrorMessage = "L Name between 20 char ")]

        public string LastName { get; set; }
        public  DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime JoinedDate { get; set; }
        public DateTime? ExitDate { get; set; }
        public decimal? Salary { get; set; }
        public string Comment { get; set; }
        public int CountryId { get; set; }
        public Country? Country { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public MaritalStatus MaritalStatus { get; set; }
        public Department? Department { get; set; }
        public int? DepartmentId { get; set; }

        // Navigation properties
    }
}
