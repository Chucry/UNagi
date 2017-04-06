using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UNagi.Data;
using UNagi.Models;

namespace UNagi.ViewModel
{
    public class MaestrosDetailsViewModel
    {
        public Maestro maestro { get; set; }
        public UNagiDbContext _context = new UNagiDbContext();

        public MaestrosDetailsViewModel()
        {
            maestro = new Maestro();
        }

        public MaestrosDetailsViewModel(int id)
        {
            maestro = _context.Maestros.Single(m => m.Id == id);
        }
    }
}