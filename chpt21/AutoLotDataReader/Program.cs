using System;
using System.Data;
using System.Data.SqlClient;

namespace AutoLotDataReader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Fun with data Readers ***");

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=.\SQLEXPRESS; Integrated Security=SSPI;" + "Initial Catalog=AutoLot";
                connection.Open();

                string sql = "Select * from Inventory";
                SqlCommand myCommand = new SqlCommand(sql, connection);

                using (SqlDataReader dataReader = myCommand.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Console.WriteLine("*** Record ***");
                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            //Console.WriteLine($"-> Make: {dataReader["Make"]}, PetName: {dataReader["PetName"]}, Color: {dataReader["Color"]}.");
                            Console.WriteLine($"{dataReader.GetName(i)} = {dataReader.GetValue(i)}");
                        }
                        Console.WriteLine();
                    }
                }
                Console.ReadLine();
            }
        }
    }
}
