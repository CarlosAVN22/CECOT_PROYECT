using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CECOT_PROYECT.CeldasForms
{
  

        public class Celda
        {
            public int Id { get; set; }

            public int IdSeccion { get; set; }
            public string Nombre { get; set; }

            public string Tipo { get; set; }

            public int CapacidadReos { get; set; }

            public int ReosActuales { get; set; }



           public Celda() { }

            public Celda(int ID, string Nombre, string Tipo, int CapacidadCeldas, int CeldasActuales)
            {
                this.Id = ID;
                this.IdSeccion = ID;
                this.Nombre = Nombre;
                this.Tipo = Tipo;
                this.CapacidadReos = CapacidadCeldas;
                this.ReosActuales = CeldasActuales;
            }
        }
}
