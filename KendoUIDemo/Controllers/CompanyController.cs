﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using KendoUIDemo.Models;
using KendoUIDemo.Services;
using System.Web.Script.Serialization;
using KendoCRUDService.Helper;

namespace KendoUIDemo.Controllers
{
    public class CompanyController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Company_Read([DataSourceRequest]DataSourceRequest request)
        {
            DBModel db = new DBModel();
            IQueryable<Company> companies = db.Companies;
            DataSourceResult result = companies.ToDataSourceResult(request, company => new
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
                LogoPath = company.LogoPath,
            });

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        //public ActionResult Index()
        //{
        //    return this.Jsonp(CompanyRepository.All());
        //}

        public ActionResult Countries_Read()
        {
            CompanyService companyService = new CompanyService(new DBModel());
            return this.Jsonp(companyService.GetCountries());
        }

        public ActionResult States_Read()
        {
            CompanyService companyService = new CompanyService(new DBModel());
            return this.Jsonp(companyService.GetStates());
        }


        //public ActionResult Company_Read()
        //{
        //    return this.Jsonp(CompanyRepository.All());
        //}

        public JsonResult Update()
        {
            var models = this.DeserializeObject<IEnumerable<CompanyViewModel>>("models");
            if (models != null)
            {
                CompanyRepository.Update(models);
            }
            return this.Jsonp(models);
        }

        public ActionResult Destroy()
        {
            var companies = this.DeserializeObject<IEnumerable<CompanyViewModel>>("models");

            if (companies != null)
            {
                CompanyRepository.Delete(companies);
            }
            return this.Jsonp(companies);
        }

        public ActionResult Create()
        {

            var companies1 = this.DeserializeObject<IEnumerable<Company>>("models");
            var companies = this.DeserializeObject<IEnumerable<CompanyViewModel>>("models");
            if (companies != null)
            {
                CompanyRepository.Insert(companies);
            }
            return this.Jsonp(companies);
        }

        public JsonResult Read(int skip, int take)
        {
            IEnumerable<CompanyViewModel> result = CompanyRepository.All().OrderByDescending(p => p.CompanyID);

            result = result.Skip(skip).Take(take);

            return this.Jsonp(result);
        }

        public JsonResult Submit()
        {
            var model = this.DeserializeObject<SpreadsheetSubmitViewModel>("models");

            if (model != null && model.Created != null)
            {
                CompanyRepository.Insert(model.Created);
            }

            if (model != null && model.Updated != null)
            {
                CompanyRepository.Update(model.Updated);
            }

            if (model != null && model.Destroyed != null)
            {
                CompanyRepository.Delete(model.Destroyed);
            }

            return this.Jsonp(model);
        }

    }
}
