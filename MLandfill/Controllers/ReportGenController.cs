using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
using System.Diagnostics;
using System.Web;
using System.Web.UI;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Drawing;
using System.Drawing.Printing;

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
           //*****This is working Final for Single Invoice Printing

            byte[] result;

            int thisval;
            string desiredMonth = month;
            string[] MonthNames = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
            thisval = Array.IndexOf(MonthNames, desiredMonth) + 1;

            DataReportLayer objDb = new DataReportLayer();

            string fmtMonth = Convert.ToString(thisval);
            if (Convert.ToInt16(fmtMonth) < 10)
                fmtMonth = "0" + fmtMonth;

            string FstDateOfMonth = "01/" + fmtMonth + "/" + Convert.ToString(year);

            // Get Invoice No
            int InvoiceNumberOut = objDb.InvoiceNumberCreate(wasteAppCode, DateTime.ParseExact(FstDateOfMonth, "dd/MM/yyyy", CultureInfo.InvariantCulture));


            //Get InvoiceFileName

            string pdfFileName = objDb.InvoiceRptFileNameGet(wasteAppCode, Convert.ToString(thisval), year);

            //Debug.WriteLine(pdfFileName);

            using (var renderer = new WebReportRenderer(@"~\Reports\rptPrintInv.rdlc", pdfFileName.Trim()))     
            {             
                renderer.ReportInstance.DataSources.Add(new ReportDataSource("ReportInvDS", objDb.InvoiceRptInfoGet(InvoiceNumberOut, Convert.ToString(thisval), year, wasteAppCode).ToList()));

                renderer.ReportInstance.Refresh();

                  result = renderer.RenderToBytesPDF();

                renderer.RenderToBytesPDFAW(@"~\Reports\rptPrintInv.rdlc",pdfFileName);

            }

            return File(result, "application/pdf", pdfFileName.Trim());
        }
        public FileResult xInvoiceViewXX( string month ,int year , string wasteApprovalCode)
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


        public ActionResult LandFillSummaryPrint()
        {
             

            DateTime dtFromDate = new DateTime(2016, 11, 01);
            DateTime dtToDate = new DateTime(2017, 1, 01);

            DataReportLayer objDb = new DataReportLayer();

            LocalReport localReport = new LocalReport();


            string FullReportPath;


            //HttpContext.Current.Server.MapPath(@"~\Reports\rptDailyLandFillSummary.rdlc");

            using (var renderer = new WebReportRenderer(@"~\Reports\rptDailyLandFillSummary.rdlc", "rptDailyLandFillSummary.pdf"))
            {
                 FullReportPath = renderer.GetFullReportPath(@"~\Reports\rptDailyLandFillSummary.rdlc");

            }

            localReport.ReportPath = FullReportPath;
            ReportDataSource reportDataSource = new ReportDataSource();


            localReport.DataSources.Add(new ReportDataSource("DailyLandFillDataSet", objDb.rptDailyLandFillSummaryGet(dtFromDate, dtToDate).ToList()));

            string reportType = "PDF";
            string mimeType;
            string encoding;
            string fileNameExtension = "pdf";
            //The DeviceInfo settings should be changed based on the reportType 
            string deviceInfo = @"<DeviceInfo>              
                     <OutputFormat>PDF</OutputFormat>              
                     <PageWidth>9.2in</PageWidth>              
                     <PageHeight>12in</PageHeight>          
                     <MarginTop>0.25in</MarginTop>          
                     <MarginLeft>0.45in</MarginLeft>            
                     <MarginRight>0.45in</MarginRight>       
                     <MarginBottom>0.25in</MarginBottom></DeviceInfo>";
            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            //renderedBytes = localReport.Render(
            // reportType, deviceInfo, out mimeType, out encoding, out fileNameExtension,
            // out streams, out warnings);

            renderedBytes = localReport.Render("PDF", null, out mimeType, out encoding, out fileNameExtension, out streams,
                                         out warnings);
            var doc = new Document();
            var reader = new PdfReader(renderedBytes);
            using (FileStream fs = new FileStream(Server.MapPath("~/Reports" +
                 Convert.ToString(Session["CurrentUserName"]) + ".pdf"), FileMode.Create))
            {
                PdfStamper stamper = new PdfStamper(reader, fs);
                string Printer = "";
                if (Printer == null || Printer == "")
                {
                    stamper.JavaScript = "var pp = getPrintParams();pp.interactive = pp.constants.interactionLevel.automatic;pp.printerName = getPrintParams().printerName;print(pp);\r";
                    stamper.Close();
                }
                else
                {
                    stamper.JavaScript = "var pp = getPrintParams();pp.interactive = pp.constants.interactionLevel.automatic;pp.printerName = " + Printer + ";print(pp);\r";
                    stamper.Close();
                }


            }
            reader.Close();
            FileStream fss = new FileStream(Server.MapPath("~/Report/Reports.pdf"), FileMode.Open);
            byte[] bytes = new byte[fss.Length];
            fss.Read(bytes, 0, Convert.ToInt32(fss.Length));
            fss.Close();
            System.IO.File.Delete(Server.MapPath("~/Report/Reports.pdf"));
            //Here we returns the file result for view(PDF)
            FileStream fssA = new FileStream(Server.MapPath("~/Report/Reports.pdf"), FileMode.Open);
            byte[] bytesA = new byte[fssA.Length];
            fssA.Read(bytesA, 0, Convert.ToInt32(fssA.Length));
            fssA.Close();
            System.IO.File.Delete(Server.MapPath("~/Report/Reports.pdf"));
            return File(bytes, "application/pdf");
        }

    

        public FileResult LandFillSummary()
        {
             
            byte[] result;
            //SendToPrinter("", "");
            DateTime dtFromDate = new DateTime(2016, 11, 01);
            DateTime dtToDate = new DateTime(2016, 11, 02);

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
        private void SendToPrinter(string pdfFileName = @"E:\LandFillApplication\InvoiceReports\rptDailyLandFillSummary.pdf", string filePath= @"~\Reports\rptDailyLandFillSummary.pdf")
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.Verb = "print";
            info.FileName = pdfFileName; 
            info.CreateNoWindow = true;
            info.WindowStyle = ProcessWindowStyle.Hidden;

            Process p = new Process();
            p.StartInfo = info;
            p.Start();

            p.WaitForInputIdle();
            System.Threading.Thread.Sleep(3000);
            if (false == p.CloseMainWindow())
                p.Kill();
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

        public ActionResult InvoiceBatch(string month = "3", string year="2016")
        {

            int thisval;
            string desiredMonth = month;
            string[] MonthNames = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
            thisval = Array.IndexOf(MonthNames, desiredMonth) + 1;


            string pApprovalCode;
            DataReportLayer objDb = new DataReportLayer();        


            InvoiceBatchGrid objInvoiceDockets = new InvoiceBatchGrid();             

            List<InvoiceBatchGrid> InvoiceDockets = objDb.InvoiceBatchGridGet(Convert.ToString(thisval), Convert.ToInt16(year)).ToList();

            foreach (var approvalCodeP in InvoiceDockets)
            {
                pApprovalCode=approvalCodeP.WApApprovalcode;
                //Debug.WriteLine(pApprovalCode);
                InvoiceView(month,Convert.ToInt16(year), pApprovalCode);
            }
            // docket.WApApprovalcode

            /*
             *public IEnumerable<InvoiceBatchGrid> InvoiceBatchGridGet(string Month, int year)
             * */

            // Call spInvoicePrintBatchGet

            //in a loop get WasterAppCode and call invoiceView in This controller string month, int year)

            //return new EmptyResult(); IndexInvNew

            return RedirectToAction("_InvoiceBatchDetailsGet", "InvoiceBatch", new { @month = month, @year = year });

            //return RedirectToAction("IndexInvNew", "InvoiceBatch" );
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
