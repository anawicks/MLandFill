using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MLandfill.Controllers
{
    public class GeneratorController : Controller
    {
        // GET: Generator
        public ActionResult Index()
        {
            return View();
        }

        // GET: Generator/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Generator/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Generator/Create
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

        // GET: Generator/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Generator/Edit/5
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

        // GET: Generator/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Generator/Delete/5
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
