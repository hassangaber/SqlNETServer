using System;
using Microsoft.Data.SqlClient;
using System.Text;

namespace SqlServerSample
{
    class Program
    {
        static void Main(string[] args) {

            // New QueryCall object to call commands
            QueryCall QC = new QueryCall();

            // Entry point (Connect to server and retrieve input)
            Console.WriteLine(">> .NET & SQL Direct Interface <<");
            QC.CONNECT();
            Console.WriteLine("Type 'D' for DEMO, 'I' for the SQL Interface, or any other key to exit.");
            String Decision=Console.ReadLine();

            // Demo mode
            if(Decision=="D") {
                try {
                    Console.WriteLine("***SQL Queries DEMO: CREATE, READ, WRITE, DELETE***");
                    using (SqlConnection connection = new SqlConnection(QC.CONNECT().ConnectionString))
                    {
                        connection.Open();

                        // CREATE Command
                        using (SqlCommand command = new SqlCommand(QC.CREATE(), connection)) {
                            command.ExecuteNonQuery();
                            Console.WriteLine("[CREATE] Done.");
                        }

                       // USE Command
                        using (SqlCommand command = new SqlCommand(QC.USE(), connection)) {
                            command.ExecuteNonQuery();
                            Console.WriteLine("[USE] Done.");
                        }

                       // INSERT Command
                        using (SqlCommand command = new SqlCommand(QC.INSERT(), connection)) {
                            command.Parameters.AddWithValue("@name", "Hassan");
                            command.Parameters.AddWithValue("@location", "United States");
                            //int rowsAffected = command.ExecuteNonQuery();
                            Console.WriteLine("Data Added.");
                        }

                        /* // UPDATE command
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
                        } */

                        /* // DELETE command
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
                        } */

                        // READ demo
                        /* Console.WriteLine("Reading data from table, press any key to continue...");
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
                        } */
                    }
                }
                catch (SqlException e) {
                    Console.WriteLine(e.ToString());
                }

            Console.WriteLine("Demo done. Press any key to finish...");
            Console.ReadKey(true);

            } 

            // Interface mode
            else if(Decision=="I") {
                Console.WriteLine("***SQL Queries Interface Mode***");
                Console.WriteLine("Directly Query or 'E' to exit");
                QueryCall ic = new QueryCall();
                try {

                    String Query;
                    using (SqlConnection connection = new SqlConnection(QC.CONNECT().ConnectionString)) {

                        connection.Open();

                        while(true){

                            Query=Console.ReadLine();
                            if(Query=="E") break;

                            using (SqlCommand command = new SqlCommand(Query, connection)) {
                                command.ExecuteNonQuery();
                                Console.WriteLine("Query Sent");
                            }
                        }
                    }
                } catch (SqlException e) {
                    Console.WriteLine(e.ToString());
                }
            } else {
                Console.WriteLine("Program Terminated.");
            }
        } 
    }
}
