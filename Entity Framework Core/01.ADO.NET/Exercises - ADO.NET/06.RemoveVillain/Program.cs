using Microsoft.Data.SqlClient;

string connectionString = "Server=GRIGOR;Database=MinionsDB;Trusted_Connection=True;TrustServerCertificate=True";


int villainId = int.Parse(Console.ReadLine());

using SqlConnection connection = new SqlConnection(connectionString);
connection.Open();

SqlTransaction transaction = connection.BeginTransaction();

try
{
    string query = "SELECT Name FROM Villains WHERE Id = @villainId";

    using SqlCommand command = new SqlCommand(query, connection, transaction);
    command.Parameters.AddWithValue("@villainId", villainId);


    var result = command.ExecuteScalar();

    if (result is null)
    {
        Console.WriteLine("No such villain was found.");
    }
    else
    {
        string villainName = (string)result;

        //Deletye from MinionsVillains
        string deleteVillainFromMinionsVillains = "DELETE FROM MinionsVillains WHERE VillainId = @villainId";

        using SqlCommand deleteVillainFromMinionsVillain = new SqlCommand(deleteVillainFromMinionsVillains, connection, transaction);
        deleteVillainFromMinionsVillain.Parameters.AddWithValue("@villainId", villainId);

        int rowsAffected = (int)deleteVillainFromMinionsVillain.ExecuteNonQuery();

        string deleteVillainsQuery = "DELETE FROM Villains WHERE Id = @villainId";

        using SqlCommand deleteVillains = new SqlCommand(deleteVillainsQuery, connection, transaction);
        deleteVillains.Parameters.AddWithValue("@villainId", villainId);

        deleteVillains.ExecuteNonQuery();

        Console.WriteLine($"{villainName} was deleted.");
        Console.WriteLine($"{rowsAffected} minions were released.");
    }
    transaction.Commit();
}
catch
{
    transaction.Rollback();
}