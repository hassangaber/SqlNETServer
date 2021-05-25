using System;
using Microsoft.Data.SqlClient;
using System.Text;

namespace SqlServerSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Entry point
            Console.WriteLine(">> .NET & SQL Direct Interface <<");
            Console.WriteLine("Type 'D' for DEMO, 'I' for the SQL Interface, or any other key to exit.");

            String Decision=Console.ReadLine();

            // Build connection string & login
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost";   
            builder.UserID = "sa";             
            builder.Password = "Password";   
            builder.InitialCatalog = "master";

            // New QueryCall object to call commands
            QueryCall QC = new QueryCall();

            // Entering demo mode in program
            if(Decision=="D"){
                try {
                    Console.WriteLine("***SQL Queries DEMO: CREATE, READ, WRITE, DELETE***");
                    using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                    {
                        connection.Open();
                        Console.WriteLine("Done.");

                        // CREATE Command
                        using (SqlCommand command = new SqlCommand(QC.CREATE(), connection))
                        {
                            command.ExecuteNonQuery();
                            Console.WriteLine("Done.");
                        }

                       // USE Command
                        using (SqlCommand command = new SqlCommand(QC.USE(), connection))
                        {
                            command.ExecuteNonQuery();
                            Console.WriteLine("Done.");
                        }

                       // INSERT Command
                        using (SqlCommand command = new SqlCommand(QC.INSERT(), connection))
                        {
                            command.Parameters.AddWithValue("@name", "Hassan");
                            command.Parameters.AddWithValue("@location", "United States");
                            //int rowsAffected = command.ExecuteNonQuery();
                            Console.WriteLine("Data Added.");
                        }

                        // UPDATE demo
                        StringBuilder sb = new StringBuilder();
                        String userToUpdate = "Hassan";
                        Console.Write("Updating 'Location' for user '" + userToUpdate + "', press any key to continue...");
                        Console.ReadKey(true);
                        sb.Clear();
                        sb.Append("UPDATE SampleDB SET Location = N'United States' WHERE Name = @name");
                        String sql = sb.ToString();
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
                Console.WriteLine("***SQL Queries Interface Mode***");
                Console.WriteLine("Directly Query or 'E' to exit");
                try {
                    String Query;
                    //int numQuery;
                    using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                    {
                        connection.Open();

                        while(true){

                            Query=Console.ReadLine();
                            if(Query=="E") break;

                            using (SqlCommand command = new SqlCommand(Query, connection))
                            {
                                command.ExecuteNonQuery();
                                Console.WriteLine("Query Sent");
                            }
                            

                        }
                    }
                } catch (SqlException e)
                {
                    Console.WriteLine(e.ToString());
                }
            } else {
                Console.WriteLine("Program Terminated.");
            }
        } 
    }
}
