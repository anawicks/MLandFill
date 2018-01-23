using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MLandfill.Models;
using MLandfill.DataAccess;
using System.Globalization;
using System.Web.Script.Serialization;
using Microsoft.Reporting.WebForms;
using System.Data.SqlClient;
using MLandfill.Reports;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;

namespace MLandfill.Controllers
{
    public class InvoiceBatchController : Controller
    {

        DataSetInvoice ds = new DataSetInvoice();

        public ActionResult ReportInvoice(int InvoiceNo =3036 )
        {

            DataAccessLayer objDb = new DataAccessLayer();


            ReportViewer reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;
            
            reportViewer.Width = Unit.Percentage(75);
            reportViewer.Height = Unit.Percentage(95);

            //InvoiceRptInfoGet

            ds = objDb.InvoiceRptInfoGet(InvoiceNo);

            /*
             * ReportParameter p4 = new ReportParameter("Error_4", Error_4_value);

 this.reportViewer1.LocalReport.SetParameters(p1);

this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4 });
*/
            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reports\ReportA1.rdlc";
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSetForInvoice", ds.Tables[0]));

            ViewBag.ReportViewer = reportViewer;

            return View();
        }

        // GET: InvoiceBatch
        //http://www.c-sharpcorner.com/article/display-data-in-report-viewer-with-mvc-4/
        // E:\GIT\GitRepository\MLandFill\MLandfill\Reports\ReportA1.rdlc
        public ActionResult Index(string month="October",int year=2017)
        {
            

            DataAccessLayer objDb = new DataAccessLayer();

            List<InvoiceBatchGrid> GridspInvoiceBatch = objDb.InvoiceBatchGridGet(month, year).ToList();
                 


            return View(GridspInvoiceBatch);
        }
        public ActionResult IndexInvNew()
        {
            ViewData["Months"] =
                new SelectList(Enumerable.Range(1, 12).Select(x =>
          new SelectListItem()
          {
              //Text = CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedMonthNames[x - 1] + " (" + x + ")",
              Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(x),
              Value = x.ToString()
          }), "Value", "Text");

            // ViewBag.Months =
            // ViewBag.Years

            ViewData["Years"] = new SelectList(Enumerable.Range(DateTime.Today.Year - 4, 5).Select(x =>

                 new SelectListItem()
                 {
                     Text = x.ToString(),
                     Value = x.ToString()
                 }), "Value", "Text");


            return View();



        }

        public ActionResult _InvoiceBatchDetailsGet(string month, int year)
        {
            InvoiceBatchGrid objInvoiceDockets = new InvoiceBatchGrid();

            DataAccessLayer objDb = new DataAccessLayer();

            List<InvoiceBatchGrid> InvoiceDockets = objDb.InvoiceBatchGridGet(month, year).ToList();
 

            return View(InvoiceDockets);

             
        }

        // GET: InvoiceBatch/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InvoiceBatch/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InvoiceBatch/Create
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

        // GET: InvoiceBatch/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InvoiceBatch/Edit/5
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

        // GET: InvoiceBatch/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InvoiceBatch/Delete/5
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
