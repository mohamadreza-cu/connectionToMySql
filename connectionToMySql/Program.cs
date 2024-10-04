using System;
using MySql.Data.MySqlClient;

namespace MySQLConnectionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Connection string to the MySQL database
            string connectionString = "Server=localhost;Database=testdb;User ID=root;Password=root;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    Console.WriteLine("Connection opened successfully.");

                    string query = "SELECT * FROM testtable";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader["id"] + " - " + reader["name"]);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                    Console.WriteLine("Connection closed.");
                }
            }
        }
    }
}
