using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UNagi.Data;
using UNagi.Models;

namespace UNagi.ViewModel
{
    public class AlumnoIndexViewModel
    {
        public List<Alumno> Alumnos { get; set; }
        public UNagiDbContext _context = new UNagiDbContext();

        public AlumnoIndexViewModel()
        {
            Alumnos = new List<Alumno>();
            Alumnos = _context.Alumnos.ToList();
        }
    }
}