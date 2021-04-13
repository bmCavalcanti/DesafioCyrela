using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cyrela.Models
{
    public class Scheduling
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public DateTime StartsAt { get; set; }
        public Employee Employee { get; set; }
        public Home Home { get; set; }
        public SchedulingStatus SchedulingStatus { get; set; }
        public SchedulingType SchedulingType { get; set; }
        public Service Service { get; set; }
    }
}