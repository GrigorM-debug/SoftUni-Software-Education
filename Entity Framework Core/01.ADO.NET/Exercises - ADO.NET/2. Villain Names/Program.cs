using Microsoft.Data.SqlClient;

string connectionString = "Server=GRIGOR;Database=MinionsDB;Trusted_Connection=True;TrustServerCertificate=True";

using SqlConnection connection = new SqlConnection(connectionString);
connection.Open();

string query = "SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount FROM Villains AS v JOIN MinionsVillains AS mv ON v.Id = mv.VillainId GROUP BY v.Id, v.Name HAVING COUNT(mv.VillainId) > 3 ORDER BY COUNT(mv.VillainId)";

using SqlCommand command = new SqlCommand(query, connection);

using SqlDataReader reader = command.ExecuteReader();

while(reader.Read())
{
    string villainName = (string)reader["Name"];
    int minionsCount = (int)reader["MinionsCount"];

    Console.WriteLine($"{villainName} - {minionsCount}");
}
