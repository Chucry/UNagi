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
    public class AlumnosController : Controller
    {
        public UNagiDbContext _context = new UNagiDbContext();

        // GET: Alumnos
        public ActionResult Index()
        {
            var viewModel = new AlumnosIndexViewModel();
            return View("_Index", viewModel);
        }

        // GET: Alumnos/Details/5
        public ActionResult Details(int id)
        {
            var viewModel = new AlumnosDetailsViewModel(id);

            return View("_Details", viewModel);
        }

        // GET: Alumnos/Create
        public ActionResult New()
        {
            return View("_NewAlumno");
        }

        // POST: Alumnos/Create
        [HttpPost]
        public ActionResult Create(int matricula, string nombre, string apellido, string contraseña)
        {
            try
            {
                var alumno = new Alumno
                {
                    Matricula = matricula,
                    Nombre = nombre,
                    Apellido = apellido,
                    Contraseña = contraseña
                };

                _context.Alumnos.Add(alumno);
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

        public ActionResult Update(int id, string contraseñaActual, string contraseñaNueva)
        {
            try
            {
                var alumnoInDb = _context.Alumnos.Single(a => a.Id == id);

                if (contraseñaActual == alumnoInDb.Contraseña)
                {
                    alumnoInDb.Contraseña = contraseñaNueva;
                    
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

        // GET: Alumnos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Alumnos/Edit/5
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

        // GET: Alumnos/Delete/5
        public ActionResult Delete(int id)
        {
            var alumno = _context.Alumnos.Single(a => a.Id == id);

            _context.Alumnos.Remove(alumno);
            _context.SaveChanges();

            var json = Json(alumno, JsonRequestBehavior.AllowGet);

            return json;
        }

        // POST: Alumnos/Delete/5
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
