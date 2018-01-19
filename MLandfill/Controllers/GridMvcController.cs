using MLandfill.Models;
 
using System.Web.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 
using MLandfill.Core.Domain;
using MLandfill.DataAccess;
 
 

namespace MLandfill.Controllers
{
    public class GridMvcController : Controller
    {
     

        // GET: GridMvc
        public ActionResult Index()
        {
            MDockets objDockets = new MDockets();

            DataAccessLayer objDb = new DataAccessLayer();

            List<ModelDockets> AllspDockets = objDb.docketsAllGet().ToList();


            return View(AllspDockets);
            
        }

        // GET: GridMvc/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GridMvc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GridMvc/Create
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

        // GET: GridMvc/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GridMvc/Edit/5
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

        // GET: GridMvc/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GridMvc/Delete/5
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
