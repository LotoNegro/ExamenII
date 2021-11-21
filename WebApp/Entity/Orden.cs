using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Orden
    {
        public int? IdOrden { get; set; }
        public int? CantidadProducto { get; set; }
        public string Estado { get; set; }
    }
}