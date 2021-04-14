using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cyrela.Models
{
    public class EmployeeDayOff
    {
        public int Id { get; set; }
        public DateTime DayOffDate { get; set; }
        public Employee Employee { get; set; }

    }
}