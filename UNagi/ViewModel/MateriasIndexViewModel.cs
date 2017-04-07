using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UNagi.Data;
using UNagi.Models;

namespace UNagi.ViewModel
{
    public class MateriasIndexViewModel
    {
        public int id;
        public List<Materia> Materias { get; set; }
        public UNagiDbContext _context = new UNagiDbContext();

        public MateriasIndexViewModel()
        {
            Materias = new List<Materia>();
            Materias = _context.Materias.ToList();
        }
    }
}