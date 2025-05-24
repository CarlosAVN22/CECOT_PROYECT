using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CECOT_PROYECT.Resources;

namespace CECOT_PROYECT.CeldasForms
{
    internal class FuncionesSQLCeldas
    {

        public static List<Celda> PresentarRegistros()
        {
            List<Celda> lista = new List<Celda>();

            using (SqlConnection conexion = conexionBD.ObtenerConexion())
            {
                string query = @"
            SELECT 
                C.Id, 
                C.IdSeccion, 
                C.CapacidadReos, 
                C.ReosActuales, 
                S.Nombre, 
                S.Tipo
                FROM 
                Celdas C
                INNER JOIN 
                Secciones S ON C.IdSeccion = S.Id";

                SqlCommand comando = new SqlCommand(query, conexion);
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Celda celda = new Celda();
                    celda.Id = reader.GetInt32(0);
                    celda.IdSeccion = reader.GetInt32(1);
                    celda.CapacidadReos = reader.GetInt32(2);
                    celda.ReosActuales = reader.GetInt32(3);
                    celda.Nombre = reader.GetString(4);  // Nombre de la sección
                    celda.Tipo = reader.GetString(5);    // Tipo de la sección

                    lista.Add(celda);
                }

                conexion.Close();
            }

            return lista;
        }

    }
}

