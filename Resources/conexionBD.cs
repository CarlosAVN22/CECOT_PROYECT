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

            SqlConnection connectionString = new SqlConnection("Server=DESKTOP-BPP96GF;Database=CECOT_1;Trusted_Connection=true;");
           connectionString.Open();
            return connectionString;

        }

        
     


    }
}
