using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MLandfill.Models;
using MLandfill.DataAccess;
using System.Globalization;
using System.Web.Script.Serialization;

namespace MLandfill.Controllers
{
    public class InvoiceDocketsController : Controller
    {
        // GET: InvoiceDockets
        public ActionResult Index(int generatorId=108, string month= "March", int year=2017, string wasteApprovalCode= "NRL1100018")
        {
            InvoiceDocket objInvoiceDockets = new InvoiceDocket();

            DataAccessLayer objDb = new DataAccessLayer();

            List<InvoiceDocket> InvoiceDockets = objDb.InvoiceDocketsGet(generatorId, month, year, wasteApprovalCode).ToList();

            ViewBag.WasteAppCode = wasteApprovalCode;

            return View(InvoiceDockets);
        }
        public ActionResult GeneratorListGet(string month, int year)
        {
            List<tblGenerator> generators = new List<tblGenerator>();

            DataAccessLayer objDb = new DataAccessLayer();

            List<tblGenerator> generatorList = objDb.InvoiceGeneratosGet( month, year).ToList();

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string result = javaScriptSerializer.Serialize(generatorList);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult WstApprovalCodeListGet(int generatorId, string month, int year)
        {
            List<tblLandFillWasteDocket> wasteApprovalCodes = new List<tblLandFillWasteDocket>();

            DataAccessLayer objDb = new DataAccessLayer();

            List<tblLandFillWasteDocket> wasteApprovalList = objDb.InvoiceWasteAppCodesGet(generatorId, month, year).ToList();

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string result = javaScriptSerializer.Serialize(wasteApprovalList);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult IndexNew()
        {
            ViewData["Months"] =
                new SelectList(Enumerable.Range(1, 12).Select(x =>
          new SelectListItem()
          {
              //Text = CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedMonthNames[x - 1] + " (" + x + ")",
              Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName( x),
              Value = x.ToString()
          }), "Value", "Text");

            // ViewBag.Months =
            // ViewBag.Years

            ViewData["Years"] = new SelectList(Enumerable.Range(DateTime.Today.Year-4, 5).Select(x =>

               new SelectListItem()
               {
                   Text = x.ToString(),
                   Value = x.ToString()
               }), "Value", "Text");


            return View();

        }

        public ActionResult _DocketDetailsGet(int generatorId , string month , int year , string wasteApprovalCode)
        {
            InvoiceDocket objInvoiceDockets = new InvoiceDocket();

            DataAccessLayer objDb = new DataAccessLayer();

            List<InvoiceDocket> InvoiceDockets = objDb.InvoiceDocketsGet(generatorId, month, year, wasteApprovalCode).ToList();
            InvoiceDocket InvoiceModel = new InvoiceDocket();


            //ViewData["InvoiceModelVDat"] = InvoiceModel;


            return View(InvoiceDockets);

            //LandFill_DBContext dbContext = new LandFill_DBContext();
            //tblTruckCompany truckComp = dbContext.tblTruckCompanies.Single(x => x.TruckCompId == id);
            //return View(truckComp);
        }
        
        
        // GET: InvoiceDockets/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InvoiceDockets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InvoiceDockets/Create
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

        // GET: InvoiceDockets/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InvoiceDockets/Edit/5
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

        // GET: InvoiceDockets/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InvoiceDockets/Delete/5
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
        //DropDown : GetYears() will fill Year DropDown and Return List.  
       public ActionResult GridWithJquery()
        {


            return View();
        }
        public JsonResult GridMvcWithJquery()
        {


            return Json("", JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateInvoiceNo(int month, int year, int generatorId, string wasteApprovalCode)
        {
            int newInvoiceNumber;

            DataAccessLayer objDb = new DataAccessLayer();

            newInvoiceNumber = objDb.NewInvoiceNoGet(month, year, generatorId, wasteApprovalCode);

            return Json(newInvoiceNumber, JsonRequestBehavior.AllowGet);

            //return View(newInvoiceNumber.ToString());
        }
    }
}
