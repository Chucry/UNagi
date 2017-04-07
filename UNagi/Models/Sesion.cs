using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UNagi.Models
{
    public enum TipoUsuario
    {
        Alumno,
        Maestro
    }

    public class Sesion
    {
        public TipoUsuario Usuario;

        public int Id;
    }
}