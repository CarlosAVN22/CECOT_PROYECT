using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CECOT_PROYECT.SeccionesForms
{
    internal class BotonesSecciones
    {
        string connectionString = @"Server=CRIS;Database=ProyectoCarcelario;Trusted_Connection=True;";
        public bool CrearSeccion( string tipo, int capacidadCeldas)
        {
            bool resultado = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "INSERT INTO Secciones (Tipo, CapacidadCeldas) VALUES (@tipo, @capacidad)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        
                        cmd.Parameters.AddWithValue("@tipo", tipo);
                        cmd.Parameters.AddWithValue("@capacidad", capacidadCeldas);

                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            resultado = true;
                        }
                    }
                }

                if (resultado)
                {
                    MessageBox.Show("Sección ingresada correctamente.");
                }
                else
                {
                    MessageBox.Show("No se pudo ingresar la sección.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            return resultado;
        }

        public bool EditarSeccion(int id, string tipo, int capacidadCeldas)
        {
            string connectionString = @"Server=CRIS;Database=ProyectoCarcelario;Trusted_Connection=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Secciones SET Tipo = @Tipo, CapacidadCeldas = @Capacidad WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Tipo", tipo);
                    cmd.Parameters.AddWithValue("@Capacidad", capacidadCeldas);
                    cmd.Parameters.AddWithValue("@Id", id);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }

        public bool EliminarSeccion(int id)
        {
            string connectionString = @"Server=CRIS;Database=ProyectoCarcelario;Trusted_Connection=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Secciones WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;

                
            }
        }




    }
}
