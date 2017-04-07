using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UNagi.Data;
using UNagi.Models;

namespace UNagi.ViewModel
{
    public class MateriasListViewModel
    {
        public Alumno Alumno = new Alumno();
        public UNagiDbContext _context = new UNagiDbContext();
        public List<Materia> Materias;

        public MateriasListViewModel(int id)
        {
            var alumno = _context.Alumnos.Single(a => a.Id == id);
            Materias = _context.Materias.SqlQuery(
@"SELECT m.Id, m.Nombre, ma.Alumno_Id FROM Materias m
JOIN MateriaAlumnoes ma
ON ma.Materia_Id = m.Id
WHERE ma.Alumno_Id = " + alumno.Id + ";")
                .ToList();
        }
    }
}