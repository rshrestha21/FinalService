using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services.Models
{
    public class Servicetype
    {

        public int ServicetypeId { get; set; }

        public String Servicekind {get; set;}

        public ICollection<Service> services { get; set; }


    }
}