using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalysalsaApi.Models
{
    public class Cliente
    {
        public int id { get; set; }
        public int usuario_id { get; set; }
        public string nombre { get; set; }
        public int correo { get; set; }
    }

}
