using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cyrela.Models
{
    public class RoleService
    {
        public int Id { get; set; }
        public Role role { get; set; }
        public Service service { get; set; }
    }
}