using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MLandfill.Core.Domain;
using MLandfill.DataAccess;
using MLandfill.Models;
using MLandfill.ViewModel;

namespace MLandfill.Controllers
{
    public class MaintWasteApprovalController : Controller
    {
        // GET: MaintWasteApproval
        public ActionResult Index()
        {
             

            DataAccessLayer objDb = new DataAccessLayer();

            List<tblMaintWasteApCode> wasteAppCodes= objDb.WasteApprovalCodeAllGet().ToList();

        

            return View(wasteAppCodes);
        }
        
        public ActionResult Details(int id)
        {
             

            DataAccessLayer objDb = new DataAccessLayer();

            //List<tblMaintWasteApCode> wasteAppCodeDetail = objDb.WasteAppCodeSingleGet(id).ToList();

            // return View(wasteAppCodeDetail.First());
            tblMaintWasteApCode wasteAppCodeDetail = objDb.WasteAppCodeSingleGet(id).First();

            return View(wasteAppCodeDetail);
        }
        
        // GET: MaintWasteApproval/Create
        public ActionResult Create()
        {
            string appcodebag;

            LandFill_DBContext lfDbContext = new LandFill_DBContext();

            var generatorTypes = lfDbContext.tblGenerators.ToList();
            var substancesTypes = lfDbContext.tblSubstances.ToList();

            var truckCompTypes = lfDbContext.tblTruckCompanies.ToList();

            var genLocations = lfDbContext.tblGeneratorLocations.ToList();

            var invoiceeTypes = lfDbContext.tblInvoiceesDds.ToList();

            //.Select( c => new {COURSE_ID = c.COURSE_ID, COURSE_TITLE = c.CIN + " " + c.COURSE_TITLE})

            DataAccessLayer objDb = new DataAccessLayer();

            tblTruckCompany truckModel = new tblTruckCompany();

            var consultantTypes = lfDbContext.tblConsultants.ToList();

            var generatorsQuery = from d in generatorTypes
                                  orderby d.GeneratorName
                                  select d;
         

            var substancesQuery = from d in substancesTypes
                                  orderby d.SubstanceName
                                  select d;

 

            var genLocationsQuery = from d in genLocations
                                    orderby d.GenerLocationLsd
                                    select d;

            var invoiceesQuery = from d in invoiceeTypes
                                 orderby d.InvoiceeName
                                 select d;

           

            var aviewModel = new tblMaintWasteApCode
            {

                ddGenerators = generatorTypes,
                ddSubstance = substancesTypes,
                ddTruckCompany = truckCompTypes,
                ddLocations = genLocations,
                ddInvoiceeD = invoiceeTypes,
                ddconsultants = consultantTypes

            };
            appcodebag = "NRL " +   objDb.ApprovalCodeIdNextGet();
            ViewData["AppCode"] = appcodebag;

            ViewData["generatorsNames"] = new SelectList(generatorsQuery, "GeneratorId", "GeneratorName", aviewModel.WApGeneratorId);

          
            ViewData["substancesNames"] = new SelectList(substancesQuery, "SubstanceId", "SubstanceName", aviewModel.WApSubId); 
            ViewData["lsdLocationNames"] = new SelectList(genLocationsQuery, "GenerLocationId", "GenerLocationLsd", aviewModel.WApLocationId);
            ViewData["invoiceerNames"] = new SelectList(invoiceesQuery, "InvoiceeID", "InvoiceeName", aviewModel.WApInvoicee); 

            return View(aviewModel);
        }

        // POST: MaintWasteApproval/Create  
        [HttpPost]
        public ActionResult Create(tblMaintWasteApCode appCodeModel)
        {
            try
            {
                var errors = ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .Select(x => new { x.Key, x.Value.Errors })
                .ToArray();

                var errorList = errors.ToList();

                if (ModelState.IsValid)
                {
                    

                    DataAccessLayer objDb = new DataAccessLayer();

                    objDb.prgeneratorId = Convert.ToInt32(Request["generatorsNames"]);
                    objDb.prsubstanceId = Convert.ToInt32(Request["substancesNames"]);
                    objDb.prlsdId = Convert.ToInt32(Request["lsdLocationNames"]);
                    objDb.prinvoiceId = Convert.ToInt32(Request["invoiceerNames"]); 

                    objDb.WasteAppCodeAddNew(appCodeModel);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return RedirectToAction("Edit");
            }
        }

        // GET: MaintWasteApproval/Edit/5
        public ActionResult Edit(int id)
        {
            DataAccessLayer objDb = new DataAccessLayer();

            LandFill_DBContext lfDbContext = new LandFill_DBContext();

             

            var generators = lfDbContext.tblGenerators.ToList();
            var substances = lfDbContext.tblSubstances.ToList();
            var genContacts = lfDbContext.tblGeneratorContacts.ToList();
            var genLocations = lfDbContext.tblGeneratorLocations.ToList();
            var invoicees = lfDbContext.tblInvoiceesDds.ToList();
            var consultant = lfDbContext.tblConsultants.ToList();
            var consultantContact = lfDbContext.tblConsultContacts.ToList();




            var generatorsQuery = from d in generators
                                  orderby d.GeneratorName
                                  select d;

            var substancesQuery = from d in substances
                                  orderby d.SubstanceName
                                  select d;


            var genContactsQuery = from d in genContacts
                                   orderby d.GenerContactName
                                  select d;

            var genLocationsQuery = from d in genLocations
                                    orderby d.GenerLocationLsd
                                   select d;

            var invoiceesQuery = from d in invoicees
                                 orderby d.InvoiceeName
                                    select d;

            var consultantQuery = from d in consultant
                                  orderby d.ConsultantName
                                 select d;
            var consultantContactQuery = from d in consultantContact
                                         orderby d.ConsultantContactName
                                  select d;

            tblMaintWasteApCode wasteAppCodeDetail = objDb.WasteAppCodeSingleGet(id).First();

            ViewData["generatorsNames"] = new SelectList(generatorsQuery, "GeneratorId", "GeneratorName", wasteAppCodeDetail.WApGeneratorId);
            ViewData["substancesNames"] = new SelectList(substancesQuery, "SubstanceId", "SubstanceName", wasteAppCodeDetail.WApSubId);
            ViewData["generatorContactsNames"] = new SelectList(genContactsQuery, "GenerContactId", "GenerContactName", wasteAppCodeDetail.WApGenContactId);
            ViewData["lsdLocationNames"] = new SelectList(genLocationsQuery, "GenerLocationId", "GenerLocationLsd", wasteAppCodeDetail.WApLocationId);            
            ViewData["invoiceerNames"] = new SelectList(invoiceesQuery, "InvoiceeID", "InvoiceeName", wasteAppCodeDetail.WApInvoicee);

            ViewData["ConsultantNames"] = new SelectList(consultantQuery, "ConsultantId", "ConsultantName", wasteAppCodeDetail.WApConsultantId);
            ViewData["ConsultantContactNames"] = new SelectList(consultantContactQuery, "ConsultantContactId", "ConsultantContactName", wasteAppCodeDetail.WApConContactID);

            

            return View(wasteAppCodeDetail);  
        }

        // POST: MaintWasteApproval/Edit/5
        [HttpPost]
        public ActionResult Edit(tblMaintWasteApCode wasteAppCode)
        {

            try
            {


                if (ModelState.IsValid)
                {
                    DataAccessLayer objDb = new DataAccessLayer();


                    // TODO: Add update logic here
                    try
                    {
                        objDb.prgeneratorId = Convert.ToInt32(Request["generatorsNames"]);
                        objDb.prsubstanceId = Convert.ToInt32(Request["substancesNames"]);

                        objDb.prgeneratorContactId = Convert.ToInt32(Request["generatorContactsNames"]);
                        objDb.prlsdId = Convert.ToInt32(Request["lsdLocationNames"]);

                        objDb.prinvoiceId = Convert.ToInt32(Request["invoiceerNames"]);
                        objDb.prconsultantId = Convert.ToInt32(Request["ConsultantNames"]);

                        objDb.prconsultantContactId = Convert.ToInt32(Request["ConsultantContactNames"]);

                        if (wasteAppCode.WApApprovalId == 0)
                            objDb.WasteAppCodeAddNew(wasteAppCode);
                        else
                            objDb.WasteAppCodeUpdate(wasteAppCode);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        return RedirectToAction("Edit");
                    }
                    return RedirectToAction("Details", "MaintWasteApproval" , new { @id = wasteAppCode.WApApprovalId });
                }
                return RedirectToAction("Edit");
            }
            catch
            {
                return View(wasteAppCode);
            }
        }

        // GET: MaintWasteApproval/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MaintWasteApproval/Delete/5
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
