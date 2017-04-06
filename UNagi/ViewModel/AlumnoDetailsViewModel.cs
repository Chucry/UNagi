using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UNagi.Data;
using UNagi.Models;

namespace UNagi.ViewModel
{
    public class AlumnoDetailsViewModel
    {
        public Alumno alumno;
        public UNagiDbContext _context = new UNagiDbContext();

        public AlumnoDetailsViewModel()
        {
            alumno = new Alumno();
        }

        public AlumnoDetailsViewModel(int id)
        {
            alumno = _context.Alumnos.Single(a => a.Id == id);
        }
    }
}