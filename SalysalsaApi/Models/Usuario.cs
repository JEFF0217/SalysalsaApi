using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalysalsaApi.Models
{
    public class Usuario
    {
        public int id { get; set; }
        public string correo { get; set; }
        public string contraseña { get; set; }
        public bool admin { get; set; }
       
    }
}
