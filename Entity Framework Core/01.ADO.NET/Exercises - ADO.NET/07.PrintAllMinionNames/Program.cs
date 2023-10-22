using Microsoft.Data.SqlClient;

string connectionString = "Server=GRIGOR;Database=MinionsDB;Trusted_Connection=True;TrustServerCertificate=True";

using SqlConnection connection = new SqlConnection(connectionString);
connection.Open();

using SqlCommand command = new SqlCommand("SELECT Name FROM Minions", connection);

List<string> names = new List<string>();    

using SqlDataReader reader = command.ExecuteReader();

while (reader.Read())
{
    names.Add((string)reader["Name"]);
}

for(int i = 0; i < names.Count / 2; i++)
{
    Console.WriteLine(names[i]);
    Console.WriteLine(names[names.Count - 1 - i]);
}
if(names.Count % 2 == 1)
{
    Console.WriteLine(names[names.Count / 2]);
}

//TODO