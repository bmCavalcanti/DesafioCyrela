using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cyrela.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime WorkStartsAt { get; set; }
        public DateTime WorkEndsAt { get; set; }
        public bool IsActive { get; set; }
        public Role Role { get; set; }

    }
}