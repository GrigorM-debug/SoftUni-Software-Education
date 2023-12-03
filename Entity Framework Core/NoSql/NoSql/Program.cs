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


var updateDefinition = Builders<BsonDocument>.Update.Set("articles.$[].rating",
    BsonDocument.Parse("{ $toDouble: '$articles.$[].rating' }") + 10);

collection.UpdateMany(new BsonDocument(), updateDefinition);