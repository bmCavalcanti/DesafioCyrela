using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cyrela.Models
{
    public class Home
    {
        public int Id { get; set; }
        public String Block { get; set; }
        public String Apartment { get; set; }
        public DateTime SaleDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public HomeAddress HomeAddress { get; set; }
        public Client Client { get; set; }
    }
}