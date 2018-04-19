using System;
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
using System.IO;


namespace MLandfill.Controllers
{
    public class ReportGenController : Controller
    {

        private string SetReportSubFolder(string PfolderType )
        {
            string folder; 
            string fmtDateStamp;

            

            if (PfolderType == "Root")
                folder =   System.Configuration.ConfigurationManager.AppSettings["ReportPathInvoice"];
            //@"~\Reports\rptPrintInv.rdlc"
            

            else
            {
                folder = System.Configuration.ConfigurationManager.AppSettings["ReportPathInvoice"];
                fmtDateStamp = DateTime.Now.ToString("dd_MMM_yyyy");
                folder +=  fmtDateStamp;


              
            }
            bool folderExists = Directory.Exists(folder);

            if (!folderExists)
            {
                DirectoryInfo di = Directory.CreateDirectory(folder);
            }

            return folder;
        }

        public FileResult InvoiceView(string month, int year, string wasteAppCode)
        {
           

            byte[] result;

            int thisval;
            string desiredMonth = month;
            string[] MonthNames = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
            thisval = Array.IndexOf(MonthNames, desiredMonth) + 1;


            DateTime dtFromDate = new DateTime(2016, 11, 01);
            DateTime dtToDate = new DateTime(2017, 1, 01);
            //using (var renderer = new WebReportRenderer(@"~\Reports\rptDailyLandFillSummary.rdlc", "rptDailyLandFillSummary.pdf"))
            using (var renderer = new WebReportRenderer(@"~\Reports\rptPrintInvoice.rdlc", "rptPrintInv.pdf"))     
            {
                DataReportLayer objDb = new DataReportLayer();

                //Microsoft.Reporting.WinForms.ReportDataSource rprtDTSource = new Microsoft.Reporting.WinForms.ReportDataSource(dt.TableName, dt); 


                renderer.ReportInstance.DataSources.Add(new ReportDataSource("InvoicePrintDataSet", objDb.InvoiceRptInfoGet(4047, Convert.ToString(thisval), year, wasteAppCode).ToList()));




                renderer.ReportInstance.Refresh();

                result = renderer.RenderToBytesPDF();

            }

            return File(result, "application/pdf", "rptPrintInv.pdf");
        }
        public FileResult InvoiceViewXX( string month ,int year , string wasteApprovalCode)
        {
            //http://www.danielroot.info/2009/06/how-to-render-reporting-services.html
            byte[] result;
            string fmtMonth=  month;
            if (Convert.ToInt16(fmtMonth) < 10)
                fmtMonth = "0" + fmtMonth;

            string FstDateOfMonth = "01/" + fmtMonth + "/" + Convert.ToString(year);

            DataReportLayer objDb = new DataReportLayer();
            
            int InvoiceNumberOut = objDb.InvoiceNumberCreate(wasteApprovalCode, DateTime.ParseExact(FstDateOfMonth, "dd/MM/yyyy", CultureInfo.InvariantCulture));
            string pdfFileName = objDb.InvoiceRptFileNameGet(wasteApprovalCode, month, year);
            using (var renderer = new WebReportRenderer(@"~\Reports\rptPrintInv.rdlc", pdfFileName))

            {
               
                renderer.ReportInstance.DataSources.Add(new ReportDataSource("ReportInvDataSet", objDb.InvoiceRptInfoGet(InvoiceNumberOut, month, year, wasteApprovalCode).ToList()));


                renderer.ReportInstance.Refresh();

                result = renderer.RenderToBytesPDF();

            }

            return File(result, "application/pdf", pdfFileName);

        }

        /*
         * This is to save into folder
        string sPath = System.Configuration.ConfigurationManager.AppSettings["ReportPathInvoice"];

        sPath = Path.Combine(Server.MapPath("~/" + sPath  ), pdfFileName);
        System.IO.File.WriteAllBytes(sPath, binary);

    result = renderer.RenderToBytesPDF();

        */
        // save no prompt: https://www.c-sharpcorner.com/UploadFile/013102/save-report-rdlc-as-pdf-at-run-time-in-C-Sharp/
        //http://www.dotnetawesome.com/2015/01/how-to-display-rdlc-report-in-report-viewer-control-into-mvc4.html
        public FileResult LandFillSummary(  )
        {
             
            byte[] result;

            DateTime dtFromDate = new DateTime(2016, 11, 01);
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


        public FileResult MonthlyLoadSummary()
        {

            byte[] result;

            DateTime dtFromDate = new DateTime(2017, 1, 01);
            DateTime dtToDate = new DateTime(2018, 1, 01);

            using (var renderer = new WebReportRenderer(@"~\Reports\rptMonthlyLoadSummary.rdlc", "rptMonthlyLoadSummary.pdf"))

            {
                DataReportLayer objDb = new DataReportLayer();

                //Microsoft.Reporting.WinForms.ReportDataSource rprtDTSource = new Microsoft.Reporting.WinForms.ReportDataSource(dt.TableName, dt); 


                renderer.ReportInstance.DataSources.Add(new ReportDataSource("MonthlyLoadSummaryDs", objDb.rptMonthlyLoadSummaryGet(108,dtFromDate, dtToDate, "NRL 141082 8").ToList()));



                renderer.ReportInstance.Refresh();

                result = renderer.RenderToBytesPDF();

            }

            return File(result, "application/pdf", "rptMonthlyLoadSummary.pdf");

        }

        public FileResult  SubstanceLoadSummary()
        {

            byte[] result;

            DateTime dtFromDate = new DateTime(2017, 1, 01);
            DateTime dtToDate = new DateTime(2018, 1, 01);

            using (var renderer = new WebReportRenderer(@"~\Reports\rptSubstanceLoadSummary.rdlc", "rptSubstanceLoadSummary.pdf"))

            {
                DataReportLayer objDb = new DataReportLayer();

                //Microsoft.Reporting.WinForms.ReportDataSource rprtDTSource = new Microsoft.Reporting.WinForms.ReportDataSource(dt.TableName, dt); 


                renderer.ReportInstance.DataSources.Add(new ReportDataSource("SubstanceLoadSummaryDs", objDb.rptSubstanceLoadSummaryGet( dtFromDate, dtToDate).ToList()));



                renderer.ReportInstance.Refresh();

                result = renderer.RenderToBytesPDF();

            }

            return File(result, "application/pdf", "rptSubstanceLoadSummary.pdf");

        }


        public FileResult LocationLoadSummary()
        {

            byte[] result;

            DateTime dtFromDate = new DateTime(2017, 1, 01);
            DateTime dtToDate = new DateTime(2018, 1, 01);

            using (var renderer = new WebReportRenderer(@"~\Reports\rptLocationLoadSummary.rdlc", "rptLocationLoadSummary.pdf"))
            {
                DataReportLayer objDb = new DataReportLayer();

                renderer.ReportInstance.DataSources.Add(new ReportDataSource("LocationLoadSummaryDs", objDb.rptLocationLoadSummaryGet(dtFromDate, dtToDate).ToList()));

                renderer.ReportInstance.Refresh();

                result = renderer.RenderToBytesPDF();

            }

            return File(result, "application/pdf", "rptLocationLoadSummary.pdf");

        }



        public FileResult CenovusDetail()
        {

            byte[] result;

            

            DateTime dtFromDate = new DateTime(2017, 1, 01);
            DateTime dtToDate = new DateTime(2018, 1, 01);
            string.Format("{0:MM/dd/yy}", dtFromDate);


            using (var renderer = new WebReportRenderer(@"~\Reports\rptCenovus.rdlc", "rptCenovus.pdf"))

            {
                DataReportLayer objDb = new DataReportLayer();

                //Microsoft.Reporting.WinForms.ReportDataSource rprtDTSource = new Microsoft.Reporting.WinForms.ReportDataSource(dt.TableName, dt); 


                renderer.ReportInstance.DataSources.Add(new ReportDataSource("CenovusDetailDs", objDb.rptCenovusGet(dtFromDate, dtToDate,40).ToList()));



                renderer.ReportInstance.Refresh();

                result = renderer.RenderToBytesPDF();

            }

            return File(result, "application/pdf", "rptCenovus.pdf");

        }



        public FileResult GeneralSummary()
        {

            byte[] result;

            DateTime dtFromDate = new DateTime(2017, 4, 01);
            DateTime dtToDate = new DateTime(2017, 7, 01);

            using (var renderer = new WebReportRenderer(@"~\Reports\rptGeneralGenSummary.rdlc", "rptGeneralGenSummary.pdf"))

            {
                DataReportLayer objDb = new DataReportLayer();

                //Microsoft.Reporting.WinForms.ReportDataSource rprtDTSource = new Microsoft.Reporting.WinForms.ReportDataSource(dt.TableName, dt); 


                renderer.ReportInstance.DataSources.Add(new ReportDataSource("GeneralGenSummaryDs", objDb.rptGeneralSummaryGet(dtFromDate, dtToDate).ToList()));



                renderer.ReportInstance.Refresh();

                result = renderer.RenderToBytesPDF();

            }

            return File(result, "application/pdf", "rptGeneralGenSummary.pdf");

        }
        // GET: ReportGen

        public FileResult SalesByCustomerSummary()
        {

            byte[] result;

            DateTime dtFromDate = new DateTime(2017, 1, 01);
            DateTime dtToDate = new DateTime(2018, 1, 01);

            using (var renderer = new WebReportRenderer(@"~\Reports\rptSalesByCustomerSummary.rdlc", "rptSalesByCustomerSummary.pdf"))
            {
                DataReportLayer objDb = new DataReportLayer();

                renderer.ReportInstance.DataSources.Add(new ReportDataSource("SaleByCustomerSummaryDs", objDb.rptSalesByCustomerSummaryGet(true,"June", 2016).ToList()));

                renderer.ReportInstance.Refresh();

                result = renderer.RenderToBytesPDF();

            }

            return File(result, "application/pdf", "rptSalesByCustomerSummary.pdf");

        }

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
