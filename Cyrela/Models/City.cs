﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cyrela.Models
{
    public class City
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public State state { get; set; }
    }
}