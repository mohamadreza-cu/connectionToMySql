using System;
using MySql.Data.MySqlClient;

namespace MySQLConnectionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Connection string to the MySQL database
            string connectionString = "Server=localhost;Database=secondtest;User ID=root;Password=root;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    Console.WriteLine("Connection opened successfully.");

                    // Step 4: Prepare the INSERT statement
                    string insertQuery = "INSERT INTO testtable (firstname, lastname) VALUES (@firstname, @lastname)";

                    // Step 5: Create a MySqlCommand to execute the query
                    MySqlCommand cmd = new MySqlCommand(insertQuery, conn);

                    // Step 6: Use parameters to prevent SQL injection
                    cmd.Parameters.AddWithValue("@firstname", "reza");  // Example value
                    cmd.Parameters.AddWithValue("@lastname", "shahabian");           // Example value

                    // Step 7: Execute the INSERT command
                    int rowsAffected = cmd.ExecuteNonQuery();
                    Console.WriteLine($"{rowsAffected} row(s) inserted.");


                    string query = "SELECT * FROM testtable";

                    MySqlCommand cmd2 = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd2.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader["id"] + " - " + reader["firstname"] + " - " + reader["lastname"]);
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
