using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using ConnectedLayer;

namespace AutoLotDAL.ConnectedLayer
{
    public class InventoryDAL
    {
        public InventoryDAL()
        {

        }

        private SqlConnection _sqlConnection = null;

        public void OpenConnection (string connectionString)
        {
            _sqlConnection = new SqlConnection { ConnectionString = connectionString };
            _sqlConnection.Open();
        }

        public void CloseConnection()
        {
            _sqlConnection.Close();
        }

        public void InsertAuto (int id, string color, string make, string petName)
        {
            //Initial version
            //string sql = "INSERT INTO Inventory" + $"(Make, Color, PetName) VALUES ('{make}', '{color}', '{petName}')";

            //using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            //{
            //    command.ExecuteNonQuery();
            //}


            //Reworking version
            string sql = "INSERT INTO Inventory (Make, Color, PetName) VALUES (@Make, @Color, @PetName)";

            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = "@Make",
                    Value = make,
                    SqlDbType = SqlDbType.Char,
                    Size = 10
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@Color",
                    Value = color,
                    SqlDbType = SqlDbType.Char,
                    Size = 10
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@PetName",
                    Value = petName,
                    SqlDbType = SqlDbType.Char,
                    Size = 10
                };
                command.Parameters.Add(parameter);

                command.ExecuteNonQuery();
            }
        }

        public void InsertAuto (NewCar car)
        {
            string sql = "INSERT INTO Inventory" + $"(Make, Color, PetName) VALUES ('{car.Make}', '{car.Color}', '{car.PetName}')";

            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.ExecuteNonQuery();
            }
        }

        public void DeleteCar(int id)
        {
            string sql = $"DELETE FROM Inventory WHERE CarId = '{id}'";

            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                try
                {
                    command.ExecuteNonQuery();
                }
                catch(SqlException exc)
                {
                    Exception error = new Exception("Sorry! This car is in order", exc);
                    throw error;
                }
            }
        }

        public void UpdateCarPetName(int id, string newPetName)
        {
            string sql = $"UPDATE Inventory SET PetName = '{newPetName}' WHERE CarId = '{id}'";

            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.ExecuteNonQuery();
            }
        }

        public string LookUpPetName(int carId)
        {
            string carPetName;

            using (SqlCommand command = new SqlCommand("GetPetName", _sqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = "@CarId",
                    SqlDbType = SqlDbType.Char,
                    Size = 10,
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(parameter);
                
                command.ExecuteNonQuery();

                carPetName = (string)command.Parameters["@PetName"].Value;
            }
            return carPetName;
        }

        public List<NewCar> GetAllInventoryAsList()
        {
            List<NewCar> inv = new List<NewCar>();

            string sql = "SELECT * FROM Inventory";

            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    inv.Add(new NewCar
                    {
                        CarId = (int)dataReader["CarId"],
                        Color = (string)dataReader["Color"],
                        Make = (string)dataReader["Make"],
                        PetName = (string)dataReader["PetName"],
                    });
                }
                dataReader.Close();
            }
            return inv;
        }

        public DataTable GetAllInventotyAsDataTable()
        {
            DataTable dataTable = new DataTable();

            string sql = "SELECT * FROM Inventory";

            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                SqlDataReader dataReader = command.ExecuteReader();

                dataTable.Load(dataReader);
                dataReader.Close();
            }
            return dataTable;
        }

        public void ProcessCreditRisk(bool throwExc, int custID)
        {
            string firstName;
            string lastName;

            var cmdSelect = new SqlCommand($"SELECT * FROM Customers WHERE CustId = {custID}", _sqlConnection);
            using (var dataReader = cmdSelect.ExecuteReader())
            {
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    firstName = (string)dataReader["FirstName"];
                    lastName = (string)dataReader["LastName"];
                }
                else
                {
                    return;
                }
            }

            var cmdRemove = new SqlCommand($"DELETE FROM Customers WHERE CustId = {custID}", _sqlConnection);

            var cmdInsert = new SqlCommand("INSERT INTO CreditRisks" + $"(FirstName, LastName) VALUES ('{firstName}', '{lastName}'", _sqlConnection);

            SqlTransaction tx = null;
            try
            {
                tx = _sqlConnection.BeginTransaction();

                cmdInsert.Transaction = tx;
                cmdRemove.Transaction = tx;

                cmdInsert.ExecuteNonQuery();
                cmdRemove.ExecuteNonQuery();

                if (throwExc)
                {
                    throw new Exception("Sorry! Database error! Tx failed..");
                }

                tx.Commit();
            }
            catch(Exception exc)
            {
                Console.WriteLine(exc.Message);
                tx?.Rollback();
            }
        }
    }
}

