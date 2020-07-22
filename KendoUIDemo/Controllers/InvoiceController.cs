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

namespace KendoUIDemo.Controllers
{
    public class InvoiceController : Controller
    {
        private DBModel db = new DBModel();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Invoices_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Invoice> invoices = db.Invoices;
            DataSourceResult result = invoices.ToDataSourceResult(request, invoice => new {
                InvoiceID = invoice.InvoiceID,
                InvoiceNumber = invoice.InvoiceNumber,
                InvoiceType = invoice.InvoiceType,
                InvoiceDate = invoice.InvoiceDate,
                InvoiceAmount = invoice.InvoiceAmount,
                Category = invoice.Category,
            });

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
