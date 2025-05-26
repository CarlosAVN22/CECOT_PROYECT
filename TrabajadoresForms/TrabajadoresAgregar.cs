using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CECOT_PROYECT.Resources;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace CECOT_PROYECT.TrabajadoresForms
{
    internal class TrabajadoresAgregar
    {
        public static int AgregarTrabajador(Trabajadores trabajador)
        {
            int retorna = 0; // Inicialmente 0

            try
            {

                using (SqlConnection conexion = new SqlConnection("Server=CRIS;Database=ProyectoCarcelario;Trusted_Connection=true;"))

                {
                    string query = @"INSERT INTO Trabajadores (Nombre, Apellido, DUI, FechaNacimiento, Género, Telefono, Email, FechaIngreso, Cargo, Departamento, FotoPath) 
                            VALUES (@Nombre, @Apellido, @DUI, @FechaNacimiento, @Género, @Telefono, @Email, @FechaIngreso, @Cargo, @Departamento, @FotoPath)";



                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", trabajador.Nombre);
                        cmd.Parameters.AddWithValue("@Apellido", trabajador.Apellido);
                        cmd.Parameters.AddWithValue("@DUI", trabajador.DUI);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", trabajador.FechaNacimiento);
                        cmd.Parameters.AddWithValue("@Género", trabajador.Género);
                        cmd.Parameters.AddWithValue("@Telefono", trabajador.Telefono);
                        cmd.Parameters.AddWithValue("@Email", trabajador.Email);
                        cmd.Parameters.AddWithValue("@FechaIngreso", trabajador.FechaIngreso);
                        cmd.Parameters.AddWithValue("@Cargo", trabajador.Cargo);
                        cmd.Parameters.AddWithValue("@Departamento", trabajador.Departamento);
                        cmd.Parameters.AddWithValue("@FotoPath", trabajador.FotoPath);

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

        public static bool ActualizarPersona(Trabajadores trabajador)
        {
            bool actualizado = false;
            try
            {

                using (SqlConnection conexion = new SqlConnection("Server=CRIS;Database=ProyectoCarcelario;Trusted_Connection=true;"))

                {
                    string query = @"UPDATE Trabajadores 
                             SET Nombre = @Nombre,
                                 Apellido = @Apellido,
                                 DUI = @DUI,
                                 FechaNacimiento = @FechaNacimiento,
                                 Género = @Género,
                                 Telefono = @Telefono,
                                 Email = @Email,
                                 FechaIngreso = @FechaIngreso,
                                 Cargo = @Cargo,
                                 Departamento = @Departamento,
                                 FotoPath = @FotoPath
                             WHERE ID = @ID";

                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", trabajador.Nombre);
                        cmd.Parameters.AddWithValue("@Apellido", trabajador.Apellido);
                        cmd.Parameters.AddWithValue("@DUI", trabajador.DUI);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", trabajador.FechaNacimiento);
                        cmd.Parameters.AddWithValue("@Género", trabajador.Género);
                        cmd.Parameters.AddWithValue("@Telefono", trabajador.Telefono);
                        cmd.Parameters.AddWithValue("@Email", trabajador.Email);
                        cmd.Parameters.AddWithValue("@FechaIngreso", trabajador.FechaIngreso);
                        cmd.Parameters.AddWithValue("@Cargo", trabajador.Cargo);
                        cmd.Parameters.AddWithValue("@Departamento", trabajador.Departamento);
                        cmd.Parameters.AddWithValue("@FotoPath", trabajador.FotoPath);

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



        public static List<Trabajadores> PresentarRegistros()
        {
            List<Trabajadores> lista = new List<Trabajadores>();

            using (SqlConnection conexion = conexionBD.ObtenerConexion())
            {
                string query = "SELECT * FROM Trabajadores";
                SqlCommand comando = new SqlCommand(query, conexion);
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Trabajadores trabajador = new Trabajadores();
                    trabajador.TrabajadorID = reader.GetInt32(0);
                    trabajador.Nombre = reader.GetString(1);
                    trabajador.Apellido = reader.GetString(2);
                    trabajador.DUI = reader.GetString(3);
                    trabajador.FechaNacimiento = reader.GetDateTime(4);
                    trabajador.Género = reader.GetString(5);
                    trabajador.Telefono = reader.GetString(6);
                    trabajador.Email = reader.GetString(7);
                    trabajador.FechaIngreso = reader.GetDateTime(8);
                    trabajador.Cargo = reader.GetString(9);
                    trabajador.Departamento = reader.GetString(10);
                    trabajador.FotoPath = reader.GetString(11);
                    lista.Add(trabajador);
                }

                conexion.Close();
                return lista;
            }
            

        }
        public static int EliminarTrabajador(string dui)
        {
            string connectionString = "Server=CRIS;Database=ProyectoCarcelario;Trusted_Connection=true;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Trabajadores WHERE DUI = @DUI";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DUI", dui);
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        

        public static bool EliminarRegistro(int TrabajadorID)
        {
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexion())
                {
                    string query = "DELETE FROM Trabajadores WHERE Id = @TrabajadorID";
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@TrabajadorID", TrabajadorID);
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

