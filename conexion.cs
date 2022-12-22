using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace examen_backend_NOE_FERNANDO
{
    internal class conexion
    {
        public static SqlConnection Conectar()
        {
            SqlConnection cn = new SqlConnection("SERVER=DESKTOP-DGI35DP\\MSSQLSERVER01;DATABASE=USUARIO;integrated security=true");
            cn.Open();
            return cn;
        }
    }
}
