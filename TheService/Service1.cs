using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;

namespace TheService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public Service1()
        {
            // Here we create the connection to the DB
            OpenConnToDb();
        }
        SqlConnection connection;
        SqlCommand command;

        // This is the function responsible with creating a connection to the DB
        void OpenConnToDb()
        {
            string connectionString;
            connectionString = "Data Source=GAMER-PC\\SQLEXPRESS;Initial Catalog=DellTestDB;Integrated Security=True";

            connection = new SqlConnection(connectionString);
            command = connection.CreateCommand();

        }

        //The next two functions were created automatically by the project
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        // Function to add a new customer in the DB
        public int AddCustomer(Customer c)
        {
            try
            {
                //Insert new customer in database
                command.CommandText = "INSERT INTO Customer_Details VALUES(@FirstName,@LastName,@Email)";
                command.Parameters.AddWithValue("FirstName", c.Fname);
                command.Parameters.AddWithValue("LastName", c.Lname);
                command.Parameters.AddWithValue("Email", c.Email);
                command.CommandType = CommandType.Text;

                //Open the connection created by OpenConnToDb()
                connection.Open();

                // Execute the insert command on the DB and get the result
                return command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    //After we add the new customer we close the connection 
                    connection.Close();
                }
            }
        }

        // Function that returns the ID created automatically for the customer 
        public int ReturnId(string s)
        {
            try
            {
                // Get the customer ID
                command.CommandText = "SELECT CustomerID FROM Customer_Details WHERE Email ='"+s+"'";                              
                command.CommandType = CommandType.Text;

                //Open the connection created by OpenConnToDb()
                connection.Open();

                // Execute the select command on the DB and get the result
                return (Int32)command.ExecuteScalar();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    //After we return the customer ID we close the connection
                    connection.Close();
                }
            }
        }

        // Function that checks if the current customer's email already exists in the DB
        public int AlreadyExists(string s)
        {
            try
            {
                // Check to see if the entered email already exists in the database
                command.CommandText = "SELECT COUNT(*) FROM Customer_Details WHERE Email ='" + s + "'";
                command.CommandType = CommandType.Text;

                //Open the connection created by OpenConnToDb()
                connection.Open();

                // Execute the select command on the DB and get the result
                return (Int32)command.ExecuteScalar();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    //After we return the count for the entered email we close the connection
                    connection.Close();
                }
            }
        }

        // Function that updates the DB entry that has the same email as the current "to be added" customer
        public int UpdateCustomer(Customer c)
        {
            try
            {
                //Update existing customer with new values
                command.CommandText = "UPDATE Customer_Details SET FirstName=@FirstName,LastName=@LastName WHERE Email=@Email";
                command.Parameters.AddWithValue("FirstName", c.Fname);
                command.Parameters.AddWithValue("LastName", c.Lname);
                command.Parameters.AddWithValue("Email", c.Email);
                command.CommandType = CommandType.Text;

                //Open the connection created by OpenConnToDb()
                connection.Open();

                // Execute the update command on the DB and get the result
                return command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    //After we update the customer we close the connection
                    connection.Close();
                }
            }
        }
    }
}
