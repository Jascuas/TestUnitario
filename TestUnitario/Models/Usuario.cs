using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestUnitario.Models
{
    public class Usuario
    {
        public int IdUser { get; set; }
        public String Nombre { get; set; }
        public String Apellidos { get; set; }
        public String Contraseña { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}