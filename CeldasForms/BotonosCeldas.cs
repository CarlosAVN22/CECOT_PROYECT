using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CECOT_PROYECT.CeldasForms
{
    internal class BotonosCeldas
    {

        string connectionString = @"Server=DESKTOP-42P3LD3\SQLEXPRESS;Database=ProyectoCarcelario;Trusted_Connection=True;";
        public bool CrearCelda(int idSeccion, int capacidadReos)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Primero verificamos la capacidad de la sección
                string verificarQuery = "SELECT CapacidadCeldas, CeldasActuales FROM Secciones WHERE Id = @idSeccion";
                using (SqlCommand verificarCmd = new SqlCommand(verificarQuery, conn))
                {
                    verificarCmd.Parameters.AddWithValue("@idSeccion", idSeccion);
                    SqlDataReader reader = verificarCmd.ExecuteReader();

                    if (reader.Read())
                    {
                        int capacidad = (int)reader["CapacidadCeldas"];
                        int actuales = (int)reader["CeldasActuales"];
                        reader.Close();

                        if (actuales < capacidad)
                        {
                            // Insertar celda
                            string insertQuery = "INSERT INTO Celdas (IdSeccion, CapacidadReos) VALUES (@idSeccion, @capacidadReos)";
                            using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@idSeccion", idSeccion);
                                insertCmd.Parameters.AddWithValue("@capacidadReos", capacidadReos);
                                insertCmd.ExecuteNonQuery();
                            }

                            // Actualizar la cantidad de celdas actuales en la sección
                            string updateQuery = "UPDATE Secciones SET CeldasActuales = CeldasActuales + 1 WHERE Id = @idSeccion";
                            using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                            {
                                updateCmd.Parameters.AddWithValue("@idSeccion", idSeccion);
                                updateCmd.ExecuteNonQuery();
                            }

                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
