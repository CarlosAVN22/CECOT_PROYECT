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
                using (SqlConnection conexion = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=CECOT_1;Data Source=DESKTOP-42P3LD3\\SQLEXPRESS"))
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
                        retorna = cmd.ExecuteNonQuery(); // Devuelve el número de filas afectadas
                    }
                }
            }
            catch (Exception ex)
            {
                // Aquí podrías registrar el error o lanzar una excepción personalizada
                MessageBox.Show("Error: " + ex.Message);
            }
            return retorna; // Si todo va bien, retornará > 0
        }
    }

        
    
}
