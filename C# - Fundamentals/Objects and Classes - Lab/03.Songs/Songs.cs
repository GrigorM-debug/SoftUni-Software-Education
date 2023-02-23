using System.Security.Cryptography.X509Certificates;

int n = int.Parse(Console.ReadLine());

List<Song> songs = new List<Song>();    

for (int i = 1; i <= n; i++)
{
    string[] songInfo = Console.ReadLine().Split("_");

    string type = songInfo[0];  
    string songName = songInfo[1];  
    string duration = songInfo[2];

    Song song = new Song();
    {
        song.TypeList = type;
        song.Name = songName;
        song.Time = duration;
    };

    songs.Add(song);
}

string typeList = Console.ReadLine();

if (typeList == "all")
{
    foreach(Song song in songs)
    {
        Console.WriteLine(song.Name);
    }
}
else
{
    foreach (Song song in songs)
    {
        if (song.TypeList == typeList)
        {
            Console.WriteLine(song.Name);
        }
    }
}


class Song
{
    public string TypeList { get; set; }

    public string Name { get; set; }    

    public string Time { get; set; }   
}