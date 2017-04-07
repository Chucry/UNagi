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
        public ActionResult Create(int id, string contraseña, string nombre)
        {
            try
            {
                var maestro = _context.Maestros.Single(m => m.Id == id);

                if (maestro.Contraseña == contraseña)
                {
                    var materia = new Materia
                    {
                        Nombre = nombre
                    };

                    _context.Materias.Add(materia);
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

        public ActionResult Register()
        {
            var id = HomeController._sesion.Id;
            var viewModel = new MateriasRegisterViewModel(id);
            return View("_Register", viewModel);
        }

        [HttpPost]
        public ActionResult SignUp(int idAlumno, string idMateria)
        {
            try
            {
                var alumno = _context.Alumnos.Single(a => a.Id == idAlumno);
                var materia = _context.Materias.Single(m => m.Nombre == idMateria);

                alumno.Materias.Add(materia);

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
