namespace P01.Stream_Progress
{
    public class Music : File
    {

        public Music(string artist, int length, int bytesSent, string album) : base(artist, length, bytesSent)
        {
            this.Artist = artist;
            this.Album = album;
        }

        public string Artist { get; }

        public string Album { get;  }
    }
}
