using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UNagi.Models
{
    [Table("Materias")]
    public class Materia
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Nombre { get; set; }

        public List<Maestro> Maestros { get; set; }

        public List<Alumno> Alumnos { get; set; }
    }
}