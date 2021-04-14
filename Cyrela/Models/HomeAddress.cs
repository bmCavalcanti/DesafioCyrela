using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cyrela.Models
{
    public class HomeAddress
    {
        public int Id { get; set; }
        public String Street { get; set; }
        public String District { get; set; }
        public String HomeNumber { get; set; }
        public String Complement { get; set; }
        public City City { get; set; }
    }
}