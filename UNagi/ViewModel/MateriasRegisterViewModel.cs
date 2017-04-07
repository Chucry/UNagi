using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UNagi.Data;
using UNagi.Models;

namespace UNagi.ViewModel
{
    public class MateriasRegisterViewModel
    {
        public Alumno Alumno = new Alumno();
        public List<Materia> Materias { get; set; }
        public UNagiDbContext _context = new UNagiDbContext();

        public MateriasRegisterViewModel(int id)
        {
            var alumno = _context.Alumnos.Single(a => a.Id == id);

            Materias = new List<Materia>();
            //materias inscritas
            Materias = _context.Materias.SqlQuery(
@"SELECT m.Id, m.Nombre, ma.Alumno_Id FROM Materias m
JOIN MateriaAlumnoes ma
ON ma.Materia_Id = m.Id
WHERE ma.Alumno_Id = " + alumno.Id + ";").ToList();

            Materias = _context.Materias.SqlQuery(
@"SELECT * FROM Materias
WHERE m.Id NOT IN (SELECT m.Id, m.Nombre, ma.Alumno_Id FROM Materias m
JOIN MateriaAlumnoes ma
ON ma.Materia_Id = m.Id
WHERE ma.Alumno_Id = " + alumno.Id + ";").ToList();
        }
    }
}