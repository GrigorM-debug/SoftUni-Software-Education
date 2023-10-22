using Microsoft.Data.SqlClient;

string connectionString = "Server=GRIGOR;Database=MinionsDB;Trusted_Connection=True;TrustServerCertificate=True";

int minionID = int.Parse(Console.ReadLine());

using SqlConnection connection = new SqlConnection(connectionString);
connection.Open();

IncreasingMionionAge(connection, minionID);
PrintingMinions(connection, minionID);

static void PrintingMinions(SqlConnection connection, int minionID)
{
    string minionNameAndAge = "SELECT Name, Age FROM Minions WHERE Id = @Id";

    using SqlCommand printingMinion = new SqlCommand(minionNameAndAge, connection);
    printingMinion.Parameters.AddWithValue("@Id", minionID);

    using SqlDataReader reader = printingMinion.ExecuteReader();

    while (reader.Read())
    {
        string name = (string)reader["Name"];
        int age = (int)reader["Age"];
        Console.WriteLine($"{name} - {age} years old");
    }
}

static void IncreasingMionionAge(SqlConnection connection, int minionID) 
{
    string procedure = "EXEC usp_GetOlder @id";

    using SqlCommand getOlder = new SqlCommand(procedure, connection);
    getOlder.Parameters.AddWithValue("@id", minionID);

    getOlder.ExecuteNonQuery();
}