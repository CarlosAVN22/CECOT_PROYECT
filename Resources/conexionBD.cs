using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CECOT_PROYECT.Resources
{
    public class conexionBD
    {
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection conn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=CECOT_1;Data Source=DESKTOP-42P3LD3\\SQLEXPRESS");
            conn.Open();
            return conn;

        }

        
     


    }
}
