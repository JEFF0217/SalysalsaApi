﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalysalsaApi.Models
{
    public class Empleado
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int restaurante_id { get; set; }
        public string img { get; set; }
    }
}
