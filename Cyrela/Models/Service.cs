using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cyrela.Models
{
    public class Service
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int MonthsWarranty { get; set; }
        public String Description { get; set; }
    }
}