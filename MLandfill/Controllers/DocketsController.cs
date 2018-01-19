﻿using System;
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
    public class DocketsController : Controller
    {
        // GET: Dockets
        public ActionResult Index()
        {
            MDockets objDockets = new MDockets();
            
            DataAccessLayer objDb = new DataAccessLayer();

            List<ModelDockets> AllspDockets = objDb.docketsAllGet().ToList();

            
            return View(AllspDockets);
        }
        public ActionResult GitHubTEST()
        {
            MDockets objDockets = new MDockets();

            DataAccessLayer objDb = new DataAccessLayer();

            List<ModelDockets> AllspDockets = objDb.docketsAllGet().ToList();


            return View(AllspDockets);
        }
        public ActionResult IndexGridMvc()
        {
            MDockets objDockets = new MDockets();

            DataAccessLayer objDb = new DataAccessLayer();

            List<DocketGrid> GridspDockets = objDb.docketsGridGet().ToList();


            return View(GridspDockets);
        }
        // GET: Dockets/Details/5 /Dockets/IndexGridMvc
        public ActionResult Details(int Id= 54068)
        {
            DocketViewModel objDockets = new DocketViewModel();
            
            DataAccessLayer objDb = new DataAccessLayer();
 

            objDockets = objDb.DocketSingleGet(Id);


            return View(objDockets);
        }
        public ActionResult DetailsNew(int Id )
        {
            //DocketViewModel objDockets = new DocketViewModel();

            DataAccessLayer objDb = new DataAccessLayer();

            LandFill_DBContext lfDbContext = new LandFill_DBContext();

            var generatorTypes = lfDbContext.tblGenerators.ToList();
            var substancesTypes = lfDbContext.tblSubstances.ToList();

            var truckCompTypes = lfDbContext.tblTruckCompanies.ToList();

            var genLocations = lfDbContext.tblGeneratorLocations.ToList();

            var wasteApproval = lfDbContext.tblWasteApprovals.ToList();

            var aviewModel = new DocketViewModel
            {

                tblGenerator = generatorTypes,
                ddSubstance = substancesTypes,
                ddTruckCompany = truckCompTypes,
                ddLocations = genLocations,
                ddWasteApproval = wasteApproval

            };

            aviewModel = objDb.DocketSingleGet(Id);


            return View(aviewModel);
        }
        // GET: Dockets/Create

        [HttpGet]
        public ActionResult Create()
        {
            LandFill_DBContext lfDbContext = new LandFill_DBContext();

            var generatorTypes = lfDbContext.tblGenerators.ToList();
            var substancesTypes = lfDbContext.tblSubstances.ToList();

            var truckCompTypes = lfDbContext.tblTruckCompanies.ToList();

            var genLocations = lfDbContext.tblGeneratorLocations.ToList();

            var wasteApproval = lfDbContext.tblWasteApprovals.ToList();

            var aviewModel = new DocketViewModel
            {

                tblGenerator = generatorTypes,
                ddSubstance = substancesTypes,
                ddTruckCompany = truckCompTypes,
                ddLocations = genLocations,
                ddWasteApproval = wasteApproval 

            };
            tblTruckCompany truckModel = new tblTruckCompany();
           
 
            ViewData["TruckCompRec"] = truckModel;

            return View(aviewModel);


             
        }

        // POST: Dockets/Create
        [HttpPost]
        public ActionResult Create(DocketViewModel viewModel)
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

                    objDb.DocketAdd(viewModel);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
         
        public ActionResult CreateDrop(DocketViewModel viewModel)
        {
            LandFill_DBContext lfDbContext = new LandFill_DBContext();

            var generatorTypes = lfDbContext.tblGenerators.ToList();
            var substancesTypes = lfDbContext.tblSubstances.ToList();

            var truckCompTypes = lfDbContext.tblTruckCompanies.ToList();

            var genLocations = lfDbContext.tblGeneratorLocations.ToList();

            var aviewModel = new DocketViewModel
            {

                tblGenerator = generatorTypes,
                ddSubstance = substancesTypes,
                ddTruckCompany = truckCompTypes,
                ddLocations = genLocations

            };


            return View(aviewModel);
        }

 

        // GET: Dockets/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            //DocketViewModel objDockets = new DocketViewModel(); 54095 44776 20468

            
            DataAccessLayer objDb = new DataAccessLayer();

            LandFill_DBContext lfDbContext = new LandFill_DBContext();


            var aviewModel = new DocketViewModel();

            var truckCompany = lfDbContext.tblTruckCompanies.ToList();
            var generators = lfDbContext.tblGenerators.ToList();
            var substances = lfDbContext.tblSubstances.ToList();
            var locations = lfDbContext.tblGeneratorLocations.ToList();
            var wasteAppCodes = lfDbContext.tblWasteDescriptionCodes.ToList();

          

            var trucksQuery = from d in truckCompany
                              orderby d.TruckCompName
                              select d;


            var generatorsQuery = from d in generators  
                              orderby d.GeneratorName
                              select d;

            var substancesQuery = from d in substances
                                  orderby d.SubstanceName
                                  select d;
            var locationsQuery = from d in locations
                                 orderby d.GenerLocationLsd
                                  select d;
            var wasteAppCodesQuery = from d in wasteAppCodes
                                 orderby d.WasteDescription
                                     select d;

            var aviewModelA = new DocketViewModel();

            
            aviewModel = objDb.DocketSingleGet(id);

            ViewData["truckingCompanies"] =   new SelectList(trucksQuery, "TruckCompId", "TruckCompName", aviewModel.TruckCompId);
            ViewData["generatorNames"] = new SelectList(generatorsQuery, "GeneratorId", "GeneratorName", aviewModel.WApGeneratorId) ;
            ViewData["substanceNames"] = new SelectList(substancesQuery, "SubstanceId", "SubstanceName", aviewModel.WApSubId);
            ViewData["locationNames"] = new SelectList(locationsQuery, "GenerLocationId", "GenerLocationLsd", aviewModel.GenerLocationId);
            ViewData["wasteAppCoderNames"] = new SelectList(wasteAppCodesQuery, "WasteDescriptionId", "WasteDescription", aviewModel.GenerLocationId);

            

            tblTruckCompany truckModel = new tblTruckCompany();
            aviewModel.ddTruckCompany = lfDbContext.tblTruckCompanies.ToList();

            /*ViewData["TruckCompRec"] = truckModel*/
            ;
            // tblTruckCompany truckComp = dbContext.tblTruckCompanies.Single(x => x.TruckCompId == id);

            ViewBag.Chapters = new SelectList(trucksQuery.AsEnumerable(), "TruckCompId", "TruckCompName");
            //ViewData["truckingCompaniesNew"] = new SelectList(trucksQuery.AsEnumerable(), "TruckCompId", "TruckCompName");

            ViewData["TruckCompRec"] = truckModel;
 

            return View(aviewModel);
        }
        private void PopulateTruckCompsDropDownList()
        {
            LandFill_DBContext lfDbContext = new LandFill_DBContext();
            var TruckCompany = lfDbContext.tblTruckCompanies.ToList();

            var trucksQuery = from d in TruckCompany
                                   orderby d.TruckCompName
                                   select d;
            ViewBag.truckingCompanies = new SelectList(trucksQuery, "TruckCompId", "TruckCompName");
        }
        // POST: Dockets/Edit/5
        [HttpPost]
        public ActionResult Edit(DocketViewModel docket)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                { 
                    DataAccessLayer objDb = new DataAccessLayer();

                    objDb.DocketUpdate(docket);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Edit");
            }
            catch
            {
                return View(docket);
            }
        }
        [HttpPost]
        public ActionResult Save(DocketViewModel docket)
        {
            try
            {
                

                if (ModelState.IsValid)
                {
                    DataAccessLayer objDb = new DataAccessLayer();


                    // TODO: Add update logic here
                    try
                    { 
                    if (docket.DocketId == 0)
                        objDb.DocketAdd(docket);
                    else
                        objDb.DocketUpdate(docket);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        return RedirectToAction("Edit");
                    }
                    return RedirectToAction("DetailsNew", "Dockets", new { @id = docket.DocketId }); 
                }
                return RedirectToAction("Edit");
            }
            catch
            {
                return View(docket);
            }
        }
        // GET: Dockets/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Dockets/Delete/5
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
        public ActionResult TestColumns()
        {
          

            return View();
        }
        public ActionResult _TruckCompanyDetails(int id)
        {
            
            
            LandFill_DBContext dbContext = new LandFill_DBContext();

            

            

            tblTruckCompany truckComp = dbContext.tblTruckCompanies.Single(x => x.TruckCompId == id);

           

            return View(truckComp);
            
        }

        public ActionResult TryIndex(int id)
        {
            LandFill_DBContext dbContext = new LandFill_DBContext();





            tblTruckCompany truckComp = dbContext.tblTruckCompanies.Single(x => x.TruckCompId == id);



            return View(truckComp);
        }
        public ActionResult TryNewIndex(int id=9)
        {
            LandFill_DBContext dbContext = new LandFill_DBContext();





            tblTruckCompany truckComp = dbContext.tblTruckCompanies.Single(x => x.TruckCompId == id);



            return View(truckComp);
        }
    }
}
