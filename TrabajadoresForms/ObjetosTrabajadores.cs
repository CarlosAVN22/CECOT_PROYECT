using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CECOT_PROYECT.TrabajadoresForms
{
    
        public class Trabajadores
        {
            public int TrabajadorID { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string DUI { get; set; }
            public DateTime FechaNacimiento { get; set; }
            public string Género { get; set; }
            public string Telefono { get; set; }
            public string Email { get; set; }
            public DateTime FechaIngreso { get; set; }
            public string Cargo { get; set; }
            public string Departamento { get; set; }
            public string FotoPath { get; set; }
        }
    }


