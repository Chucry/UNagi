using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UNagi.Data;
using UNagi.Models;

namespace UNagi.ViewModel
{
    public class AlumnosDetailsViewModel
    {
        public Alumno alumno;
        public UNagiDbContext _context = new UNagiDbContext();

        public AlumnosDetailsViewModel()
        {
            alumno = new Alumno();
        }

        public AlumnosDetailsViewModel(int id)
        {
            alumno = _context.Alumnos.Single(a => a.Id == id);
        }
    }
}