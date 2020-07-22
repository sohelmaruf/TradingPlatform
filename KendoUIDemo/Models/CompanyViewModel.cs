using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KendoUIDemo.Models
{
    public class CompanyViewModel
    {
        [ScaffoldColumn(false)]
        public int CompanyID { get; set; }

        [Required]
        [DisplayName("Company name")]
        public string Name { get; set; }


        [DisplayName("Address Line One")]
        public string AddressLine1 { get; set; }


        [DisplayName("Address Line Two")]
        public string AddressLine2 { get; set; }

        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string Contact { get; set; }
        public string TradingZone { get; set; }
        public string LogoPath { get; set; }

    }
}