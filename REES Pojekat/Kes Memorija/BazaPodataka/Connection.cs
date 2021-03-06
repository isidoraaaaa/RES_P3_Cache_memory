using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaPodataka
{
    [ExcludeFromCodeCoverage]
    public class Connection
    {
        private string ip = "77.105.61.149";
        private static SqlConnection sqlConnection = new SqlConnection();

        public SqlConnection SqlConnection { get => sqlConnection; set => sqlConnection = value; }

        public void OtvoriRemoteKonekciju()
        {
            ZatvoriKonekciju();

            string baseConnectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=CacheMemory;Integrated Security=True";

            try
                {
                    SqlConnection.ConnectionString = baseConnectionString;
                    SqlConnection.Open();
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    Console.WriteLine(ex.Message);
         
                }    
            
        }
        public void ZatvoriKonekciju()
        {
            if (!SqlConnection.Equals(null) && !SqlConnection.State.Equals(System.Data.ConnectionState.Closed))
                SqlConnection.Close();
        }

        public bool ProveriKonekciju()
        {
            bool izlaz = true;
            if (SqlConnection.State.Equals(System.Data.ConnectionState.Closed))
                izlaz = false;
            return izlaz;
        }


    }
}
