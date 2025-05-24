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
        public bool CrearSeccion(string nombre, string tipo, int capacidadCeldas)
        {
            bool resultado = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "INSERT INTO Secciones (Nombre, Tipo, CapacidadCeldas) VALUES (@nombre, @tipo, @capacidad)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
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


    }
}
