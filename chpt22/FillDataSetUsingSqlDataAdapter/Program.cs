using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace FillDataSetUsingSqlDataAdapter
{
    class Program
    {
        static void PrintDataSet(DataSet ds)
        {
            Console.WriteLine($"Dataset is named: {ds.DataSetName}");
            foreach (DictionaryEntry de in ds.ExtendedProperties)
            {
                Console.WriteLine($"Key = {de.Key}, Value = {de.Value}");
            }
            Console.WriteLine();

            foreach (DataTable dt in ds.Tables)
            {
                Console.WriteLine($"=> {dt.TableName} Table: ");

                for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
                {
                    Console.Write(dt.Columns[curCol].ColumnName + "\t");
                }

                Console.WriteLine();

                for (int curRow = 0; curRow < dt.Rows.Count; curRow++)
                {
                    for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
                    {
                        Console.Write(dt.Rows[curRow][curCol].ToString().Trim() + "\t");
                    }
                    Console.WriteLine();
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("*** Fun with Data Adapters ***");

            string connectionString = "Integrated Security=SSPI; Initial Catalog=AutoLot;" + @"Data Source=.\SQLEXPRESS";

            DataSet ds = new DataSet("AutoLot");

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Inventory", connectionString);

            adapter.Fill(ds, "Inventory");

            DataTableMapping tableMapping = adapter.TableMappings.Add("Inventory", "Current Inventory");
            tableMapping.ColumnMappings.Add("CarId", "Car Id");
            tableMapping.ColumnMappings.Add("PetName", "Name of Car");
            //dAdapt    WTF?!        

            PrintDataSet(ds);
            Console.ReadLine();
        }
    }
}
