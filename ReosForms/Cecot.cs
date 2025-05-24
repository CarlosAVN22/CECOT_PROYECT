namespace CECOT_PROYECT.Resources
{
    public class Cecot
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Edad { get; set; }
        public int IdCelda { get; set; }

        public string DUI { get; set; }

        public string FechaIngreso { get; set; }

        public Cecot() { }

        public Cecot(int id, string nombre, string edad, string dui, string fechaIngreso)
        {
            Id = id;
            Nombre = nombre;
            DUI = dui;
            FechaIngreso = fechaIngreso;
        }
    }
}


