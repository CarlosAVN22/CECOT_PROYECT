using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CECOT_PROYECT.Resources
{
    public class cecotAgregar
    {
        public static int AgregarPersona(Cecot persona)
        {
            int retorna = 0; // Inicialmente 0
            try
            {
                using (SqlConnection conexion = new SqlConnection("Server=AFANEE;Database=CECOT_1;Trusted_Connection=true;"))
                {
                    string query = @"INSERT INTO REOS (Nombre, Edad, Celda, Dui, Cargos, FechaIngreso) 
                             VALUES (@Nombre, @Edad, @Celda, @Dui, @Cargos, @FechaIngreso)";

                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", persona.Nombre);
                        cmd.Parameters.AddWithValue("@Edad", persona.Edad);
                        cmd.Parameters.AddWithValue("@Celda", persona.Celda);
                        cmd.Parameters.AddWithValue("@Dui", persona.Dui);
                        cmd.Parameters.AddWithValue("@Cargos", persona.Cargos);
                        cmd.Parameters.AddWithValue("@FechaIngreso", persona.FechaIngreso);

                        conexion.Open();
                        retorna = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
            }
            return retorna;
        }


        public static List<Cecot> PresentarRegistros()
        {
            List<Cecot> lista = new List<Cecot>();

            using (SqlConnection conexion = conexionBD.ObtenerConexion())
            {
                string query = "SELECT * FROM REOS";
                SqlCommand comando = new SqlCommand(query, conexion);
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Cecot persona = new Cecot();
                    persona.Id = reader.GetInt32(0);
                    persona.Nombre = reader.GetString(1);
                    persona.Edad = reader.GetString(2);
                    persona.Celda = reader.GetString(3);
                    persona.Dui = reader.GetString(4);
                    persona.Cargos = reader.GetString(5);
                    persona.FechaIngreso = reader.GetString(6);
                    lista.Add(persona);
                }

                conexion.Close();
                return lista;
            }


        }

    }
}
