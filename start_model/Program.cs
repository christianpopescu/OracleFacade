using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Dapper;

namespace SandboxOracle
{
    class Program
    {
        static void Main(string[] args)
        {

            string conString = @"Data Source=(DESCRIPTION =  (ADDRESS=(PROTOCOL=tcp)(HOST=host)(PORT=1000))   (CONNECT_DATA=(SERVICE_NAME=ORADB)));User Id=USER; password=PASSWORD;"; 

            DbProviderFactory factory =
           DbProviderFactories.GetFactory("Oracle.ManagedDataAccess.Client");

            using (DbConnection conn = factory.CreateConnection())
            {
                conn.ConnectionString = conString;
                try
                {
                    conn.Open();
                    string query = "select NAME,AGE from trade";
                    var answer = conn.Query<PersonDto>(query).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
            }

        }
    }
}
