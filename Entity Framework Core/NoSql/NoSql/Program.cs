using MongoDB.Bson;
using MongoDB.Driver;


const string connectionUri = "mongodb://localhost:27017";
var settings = MongoClientSettings.FromConnectionString(connectionUri);
settings.ServerApi = new ServerApi(ServerApiVersion.V1);
var client = new MongoClient(settings);

var database = client.GetDatabase("Articles");

var collection = database.GetCollection<BsonDocument>("articles");

//var document = collection.Find(new BsonDocument()).FirstOrDefault();

//var articlesArray = document["articles"].AsBsonArray;

//foreach (var article in articlesArray)
//{
//    Console.WriteLine(article["name"]);
//}


//var newArticle = new BsonDocument
//{
//    { "author", "Steve Jobs" },
//    { "date", "05-05-2005" },
//    { "name", "The story of Apple" },
//    { "rating", "60" }
//};

//collection.InsertOne(newArticle);


//var filter = Builders<BsonDocument>.Filter.Type("articles.rating", BsonType.String);

//var arrayUpdate = Builders<BsonDocument>.Update.Set("articles.$.rating", 10);

//collection.UpdateMany(filter, arrayUpdate);

var deleteFilter = Builders<BsonDocument>.Filter.Lte("articles.rating", 50);
collection.DeleteMany(deleteFilter);

// Print names of remaining articles
var document = collection.Find(new BsonDocument()).FirstOrDefault();

var articlesArray = document["articles"].AsBsonArray;

foreach (var article in articlesArray)
{
    Console.WriteLine(article["name"]);
}
