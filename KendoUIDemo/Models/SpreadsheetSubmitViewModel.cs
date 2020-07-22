using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KendoUIDemo.Models
{
    public class SpreadsheetSubmitViewModel
    {
        public IList<CompanyViewModel> Created { get; set; }

        public IList<CompanyViewModel> Destroyed { get; set; }

        public IList<CompanyViewModel> Updated { get; set; }
    }
}