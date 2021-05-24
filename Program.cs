using System;
using Microsoft.Data.SqlClient;
using System.Text;

//

namespace SqlServerSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Entry point
            Console.WriteLine(">> .NET & SQL Direct Interface <<");
            Console.WriteLine("Type 'D' for DEMO or 'I' for the SQL Interface.");

            String Decision=Console.ReadLine();

            // Build connection string & login
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost";   
            builder.UserID = "sa";             
            builder.Password = "Incorrect475";   
            builder.InitialCatalog = "master";

            // Entering demo mode in program
            if(Decision=="D"){
                try {
                    Console.WriteLine("***SQL Queries DEMO: CREATE, READ, WRITE, DELETE***");

                    using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                    {
                        connection.Open();
                        Console.WriteLine("Done.");

                        // Create a sample database
                        Console.Write("Creating database 'SampleDB' ... ");
                        String sql = "DROP DATABASE IF EXISTS SampleDB; CREATE DATABASE SampleDB";
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.ExecuteNonQuery();
                            Console.WriteLine("Done.");
                        }

                        // Create a Table and insert some sample data
                        Console.Write("Creating sample table with data, press any key to continue...");
                        Console.ReadKey(true);
                        StringBuilder sb = new StringBuilder();
                        sb.Append("USE SampleDB");
                    
                        sql = sb.ToString();
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.ExecuteNonQuery();
                            Console.WriteLine("Done.");
                        }

                        // INSERT demo
                        Console.Write("Inserting a new row into table, press any key to continue...");
                        Console.ReadKey(true);
                        sb.Clear();
                    
                        sql = sb.ToString();
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@name", "Hassan");
                            command.Parameters.AddWithValue("@location", "United States");
                            //int rowsAffected = command.ExecuteNonQuery();
                            Console.WriteLine("Data Added.");
                        }

                        // UPDATE demo
                        String userToUpdate = "Hassan";
                        Console.Write("Updating 'Location' for user '" + userToUpdate + "', press any key to continue...");
                        Console.ReadKey(true);
                        sb.Clear();
                        sb.Append("UPDATE SampleDB SET Location = N'United States' WHERE Name = @name");
                        sql = sb.ToString();
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@name", userToUpdate);
                            int rowsAffected = command.ExecuteNonQuery();
                            Console.WriteLine(rowsAffected + " row(s) updated");
                        }

                        // DELETE demo
                        String userToDelete = "Hassan";
                        Console.Write("Deleting user '" + userToDelete + "', press any key to continue...");
                        Console.ReadKey(true);
                        sb.Clear();
                        sb.Append("DELETE FROM SampleDB WHERE Name = @name;");
                        sql = sb.ToString();
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@name", userToDelete);
                            int rowsAffected = command.ExecuteNonQuery();
                            Console.WriteLine(rowsAffected + " row(s) deleted");
                        }

                        // READ demo
                        Console.WriteLine("Reading data from table, press any key to continue...");
                        Console.ReadKey(true);
                        sql = "SELECT Id, Name, Location FROM SampleDB;";
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Console.WriteLine("{0} {1} {2}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                                }
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.ToString());
                }

            Console.WriteLine("Demo done. Press any key to finish...");
            Console.ReadKey(true);
            } 
            // Entering direct interface mode in program
            else if(Decision=="I") {














            } else {
                Console.WriteLine("No Correct Input selected. Program Terminated.");
            }
        } 
    }
}
