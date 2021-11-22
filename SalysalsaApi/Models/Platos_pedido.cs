using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalysalsaApi.Models
{
    public class Platos_pedido
    {
        public int pedido_id { get; set;}
        public int plato_id { get; set; }
        public int cantidad { get; set; }

    }
}
