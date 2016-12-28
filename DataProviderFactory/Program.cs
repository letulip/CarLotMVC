using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace DataProviderFactory
{
    class Program
    {
        private static void ShowError (string objectName)
        {
            Console.WriteLine($"There was an issue creating the {objectName}");
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("*** Fun with data Provider Factories ***");
            string dataProvider = ConfigurationManager.AppSettings["provider"];
            //string connectionString = ConfigurationManager.AppSettings["connectionString"];
            string connectionString = ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString;

            DbProviderFactory factory = DbProviderFactories.GetFactory(dataProvider);

            using (DbConnection connection = factory.CreateConnection())
            {
                if (connection == null)
                {
                    ShowError("connection");
                    return;
                }
                Console.WriteLine($"Your connection object is a: {connection.GetType().Name}");
                connection.ConnectionString = connectionString;
                connection.Open();

                var sqlConnection = connection as SqlConnection;
                if (sqlConnection != null)
                {
                    Console.WriteLine(sqlConnection.ServerVersion);
                }

                DbCommand command = factory.CreateCommand();
                if (command == null)
                {
                    ShowError("command");
                    return;
                }
                Console.WriteLine($"Your command object is a: {command.GetType().Name}");
                command.Connection = connection;
                command.CommandText = "Select * from Inventory";

                using (DbDataReader dataReader = command.ExecuteReader())
                {
                    Console.WriteLine($"Your data reader object is a: {dataReader.GetType().Name}");
                    Console.WriteLine("*** Current Inventory ***");
                    while (dataReader.Read())
                    {
                        Console.WriteLine($"-> Car #{dataReader["CarId"]} is a {dataReader["Make"]}.");
                    }
                }
                Console.ReadLine();
            }
        }
    }
}
