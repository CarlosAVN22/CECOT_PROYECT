using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using CECOT_PROYECT.SeccionesForms;

namespace CECOT_PROYECT.Resources
{
    public class cecotAgregar
    {
        public static int AgregarPersona(Cecot persona)
        {
            int retorna = 0;
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexion())
                {
                    // Validar si la celda existe antes de insertar
                    if (!ExisteCelda(persona.IdCelda, conexion))
                    {
                        MessageBox.Show("La celda con el ID " + persona.IdCelda + " no existe. Inserta una celda válida.");
                        return 0;
                    }

                    string query = @"
                        INSERT INTO Reos 
                        (Nombre, Edad, DUI, FechaIngreso, IdCelda,Delito,Sentencia) 
                        VALUES 
                        (@Nombre, @Edad, @DUI, @FechaIngreso, @IdCelda,@Delito,@Sentencia)";

                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", persona.Nombre);
                        cmd.Parameters.AddWithValue("@Edad", persona.Edad);
                        cmd.Parameters.AddWithValue("@DUI", persona.DUI);                                             
                        cmd.Parameters.AddWithValue("@Delito", persona.Delito);
                        cmd.Parameters.AddWithValue("@Sentencia", persona.Sentencia);
                        cmd.Parameters.AddWithValue("@FechaIngreso", persona.FechaIngreso);
                        cmd.Parameters.AddWithValue("@IdCelda", persona.IdCelda);

                        retorna = cmd.ExecuteNonQuery();
                    }

                    string updateQuery = "UPDATE Celdas SET ReosActuales = ReosActuales + 1 WHERE Id = @IdCelda";
                    ;
                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, conexionBD.ObtenerConexion()))
                    {
                        updateCmd.Parameters.AddWithValue("@IdCelda", persona.IdCelda);
                        updateCmd.ExecuteNonQuery();
                    }
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar: " + ex.Message);
            }
            return retorna;
        }

        // Método para verificar si existe el IdCelda
        private static bool ExisteCelda(int idCelda, SqlConnection conexion)
        {
            string query = "SELECT COUNT(*) FROM Celdas WHERE Id = @IdCelda";
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@IdCelda", idCelda);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public static bool ActualizarPersona(Cecot persona)
        {
            bool actualizado = false;
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexion())
                {
                    if (!ExisteCelda(persona.IdCelda, conexion))
                    {
                        MessageBox.Show("La celda con el ID " + persona.IdCelda + " no existe. No se puede actualizar.");
                        return false;
                    }

                    string query = @"UPDATE Reos 
                                     SET Nombre = @Nombre,
                                     Edad = @Edad,
                                     DUI = @DUI,
                                     FechaIngreso = @FechaIngreso,
                                     IdCelda = @IdCelda,
                                     Delito = @Delito,
                                     Sentencia = @Sentencia,
                                     TipoCelda = @TipoCelda
                                     WHERE Id = @Id";


                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Id", persona.Id);
                        cmd.Parameters.AddWithValue("@Nombre", persona.Nombre);
                        cmd.Parameters.AddWithValue("@Edad", persona.Edad);
                        cmd.Parameters.AddWithValue("@DUI", persona.DUI);                         
                        cmd.Parameters.AddWithValue("@IdCelda", persona.IdCelda);
                        cmd.Parameters.AddWithValue("@Delito", persona.Delito);
                        cmd.Parameters.AddWithValue("@FechaIngreso", persona.FechaIngreso);
                        cmd.Parameters.AddWithValue("@Sentencia", persona.Sentencia);
                        cmd.Parameters.AddWithValue("@TipoCelda", persona.TipoCelda);


                        actualizado = cmd.ExecuteNonQuery() > 0;
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message);
            }
            return actualizado;
        }

        public static List<Cecot> PresentarRegistros()
        {
            List<Cecot> lista = new List<Cecot>();

            using (SqlConnection conexion = conexionBD.ObtenerConexion())
            {

            
            string query = @"
                    SELECT 
                    R.Id,
                    R.Nombre, 
                    R.Edad, 
                    R.DUI, 
                    R.Delito, 
                    R.Sentencia, 
                    R.FechaIngreso, 
                    C.Id AS IdCelda, 
                    S.Tipo AS TipoCelda                    
                    FROM Reos R
                    INNER JOIN Celdas C ON R.IdCelda = C.Id
                    INNER JOIN Secciones S ON C.IdSeccion = S.Id";
                

                SqlCommand comando = new SqlCommand(query, conexion);
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Cecot reo = new Cecot
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Edad = reader.GetInt32(2).ToString(),
                        DUI = reader.GetString(3),
                        Delito = reader.GetString(4),
                        Sentencia = $"{reader.GetString(5)} Años",
                        FechaIngreso = reader.GetDateTime(6).ToShortDateString(),
                        IdCelda = reader.GetInt32(7),
                        TipoCelda=reader.GetString(8)
                    };

                    lista.Add(reo);
                }
                conexion.Close();
            }

            return lista;
        }

        public static bool EliminarRegistro(int idReo)
        {
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexion())
                {
                    

                    // 1. Obtener la celda a la que pertenece el reo
                    int idCelda = 0;
                    string getCeldaQuery = "SELECT IdCelda FROM Reos WHERE Id = @Id";
                    using (SqlCommand cmdGet = new SqlCommand(getCeldaQuery, conexion))
                    {
                        cmdGet.Parameters.AddWithValue("@Id", idReo);
                        object result = cmdGet.ExecuteScalar();
                        if (result == null)
                            return false; 

                        idCelda = Convert.ToInt32(result);
                    }

                    // 2. Eliminar al reo
                    string deleteQuery = "DELETE FROM Reos WHERE Id = @Id";
                    using (SqlCommand cmdDelete = new SqlCommand(deleteQuery, conexion))
                    {
                        cmdDelete.Parameters.AddWithValue("@Id", idReo);
                        int filasAfectadas = cmdDelete.ExecuteNonQuery();
                        if (filasAfectadas == 0)
                            return false; 
                    }

                    // 3. Actualizar la celda (restar un reo)
                    string updateQuery = "UPDATE Celdas SET ReosActuales = ReosActuales - 1 WHERE Id = @IdCelda";
                    using (SqlCommand cmdUpdate = new SqlCommand(updateQuery, conexion))
                    {
                        cmdUpdate.Parameters.AddWithValue("@IdCelda", idCelda);
                        object result = cmdUpdate.ExecuteNonQuery();
                        if (result == null)
                            return false;
                    }

                    return true;
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

