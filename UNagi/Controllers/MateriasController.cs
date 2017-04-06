using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UNagi.Data;
using UNagi.ViewModel;

namespace UNagi.Controllers
{
    public class MateriasController : Controller
    {
        public UNagiDbContext _context = new UNagiDbContext();

        // GET: Materias
        public ActionResult Index()
        {
            var viewModel = new MateriasIndexViewModel();
            return View("_Index", viewModel);
        }

        // GET: Materias/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Materias/Create
        public ActionResult New()
        {
            return View("_NewMateria");
        }

        // POST: Materias/Create
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

        // GET: Materias/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Materias/Edit/5
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

        // GET: Materias/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Materias/Delete/5
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
