using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotDAL.ConnectedLayer;
using System.Configuration;
using System.Data;


namespace AutoLotCUIClient
{
    class Program
    {
        private static void InsertNewAuto(InventoryDAL invDAL)
        {
            Console.Write("Enter ID of Car: ");
            int id = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Enter Color of Car: ");
            var color = Console.ReadLine();
            Console.Write("Enter Make of Car: ");
            var make = Console.ReadLine();
            Console.Write("Enter PetName of Car: ");
            var petName = Console.ReadLine();

            invDAL.InsertAuto(id, color, make, petName);
        }

        private static void LookUpPetName(InventoryDAL invDAL)
        {
            Console.Write("Enter ID of Car to look up: ");
            int id = int.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine($"PetName of {id} is {invDAL.LookUpPetName(id).TrimEnd()}.");
        }

        private static void ListInventory(InventoryDAL invDAL)
        {
            DataTable dt = invDAL.GetAllInventotyAsDataTable();
            DisplayTable(dt);
        }

        private static void DisplayTable(DataTable dt)
        {
            for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
            {
                Console.Write($"{dt.Columns[curCol].ColumnName}\t");
            }
            Console.WriteLine();

            for (int curRow = 0; curRow < dt.Rows.Count; curRow++)
            {
                for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
                {
                    Console.Write($"{dt.Rows[curRow][curCol]}\t");
                }
                Console.WriteLine();
            }
        }

        private static void DeleteCar(InventoryDAL invDAL)
        {
            Console.Write("Enter ID of Car to delete: ");
            int id = int.Parse(Console.ReadLine()??"0");

            try
            {
                invDAL.DeleteCar(id);
            }
            catch(Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        private static void UpdateCarPetName(InventoryDAL invDAL)
        {
            Console.Write("Enter ID of Car: ");
            int id = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Enter new PetName: ");
            var newCarPetName = Console.ReadLine();

            invDAL.UpdateCarPetName(id, newCarPetName);
        }

        private static void ShowInstructions()
        {
            Console.WriteLine("I: Inserts a new car.");
            Console.WriteLine("U: Updates an existing car.");
            Console.WriteLine("D: Deletes an existing car.");
            Console.WriteLine("L: List current inventory.");
            Console.WriteLine("S: Shows this instructions.");
            Console.WriteLine("P: Looks up PetName.");
            Console.WriteLine("Q: Quits program.");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("*** The AutoLot Console UI ***");

            string connectionString = ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString;
            bool userDone = false;
            string userCommand = "";

            InventoryDAL invDAL = new InventoryDAL();
            invDAL.OpenConnection(connectionString);

            try
            {
                ShowInstructions();

                do
                {
                    Console.WriteLine("Please, enter your command: ");
                    userCommand = Console.ReadLine();
                    Console.WriteLine();

                    switch (userCommand?.ToUpper() ?? "")
                    {
                        case "I":
                            InsertNewAuto(invDAL);
                            break;
                        case "U":
                            UpdateCarPetName(invDAL);
                            break;
                        case "D":
                            DeleteCar(invDAL);
                            break;
                        case "L":
                            ListInventory(invDAL);
                            break;
                        case "S":
                            ShowInstructions();
                            break;
                        case "P":
                            LookUpPetName(invDAL);
                            break;
                        case "Q":
                            userDone = true;
                            break;
                        default:
                            Console.WriteLine("Bad data! Try again");
                            break;
                    }
                } while (!userDone);
            }
            catch(Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            finally
            {
                invDAL.CloseConnection();
            }
        }

    }
}
