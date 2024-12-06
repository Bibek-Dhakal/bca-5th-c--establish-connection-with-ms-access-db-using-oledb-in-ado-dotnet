using System.Data;
using System.Data.OleDb;
using System.Runtime.Versioning;

namespace Establish_Connection_with_MS_ACCESS_DB_using_OLEDB_in_ADO_Dotnet
{
    // API is only supported on Windows
    [SupportedOSPlatform("windows")]
    static class Program
    {
        static void Main()
        {
            Console.Write("Enter the full path to the MS Access database file: ");
            var pathToMsAccessDbFile = Console.ReadLine() ?? string.Empty;
            
            if(pathToMsAccessDbFile.Length == 0)
            {
                Console.WriteLine("Path to MS Access database file is required!");
                return;
            }
            
            // Connection string for MS Access database
            string connectionString =
                "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="
                + pathToMsAccessDbFile + ";";

            try
            {
                // using OLEDB connection
                using var connection = new OleDbConnection(connectionString);
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    Console.WriteLine("Connection successful!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection failed: " + ex.Message);
            }
        }
    }
}