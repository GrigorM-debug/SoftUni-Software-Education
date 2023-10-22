using Microsoft.Data.SqlClient;

string connectionString = "Server=GRIGOR;Database=MinionsDB;Trusted_Connection=True;TrustServerCertificate=True";

using SqlConnection connection = new SqlConnection(connectionString);
connection.Open();

int[] minionsIds = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

UpdateMinionAge(connection, minionsIds);
PrintingMinions(connection);

void UpdateMinionAge(SqlConnection connection, int[] minionIds)
{
    for(int i = 0; i < minionIds.Length - 1; i++)
    {
        using SqlCommand command = new SqlCommand("UPDATE Minions SET Name = LOWER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1 WHERE Id = @Id", connection);
        command.Parameters.AddWithValue("@Id", minionIds[i]);
        command.ExecuteNonQuery();
    }
}

static void PrintingMinions(SqlConnection connection)
{
    string query = "SELECT Name, Age FROM Minions";

    using SqlCommand command= new SqlCommand(query, connection);

    using SqlDataReader reader = command.ExecuteReader();

    while (reader.Read())
    {
        Console.WriteLine($"{(string)reader["Name"]} {(int)reader["Age"]}");
    }
}