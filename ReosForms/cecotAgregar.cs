using System;
using System.Collections;
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

<<<<<<< Updated upstream
               using (SqlConnection conexion = new SqlConnection("Server=DESKTOP-42P3LD3\\SQLEXPRESS;Database=CECOT_1;Trusted_Connection=true;"))
=======
               using (SqlConnection conexion = new SqlConnection("Server=DESKTOP-BPP96GF;Database=CECOT_1;Trusted_Connection=true;"))
>>>>>>> Stashed changes
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

        public static bool ActualizarPersona(Cecot persona)
        {
            bool actualizado = false;
            try
            {

<<<<<<< Updated upstream
                using (SqlConnection conexion = new SqlConnection("Server=DESKTOP-42P3LD3\\SQLEXPRESS;Database=CECOT_1;Trusted_Connection=true;"))
=======
                using (SqlConnection conexion = new SqlConnection("Server=DESKTOP-BPP96GF;Database=CECOT_1;Trusted_Connection=true;"))
>>>>>>> Stashed changes
                {
                    string query = @"UPDATE REOS 
                             SET Nombre = @Nombre,
                                 Edad = @Edad,
                                 Celda = @Celda,
                                 Dui = @Dui,
                                 Cargos = @Cargos,
                                 FechaIngreso = @FechaIngreso
                             WHERE ID = @ID";

                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@ID", persona.Id);
                        cmd.Parameters.AddWithValue("@Nombre", persona.Nombre);
                        cmd.Parameters.AddWithValue("@Edad", persona.Edad);
                        cmd.Parameters.AddWithValue("@Celda", persona.Celda);
                        cmd.Parameters.AddWithValue("@Dui", persona.Dui);
                        cmd.Parameters.AddWithValue("@Cargos", persona.Cargos);
                        cmd.Parameters.AddWithValue("@FechaIngreso", persona.FechaIngreso);

                        conexion.Open();
                        int filaafectado = cmd.ExecuteNonQuery();
                        actualizado = filaafectado > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return actualizado;
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

        public static bool EliminarRegistro(int idReo)
        {
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexion())
                {
                    string query = "DELETE FROM REOS WHERE Id = @idReo";
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@idReo", idReo);
                        int filasAfectadas = comando.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
                return false;
            }
        }


    }
}
