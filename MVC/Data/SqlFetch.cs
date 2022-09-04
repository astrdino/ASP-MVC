using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using MVC.Models;

namespace MVC.Data
{

    /*
        This is the script that recorded the command that used to 
        interact with SQL server.
     
     */

    internal class SqlFetch
    {

        private string connectionString = @"data source=ASTRDINO;initial catalog=BugDatabase;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
       
        public List<Table_1> Fetch()
        {
            List<Table_1> returnList = new List<Table_1>();




            //Access the Database

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * from dbo.Table_1";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //Create the object 
                        Table_1 obj = new Table_1();
                        obj.ID = reader.GetInt32(0);
                        obj.Name = reader.GetString(1);
                        obj.Date = reader.GetDateTime(2);
                        obj.Bug_Level = reader.GetInt32(3);

                        returnList.Add(obj);
                    }
                }
            }

            return returnList;

        }

        public Table_1 FetchOne(int GoalID)
        {
            //List<Table_1> returnList = new List<Table_1>();
            Table_1 obj = new Table_1();


            //Access the Database

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * from dbo.Table_1 WHERE Id = @id";

               
                
                //Associate the @id with parameter Id

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = GoalID;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

               

               

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        //Create the object 
                        
                        obj.ID = reader.GetInt32(0);
                        obj.Name = reader.GetString(1);
                        obj.Date = reader.GetDateTime(2);
                        obj.Bug_Level = reader.GetInt32(3);

                      
                    }
                }
            }

            return obj;

        }

        public int FetchHRAmt()
        {
            int amt = 0;
            List<Table_1> returnList = new List<Table_1>(); 

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * from dbo.Table_1";

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //Create the object 
                        Table_1 obj = new Table_1();
                        obj.ID = reader.GetInt32(0);
                        obj.Name = reader.GetString(1);
                        obj.Date = reader.GetDateTime(2);
                        obj.Bug_Level = reader.GetInt32(3);

                        returnList.Add(obj);
                    }
                }

                amt = returnList.Count();
            }

                return amt;
        }
    }
  
}