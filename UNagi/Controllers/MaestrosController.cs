using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UNagi.Data;
using UNagi.Models;
using UNagi.ViewModel;

namespace UNagi.Controllers
{
    public class MaestrosController : Controller
    {
        public UNagiDbContext _context = new UNagiDbContext();

        // GET: Maestros
        public ActionResult Index()
        {
            var viewModel = new MaestrosIndexViewModel();
            return View("_Index", viewModel);
        }

        // GET: Maestros/Details/5
        public ActionResult Details(int id)
        {
            var viewModel = new MaestrosDetailsViewModel(Convert.ToInt32(id));

            return View("_Details", viewModel);
        }

        // GET: Maestros/Create
        public ActionResult New()
        {
            return View("_NewMaestro");
        }

        // POST: Maestros/Create
        [HttpPost]
        public ActionResult Create(string email, string nombre, string apellido, string contraseña)
        {
            try
            {
                var maestro = new Maestro()
                {
                    Email = email,
                    Nombre = nombre,
                    Apellido = apellido,
                    Contraseña = contraseña
                };

                _context.Maestros.Add(maestro);
                _context.SaveChanges();

                var json = Json(true);
                return json;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                var json = Json(false);
                return json;
            }
        }

        // GET: Maestros/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Maestros/Edit/5
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

        [HttpPost]
        public ActionResult Update(int id, string contraseñaActual, string contraseñaNueva)
        {
            try
            {
                var maestroInDb = _context.Maestros.Single(m => m.Id == id);

                if (contraseñaActual == maestroInDb.Contraseña)
                {
                    maestroInDb.Contraseña = contraseñaNueva;
                    
                    _context.SaveChanges();

                    var json = Json(true);
                    return json;
                }
                else
                {
                    var json = Json(false);
                    return json;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);

                var json = Json(false);
                return json;
            }
        }

        // GET: Maestros/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Maestros/Delete/5
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
