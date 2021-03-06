﻿using System;
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

            Materias = _context.Materias.ToList();

        }
    }
}