using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Services.Models
{
    public class Service
    {
        public int ID { get; set; }


        [StringLength(10, MinimumLength = 5)]
        public String Name { get; set; }


        [StringLength(3000, MinimumLength = 10)]
        public String Desription {get; set;}

        [Display(Name="Start Time")]
        
        public DateTime Startdate { get; set; }

        [Display(Name="End Time")]
        public DateTime Enddate { get; set; }

        public int ServicetypeId { get; set; }

        public virtual Servicetype servicetype { get; set; }

        public string ApplicationUserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

    }

}

