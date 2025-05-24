using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CECOT_PROYECT.Resources;

namespace CECOT_PROYECT.SeccionesForms
{
    internal class FuncionesSQL
    {

        public static List<Seccion> PresentarRegistros()
        {
            List<Seccion> lista = new List<Seccion>();

            using (SqlConnection conexion = conexionBD.ObtenerConexion())
            {
                string query = "SELECT * FROM Secciones";
                SqlCommand comando = new SqlCommand(query, conexion);
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Seccion seccion = new Seccion();
                    seccion.Id = reader.GetInt32(0);
                    seccion.Nombre = reader.GetString(1);
                    seccion.Tipo = reader.GetString(2);
                    seccion.CapacidadCeldas = reader.GetInt32(3);
                    seccion.CeldasActuales = reader.GetInt32(4);
                    lista.Add(seccion);
                }

                conexion.Close();
                return lista;
            }
        }
    }
}
