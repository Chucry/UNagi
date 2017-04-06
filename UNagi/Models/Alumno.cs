using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.Expressions;

namespace UNagi.Models
{
    [Table("Alumnos")]
    public class Alumno
    {
        [Key]
        [Column(Order=1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        [Column(Order=2)]
        public int Matricula { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }

        [Required]
        [RegularExpression("^([a-zA-Z0-9]{8,})$")]
        public string Contraseña { get; set; }

        public List<Materia> Materias { get; set; }
    }
}