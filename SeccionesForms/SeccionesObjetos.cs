using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CECOT_PROYECT.SeccionesForms
{
  

        public class Seccion
        {
            public int Id { get; set; }
            public string Nombre { get; set; }

            public string Tipo { get; set; }

            public int CapacidadCeldas { get; set; }

            public int CeldasActuales { get; set; }



           public Seccion() { }

            public Seccion(int ID, string Nombre, string Tipo, int CapacidadCeldas, int CeldasActuales)
            {
                this.Id = ID;
                this.Nombre = Nombre;
                this.Tipo = Tipo;
                this.CapacidadCeldas = CapacidadCeldas;
                this.CeldasActuales = CeldasActuales;
            }
        }
}
