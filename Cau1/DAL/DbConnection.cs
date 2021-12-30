using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau1.DAL
{
    public class DbConnection
    {
        public DbConnection() { }
        public SqlConnection CreateConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP-AI5919B\MSSQLSERVER01; Initial Catalog=HR; User Id=sa; Password=sa";
            return conn;
        }
    }
}
