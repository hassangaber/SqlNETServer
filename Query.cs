using System;
using Microsoft.Data.SqlClient;
using System.Text;

namespace SqlServerSample{

    public class QueryCall {

        //Create a database query
        public String CREATE(){
            Console.Write("Creating database 'SampleDB' ... ");
            String sql = "DROP DATABASE IF EXISTS SampleDB; CREATE DATABASE SampleDB";
            return sql;
        }

        // Create data table and append to it
        public String USE(){
             // Create a Table and insert some sample data
             Console.Write("Creating sample table with data, press any key to continue...");
             Console.ReadKey(true);
             StringBuilder sb = new StringBuilder();
             sb.Append("USE SampleDB");
             return sb.ToString();
        }

        // Insert data to DB
        public String INSERT(){
             // INSERT demo
            Console.Write("Inserting a new row into table, press any key to continue...");
            Console.ReadKey(true);
            StringBuilder sb = new StringBuilder();
            sb.Clear();
            return sb.ToString();
        }


    }
}