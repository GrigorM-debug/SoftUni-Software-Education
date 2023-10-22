using Microsoft.Data.SqlClient;

string connectionString = "Server=GRIGOR;Database=MinionsDB;Trusted_Connection=True;TrustServerCertificate=True";

using SqlConnection connection = new SqlConnection(connectionString);
connection.Open();

int id = int.Parse(Console.ReadLine());

GetVillainName(connection, id);
GetMinionNames(connection, id);

static void GetMinionNames(SqlConnection connection, int id)
{
    string query = "SELECT ROW_NUMBER() OVER (ORDER BY m.Name) AS RowNum,                 m.Name, m.Age FROM MinionsVillains AS mv                                         JOIN Minions As m ON mv.MinionId = m.Id                                   WHERE mv.VillainId = @Id ORDER BY                                                              m.Name";
    using SqlCommand command = new SqlCommand(query, connection);
    command.Parameters.AddWithValue("@id", id);

    using SqlDataReader reader = command.ExecuteReader();

    int minionCount = 0;
    
    if(!reader.HasRows)
    {
        Console.WriteLine("(no minions)");
    }
    else
    {
        while (reader.Read())
        {
            string minionName = (string)reader["Name"];
            int minionAge = (int)reader["Age"];

            Console.WriteLine($"{++minionCount}. {minionName} {minionAge}");
        }
    }
}

static void GetVillainName(SqlConnection connection, int id)
{
    string query = "SELECT Name FROM Villains WHERE Id = @Id";

    using SqlCommand sqlCommand = new SqlCommand(query, connection);
    sqlCommand.Parameters.AddWithValue("@id", id);

    string name = (string)sqlCommand.ExecuteScalar();

    if(name is null)
    {
        Console.WriteLine($"No villain with ID {id} exist in the database.");
    }
    else
    {
        Console.WriteLine($"Villain: {name}");
    }
   
}
