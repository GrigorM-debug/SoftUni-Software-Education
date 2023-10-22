using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Globalization;

string connectionString = "Server=GRIGOR;Database=MinionsDB;Trusted_Connection=True;TrustServerCertificate=True";

using SqlConnection connection = new SqlConnection(connectionString);
connection.Open();

string countryName = Console.ReadLine();

updateTownName(connection, countryName);

static void updateTownName(SqlConnection connection, string countryName)
{
    string query = "UPDATE Towns SET Name = UPPER(Name) WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";
  

    using SqlCommand command = new SqlCommand(query, connection);
    command.Parameters.AddWithValue("@countryName", countryName);

    int townAffected = (int)command.ExecuteNonQuery();

    if (townAffected == 0)
    {
        Console.WriteLine("No towns were affected.");
    }
    else
    {
        Console.WriteLine($"{townAffected} town names were affected.");
        GetTownNames(connection, countryName);
    }
}

static void GetTownNames(SqlConnection connection, string countryName)
{
    string query = "SELECT t.Name FROM Towns as t JOIN Countries AS c ON c.Id = t.CountryCode WHERE c.Name = @countryName";

    using SqlCommand command = new SqlCommand(query, connection);
    command.Parameters.AddWithValue($"@countryName", countryName);

    List<string> names = new List<string>();

    using SqlDataReader reader = command.ExecuteReader();

    while (reader.Read())
    {
        string townName = (string)reader["Name"];

        names.Add(townName);
    }

    Console.WriteLine($"[{string.Join(", ", names)}]");
}