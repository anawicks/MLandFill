﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MLandfill.Models;
using MLandfill.DataAccess;
using System.Globalization;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;
using MLandfill.Reports;


namespace MLandfill.Controllers
{
    public class ReportGenController : Controller
    {


        public FileResult InvoiceView(int invoiceNumber = 5118)
        {
            //http://www.danielroot.info/2009/06/how-to-render-reporting-services.html
            byte[] result;

            using (var renderer = new WebReportRenderer(@"~\Reports\rptPrintInv.rdlc", "rptPrintInv.pdf"))

            {
                DataAccessLayer objDb = new DataAccessLayer();

                //Microsoft.Reporting.WinForms.ReportDataSource rprtDTSource = new Microsoft.Reporting.WinForms.ReportDataSource(dt.TableName, dt); 


                renderer.ReportInstance.DataSources.Add(new ReportDataSource("ReportInvDataSet", objDb.InvoiceRptInfoGet(invoiceNumber).ToList()));



                renderer.ReportInstance.Refresh();

                result = renderer.RenderToBytesPDF();

            }

            return File(result, "application/pdf", "rptPrintInv.pdf");

        }


        public FileResult LandFillSummary(  )
        {
             
            byte[] result;

            DateTime dtFromDate = new DateTime(2016, 1, 01);
            DateTime dtToDate = new DateTime(2017, 1, 01);

            using (var renderer = new WebReportRenderer(@"~\Reports\rptDailyLandFillSummary.rdlc", "rptDailyLandFillSummary.pdf"))

            {
                DataReportLayer objDb = new DataReportLayer();

                //Microsoft.Reporting.WinForms.ReportDataSource rprtDTSource = new Microsoft.Reporting.WinForms.ReportDataSource(dt.TableName, dt); 


                renderer.ReportInstance.DataSources.Add(new ReportDataSource("DailyLandFillDataSet", objDb.rptDailyLandFillSummaryGet(dtFromDate, dtToDate).ToList()));



                renderer.ReportInstance.Refresh();

                result = renderer.RenderToBytesPDF();

            }

            return File(result, "application/pdf", "rptDailyLandFillSummary.pdf");

        }

        // GET: ReportGen
        public ActionResult Index()
        {
            return View();
        }

        // GET: ReportGen/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReportGen/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReportGen/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ReportGen/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReportGen/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ReportGen/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReportGen/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
