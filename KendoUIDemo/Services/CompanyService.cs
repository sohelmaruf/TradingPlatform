using Kendo.Mvc.UI;
using KendoUIDemo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace KendoUIDemo.Services
{
    public class CompanyService: IDisposable
    {
        private static bool UpdateDatabase = false;
        private DBModel db;

        public CompanyService(DBModel entities)
        {
            this.db = entities;
        }

        public IList<CompanyViewModel> GetAll()
        {
            var result = HttpContext.Current.Session["Company"] as IList<CompanyViewModel>;

            if (result == null || UpdateDatabase)
            {
                result = db.Companies.Select(company => new CompanyViewModel
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

                HttpContext.Current.Session["Company"] = result;
            }

            return result;
        }

        public IEnumerable<CompanyViewModel> Read()
        {
            return GetAll();
        }

       
        public void Create(CompanyViewModel company)
        {
            var entity = new Company();

            entity.Name = company.Name;
            entity.AddressLine1 = company.AddressLine1;
            entity.AddressLine2 = company.AddressLine2;
            entity.City = company.City;
            entity.State = company.State;
            entity.ZipCode = company.ZipCode;
            entity.Country = company.Country;
            entity.Contact = company.Contact;
            entity.TradingZone = company.TradingZone;
            entity.LogoPath = company.LogoPath;

            db.Companies.Add(entity);
            db.SaveChanges();

            company.CompanyID = entity.CompanyID;
        }

        public void Update(CompanyViewModel company)
        {
            if (!UpdateDatabase)
            {
                Company entity = db.Companies.Where(x => x.CompanyID == company.CompanyID).FirstOrDefault<Company>();

                entity.CompanyID = company.CompanyID;
                entity.Name = company.Name;
                entity.AddressLine1 = company.AddressLine1;
                entity.AddressLine2 = company.AddressLine2;
                entity.City = company.City;
                entity.State = company.State;
                entity.ZipCode = company.ZipCode;
                entity.Country = company.Country;
                entity.Contact = company.Contact;
                entity.TradingZone = company.TradingZone;
                entity.LogoPath = company.LogoPath;

                db.Companies.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                var entity = new Company();

                entity.CompanyID = company.CompanyID;
                entity.Name = company.Name;
                entity.AddressLine1 = company.AddressLine1;
                entity.AddressLine2 = company.AddressLine2;
                entity.City = company.City;
                entity.State = company.State;
                entity.ZipCode = company.ZipCode;
                entity.Country = company.Country;
                entity.Contact = company.Contact;
                entity.TradingZone = company.TradingZone;
                entity.LogoPath = company.LogoPath;

                db.Companies.Add(entity);
                db.SaveChanges();
            }
        }

        public void Destroy(CompanyViewModel company)
        {
            Company entity = db.Companies.Where(x => x.CompanyID == company.CompanyID).FirstOrDefault<Company>();
            db.Companies.Remove(entity);

            db.SaveChanges();
        }

        public CompanyViewModel One(Func<CompanyViewModel, bool> predicate)
        {
            return GetAll().FirstOrDefault(predicate);
        }


        public IEnumerable<Country> GetCountries()
        {
            var countryList = db.Countries.OrderBy(x =>x.Name);

            return countryList;
        }

        public IEnumerable<State> GetStates()
        {
            var stateList = db.States.OrderBy(x => x.Name); ;

            return stateList;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}