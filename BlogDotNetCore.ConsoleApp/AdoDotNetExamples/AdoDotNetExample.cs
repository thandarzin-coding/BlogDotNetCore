using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDotNetCore.ConsoleApp.AdoDotNetExamples
{
    public class AdoDotNetExample
    {
        public void Run()
        {
           //Read();
           // Edit(7);
           // Create("Testing Title", "Testing Author", "Testing Content");
            //Update(7, "Testing", "Testing Two", "Testing Content");
            Delete(7);
        }

        public void Read()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "TestDb",
                UserID = "sa",
                Password = "sa@123",
                TrustServerCertificate = true
            };
            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            string query = @"SELECT [Blog_Id]
      ,[Blog_Title]
      ,[Blog_Author]
      ,[Blog_Content]
  FROM [dbo].[Tbl_Blog]";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            connection.Close();
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("Id => " + dr["Blog_Id"]);
                Console.WriteLine("Id => " + dr["Blog_Author"]);
                Console.WriteLine("Id => " + dr["Blog_Content"]);
                Console.WriteLine("Id => " + dr["Blog_Title"]);
                Console.WriteLine(".....................");
            }

        }

        public void Edit(int id)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "TestDb",
                UserID = "sa",
                Password = "sa@123",
                TrustServerCertificate = true
            };
            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            string query = @"SELECT [Blog_Id]
      ,[Blog_Title]
      ,[Blog_Author]
      ,[Blog_Content]
  FROM [dbo].[Tbl_Blog] where Blog_Id = @Blog_Id";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@Blog_Id",id);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            connection.Close();
            DataRow dr = dt.Rows[0];
                Console.WriteLine("Id => " + dr["Blog_Id"]);
                Console.WriteLine("Id => " + dr["Blog_Author"]);
                Console.WriteLine("Id => " + dr["Blog_Content"]);
                Console.WriteLine("Id => " + dr["Blog_Title"]);
                Console.WriteLine(".....................");
        }

        public void Create(string title,string author,string content)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "TestDb",
                UserID = "sa",
                Password = "sa@123",
                TrustServerCertificate = true
            };
            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([Blog_Title]
           ,[Blog_Author]
           ,[Blog_Content])
     VALUES
           (@Blog_Title
           ,@Blog_Author
           ,@Blog_Content)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Blog_Title", title);
            command.Parameters.AddWithValue("@Blog_Content", content);
            command.Parameters.AddWithValue("@Blog_Author", author);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            int result = command.ExecuteNonQuery();
            string message = result > 0 ? "Saving Successful" : "Saving Failed";
            Console.WriteLine(message);
        }

        public void Update(int id, string title, string author, string content)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "TestDb",
                UserID = "sa",
                Password = "sa@123",
                TrustServerCertificate = true
            };
            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [Blog_Title] = @Blog_Title
      ,[Blog_Author] = @Blog_Author
      ,[Blog_Content] = @Blog_Content
 WHERE Blog_Id = @Blog_Id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Blog_Id", id);
            command.Parameters.AddWithValue("@Blog_Title", title);
            command.Parameters.AddWithValue("@Blog_Content", content);
            command.Parameters.AddWithValue("@Blog_Author", author);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            int result = command.ExecuteNonQuery();
            string message = result > 0 ? "Updated Successful" : "Updating Failed";
            Console.WriteLine(message);
        }

        public void Delete(int id)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "TestDb",
                UserID = "sa",
                Password = "sa@123",
                TrustServerCertificate = true
            };
            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            string query = @"DELETE FROM [dbo].[Tbl_Blog]
      WHERE Blog_Id = @Blog_Id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Blog_Id", id);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            int result = command.ExecuteNonQuery();
            string message = result > 0 ? "Deleted Successful" : "Deleting Failed";
            Console.WriteLine(message);
        }
    }
}
