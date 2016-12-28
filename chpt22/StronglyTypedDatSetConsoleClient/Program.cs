using System;
using System.Configuration;
using DataGridViewDesigner.DataSets;
using DataGridViewDesigner.InventoryDataSetTableAdapters;
using System.Data.SqlClient;

namespace StronglyTypedDatSetConsoleClient
{
    class Program
    {
        static void PrintInventory(AutoLotDataSet.InventoryDataTable dt)
        {
            for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
            {
                Console.Write(dt.Columns[curCol].ColumnName + "\t");
            }
            Console.WriteLine();

            for (int curRow = 0; curRow < dt.Rows.Count; curRow++)
            {
                for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
                {
                    Console.Write(dt.Rows[curRow][curCol] + "\t");
                }
                Console.WriteLine();
            }
        }

        static void AddRecords(AutoLotDataSet.InventoryDataTable table)
        {
            try
            {
                AutoLotDataSet.InventoryRow newRow = table.NewInventoryRow();

                newRow.Color = "Purple";
                newRow.Make = "Mercedes";
                newRow.PetName = "Saku";

                table.AddInventoryRow(newRow);

                table.AddInventoryRow("Renault", "Sand", "Duster");
            }
            
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("*** Fun with Strongly Typed DataSets ***");

            string connectionString = "Integrated Security=SSPI; Initial Catalog=AutoLot;" + @"Data Source=.\SQLEXPRESS";

            var table = new AutoLotDataSet.InventoryDataTable();

            var adapter = new SqlDataAdapter("SELECT * FROM Inventory", connectionString);

            //покдлючается к строке в библиотеке, но говорит о невозможности преобразования данных использую Fill, приходится добавлять строку вручную
            //var adapter = new InventoryTableAdapter();

            adapter.Fill(table);

            PrintInventory(table);

            AddRecords(table);

            Console.WriteLine();

            PrintInventory(table);

            Console.ReadKey();
        }
    }
}
