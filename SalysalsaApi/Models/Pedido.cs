using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalysalsaApi.Models
{
    public class Pedido
    {
        public int id { get; set; }
        public int cliente_id { get; set; }
        public DateTime fecha { get; set; }
    }
   
}
