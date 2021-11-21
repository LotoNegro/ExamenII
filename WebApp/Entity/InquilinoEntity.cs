using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class InquilinoEntity
    {
        public int? IdEmpleado { get; set; }

        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public int? Edad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public object IdInquilino { get; set; }
    }
}