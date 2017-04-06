using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UNagi.Data;

namespace UNagi.Controllers
{
    public class HomeController : Controller
    {
        public UNagiDbContext _context = new UNagiDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignIn()
        {

            return View("_SignIn");
        }

        public ActionResult SignInAlumno(int matricula, string contraseña)
        {
            try
            {
                var alumno = _context.Alumnos.Single(m => m.Matricula == matricula);

                if (alumno.Contraseña == contraseña)
                {
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

        public ActionResult SignInMaestro(string email, string contraseña)
        {
            try
            {
                var maestro = _context.Maestros.Single(m => m.Email == email);

                if (maestro.Contraseña == contraseña)
                {
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

        public ActionResult Author()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}