using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DomainModel
{
    [Table("Employee")]
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}