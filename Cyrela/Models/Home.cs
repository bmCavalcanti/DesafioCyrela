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
        public DateTime DateSale { get; set; }
        public DateTime DateDelivery { get; set; }
        public HomeAddress HomeAddress { get; set; }
        public Client Client { get; set; }
    }
}