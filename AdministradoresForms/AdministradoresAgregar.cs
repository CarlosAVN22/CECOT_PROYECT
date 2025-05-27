using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CECOT_PROYECT.Resources;
using CECOT_PROYECT.TrabajadoresForms;
using System.Windows.Forms;

namespace CECOT_PROYECT.AdministradoresForms
{
    public class AdministradoresAgregar
    {
        public static int AgregarAdministrador(Administradores admin)
        {
            int retorna = 0; // Inicialmente 0

            try
            {

                using (SqlConnection conexion = new SqlConnection("Server=CRIS;Database=ProyectoCarcelario;Trusted_Connection=true;"))

                {
                    string query = @"INSERT INTO Administradores (Nombre, Apellido, Dui, FechaNacimiento, Género, Telefono, Email, FechaIngreso, Cargo, Departamento, FotoPath) 
                            VALUES (@Nombre, @Apellido, @Dui, @FechaNacimiento, @Género, @Telefono, @Email, @FechaIngreso, @Cargo, @Departamento, @FotoPath)";



                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", admin.Nombre);
                        cmd.Parameters.AddWithValue("@Apellido", admin.Apellido);
                        cmd.Parameters.AddWithValue("@Dui", admin.Dui);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", admin.FechaNacimiento);
                        cmd.Parameters.AddWithValue("@Género", admin.Género);
                        cmd.Parameters.AddWithValue("@Telefono", admin.Telefono);
                        cmd.Parameters.AddWithValue("@Email", admin.Email);
                        cmd.Parameters.AddWithValue("@FechaIngreso", admin.FechaIngreso);
                        cmd.Parameters.AddWithValue("@Cargo", admin.Cargo);
                        cmd.Parameters.AddWithValue("@Departamento", admin.Departamento);
                        cmd.Parameters.AddWithValue("@FotoPath", admin.FotoPath);

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

        public static bool ActualizarAdministrador(Administradores admin)
        {
            bool actualizado = false;
            try
            {

                using (SqlConnection conexion = new SqlConnection("Server=CRIS;Database=ProyectoCarcelario;Trusted_Connection=true;"))

                {
                    string query = @"UPDATE Administradores 
                             SET Nombre = @Nombre,
                                 Apellido = @Apellido,
                                 Dui = @Dui,
                                 FechaNacimiento = @FechaNacimiento,
                                 Género = @Género,
                                 Telefono = @Telefono,
                                 Email = @Email,
                                 FechaIngreso = @FechaIngreso,
                                 Cargo = @Cargo,
                                 Departamento = @Departamento,
                                 FotoPath = @FotoPath
                             WHERE AdministradorID = @AdministradorID";

                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@AdministradorID", admin.AdministradorID);
                        cmd.Parameters.AddWithValue("@Nombre", admin.Nombre);
                        cmd.Parameters.AddWithValue("@Apellido", admin.Apellido);
                        cmd.Parameters.AddWithValue("@DUI", admin.Dui);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", admin.FechaNacimiento);
                        cmd.Parameters.AddWithValue("@Género", admin.Género);
                        cmd.Parameters.AddWithValue("@Telefono", admin.Telefono);
                        cmd.Parameters.AddWithValue("@Email", admin.Email);
                        cmd.Parameters.AddWithValue("@FechaIngreso", admin.FechaIngreso);
                        cmd.Parameters.AddWithValue("@Cargo", admin.Cargo);
                        cmd.Parameters.AddWithValue("@Departamento", admin.Departamento);
                        cmd.Parameters.AddWithValue("@FotoPath", admin.FotoPath);

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



        public static List<Administradores> PresentarRegistros()
        {
            List<Administradores> lista = new List<Administradores>();

            using (SqlConnection conexion = conexionBD.ObtenerConexion())
            {
                string query = "SELECT * FROM Administradores";
                SqlCommand comando = new SqlCommand(query, conexion);
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Administradores admin = new Administradores();
                    admin.AdministradorID = reader.GetInt32(0);
                    admin.Nombre = reader.GetString(1);
                    admin.Apellido = reader.GetString(2);
                    admin.Dui = reader.GetString(3);
                    admin.FechaNacimiento = reader.GetDateTime(4);
                    admin.Género = reader.GetString(5);
                    admin.Telefono = reader.GetString(6);
                    admin.Email = reader.GetString(7);
                    admin.FechaIngreso = reader.GetDateTime(8);
                    admin.Cargo = reader.GetString(9);
                    admin.Departamento = reader.GetString(10);
                    admin.FotoPath = reader.GetString(11);
                    lista.Add(admin);
                }

                conexion.Close();
                return lista;
            }


        }
        public static int EliminarAdministrador(string dui)
        {
            string connectionString = "Server=CRIS;Database=ProyectoCarcelario;Trusted_Connection=true;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Administradores WHERE Dui = @Dui";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Dui", dui);
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }


        public static bool EliminarRegistro(int AdministradorID)
        {
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexion())
                {
                    string query = "DELETE FROM Administradores WHERE AdministradorID = @AdministradorID";
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@AdministradorID", AdministradorID);
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
