using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalysalsaApi.Models
{
    public class Comentario
    {
        public int id { get; set; }
        public string comentario { get; set; }
        public int usuario_id { get; set; }
  
    }
}
