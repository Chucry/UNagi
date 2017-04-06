using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UNagi.Data;
using UNagi.Models;

namespace UNagi.ViewModel
{
    public class MaestrosIndexViewModel
    {
        public List<Maestro> Maestros { get; set; }
        public UNagiDbContext _context = new UNagiDbContext();

        public MaestrosIndexViewModel()
        {
            Maestros = new List<Maestro>();
            Maestros = _context.Maestros.ToList();
        }
    }
}