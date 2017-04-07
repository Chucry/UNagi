using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UNagi.Data;
using UNagi.Models;

namespace UNagi.Controllers
{
    public class HomeController : Controller
    {
        public static Sesion _sesion = new Sesion();

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
                    _sesion.Id = alumno.Id;
                    _sesion.Usuario = TipoUsuario.Alumno;

                    var json = Json(alumno, JsonRequestBehavior.AllowGet);
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
                    _sesion.Id = maestro.Id;
                    _sesion.Usuario = TipoUsuario.Maestro;

                    var json = Json(maestro, JsonRequestBehavior.AllowGet);
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

        public ActionResult SignOut()
        {
            _sesion = new Sesion();

            var json = Json(true);
            return json;
        }
    }
}