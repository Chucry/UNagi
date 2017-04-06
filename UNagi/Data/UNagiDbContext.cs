using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UNagi.Models;

namespace UNagi.Data
{
    public class UNagiDbContext : DbContext
    {
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Maestro> Maestros { get; set; }
        public DbSet<Materia> Materias { get; set; }
    }
}