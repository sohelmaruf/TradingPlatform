using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KendoUIDemo.Services;

namespace KendoUIDemo.Models
{
    public static class CompanyRepository
    {

        public static IList<CompanyViewModel> All()
        {
            var result = HttpContext.Current.Session["Companies"] as IList<CompanyViewModel>;

            if (result == null)
            {
                HttpContext.Current.Session["Companies"] = result =
                    new DBModel().Companies.Select(company => new CompanyViewModel
                    {
                        CompanyID = company.CompanyID,
                        Name = company.Name,
                        AddressLine1 = company.AddressLine1,
                        AddressLine2 = company.AddressLine2,
                        City = company.City,
                        State = company.State,
                        ZipCode = company.ZipCode,
                        Country = company.Country,
                        Contact = company.Contact,
                        TradingZone = company.TradingZone,
                        LogoPath = company.LogoPath
                    }).ToList();
            }

            return result;
        }

        public static CompanyViewModel One(Func<CompanyViewModel, bool> predicate)
        {
            return All().FirstOrDefault(predicate);
        }

        public static void Insert(CompanyViewModel company)
        {
            CompanyService companyService = new CompanyService(new DBModel());
            companyService.Create(company);
        }

        public static void Insert(IEnumerable<CompanyViewModel> companies)
        {
            CompanyService companyService = new CompanyService(new DBModel());
            foreach (var company in companies)
            {
                companyService.Create(company);
            }
        }

        public static void Update(CompanyViewModel company)
        {
            var target = One(p => p.CompanyID == company.CompanyID);
            if (target != null)
            {
                //target.CompanyID = company.CompanyID;
                target.Name = company.Name;
                target.AddressLine1 = company.AddressLine1;
                target.AddressLine2 = company.AddressLine2;
                target.City = company.City;
                target.State = company.State;
                target.ZipCode = company.ZipCode;
                target.Country = company.Country;
                target.Contact = company.Contact;
                target.TradingZone = company.TradingZone;
                target.LogoPath = company.LogoPath;
            }
        }

        public static void Update(IEnumerable<CompanyViewModel> companies)
        {
            CompanyService companyService = new CompanyService(new DBModel());

            foreach (var company in companies)
            {
                companyService.Update(company);
            }
        }

        public static void Delete(CompanyViewModel company)
        {
            var target = One(p => p.CompanyID == company.CompanyID);
            if (target != null)
            {
                All().Remove(target);
            }
        }

        public static void Delete(IEnumerable<CompanyViewModel> companies)
        {
            CompanyService companyService = new CompanyService(new DBModel());
            foreach (var company in companies)
            {
                companyService.Destroy(company);
            }
        }
    }
}