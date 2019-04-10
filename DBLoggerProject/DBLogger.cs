using AppInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLoggerProject
{ 
    [Export(typeof(ILogger))]
    public class DBLogger : ILogger
    {
        public void Log(string message)
        {
            string connectionString = "Data Source=DESKTOP-1B7KRH0\\SQLEXPRESS;Initial Catalog=TPA;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
            string queryString = "insert into[tpa].[dbo].[LOG] values(sysdatetime(), @message)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@message", message));
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
