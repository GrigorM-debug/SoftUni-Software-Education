using Microsoft.Data.SqlClient;
using System.Globalization;

string[] minionInformation = Console.ReadLine().Split();
string[] villainInformation = Console.ReadLine().Split();

string minionName = minionInformation[1];
int minionAge = int.Parse(minionInformation[2]);
string minionTown = minionInformation[3];   

string villainName = villainInformation[1];

string connectionString = "Server=GRIGOR;Database=MinionsDB;Trusted_Connection=True;TrustServerCertificate=True";
using SqlConnection connection = new SqlConnection(connectionString);
connection.Open();

SqlTransaction transaction = connection.BeginTransaction();

try
{
    #region Town
    string townById = "SELECT Id FROM Towns WHERE Name = @townName";
    SqlCommand command = new SqlCommand(townById, connection, transaction);
    command.Parameters.AddWithValue("@townName", minionTown);

    var result = command.ExecuteScalar();

    int townId = -1;

    if (result is null)
    {
        string insertTown = "INSERT INTO Towns (Name) VALUES (@townName)";
        using SqlCommand insertingTown = new SqlCommand(insertTown, connection, transaction);
        insertingTown.Parameters.AddWithValue("@townName", minionName);

        insertingTown.ExecuteNonQuery();

        Console.WriteLine($"Town {minionTown} was added to the database.");
    }
    else
    {
        townId = (int)result;
    }
    #endregion

    #region Villain
    string query = "SELECT Id FROM Villains WHERE Name = @Name";
    using SqlCommand getVillain = new SqlCommand(query, connection, transaction);

    getVillain.Parameters.AddWithValue("@Name", villainName);

    var villainResult = getVillain.ExecuteScalar();

    int villainId = -1;

    if (villainResult is null)
    {
        string insertVillain = "INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";
        using SqlCommand insertingVillian = new SqlCommand(insertVillain, connection, transaction);
        insertingVillian.Parameters.AddWithValue("@villainName", villainName);
        insertingVillian.Parameters.AddWithValue("@evilnessFactorID", 4);

        insertingVillian.ExecuteNonQuery();

        Console.WriteLine($"Villain {villainName} was added to the database.");

        villainId = Convert.ToInt32(getVillain.ExecuteScalar());
    }
    else
    {
        villainId = (int)villainResult;
    }
    #endregion

    #region Minion
    string getMinion = "SELECT Id FROM Minions WHERE Name = @Name";
    using SqlCommand getMinnion = new SqlCommand(getMinion, connection, transaction);
    getMinnion.Parameters.AddWithValue("@Name", minionName);

    var minionResult = getMinnion.ExecuteScalar();

    int minionId = -1;
    if(minionResult is null)
    {
        string insertMinion = "INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";
        using SqlCommand insertingMinion = new SqlCommand(insertMinion, connection, transaction);
        insertingMinion.Parameters.AddWithValue("@Name", minionName);
        insertingMinion.Parameters.AddWithValue("@Age", minionAge);
        insertingMinion.Parameters.AddWithValue("@townId", townId);

        insertingMinion.ExecuteNonQuery();
        minionId = Convert.ToInt32(getMinnion.ExecuteScalar());
        //int minionId = Convert.ToInt32(insertingMinion.ExecuteScalar());
    }
    else
    {
        minionId = (int)minionResult;
    }
    using SqlCommand insertMinionVillain = new SqlCommand("INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)", connection, transaction);
    insertMinionVillain.Parameters.AddWithValue("MinionId", minionId);
    insertMinionVillain.Parameters.AddWithValue("VillainId", villainId);
    insertMinionVillain.ExecuteNonQuery();
    Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
    #endregion

    transaction.Commit();
}
catch
{
    transaction.Rollback();
}