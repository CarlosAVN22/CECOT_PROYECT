using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CECOT_PROYECT.Resources
{
    public class Cecot
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Edad { get; set; }

        public string Celda { get; set; }

        public string Dui { get; set; }

        public string Cargos { get; set; }

        public string FechaIngreso { get; set; }


        public Cecot() { }

        public Cecot(int ID, string Nombre, string Edad, string Celda, string Dui, string Cargos, string FechaIngreso)
        {
            this.Id = ID;
            this.Nombre = Nombre;
            this.Edad = Edad;
            this.Celda = Celda;
            this.Dui = Dui;
            this.Cargos = Cargos;
            this.FechaIngreso = FechaIngreso;
        }

    }
}
