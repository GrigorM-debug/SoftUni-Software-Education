using System.Globalization;
using System.Text;
using MusicHub.Data.Models;

namespace MusicHub
{
    using System;

    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here
            Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albumsInfo = context.Albums
                .Where(a => a.ProducerId.HasValue && a.ProducerId.Value == producerId)
                .ToArray()
                .OrderByDescending(a => a.Price)
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs
                        .Select(s => new
                        {
                            SongName = s.Name,
                            SongPrice = s.Price.ToString("f2"),
                            WriterName = s.Writer.Name
                        })
                        .OrderByDescending(s => s.SongName)
                        .ThenBy(s => s.WriterName)
                        .ToArray(),
                    TotalAlbumPrice = a.Price.ToString("f2")
                }).ToArray();

            var sb = new StringBuilder();
            foreach (var a in albumsInfo)
            {
                sb
                    .AppendLine($"-AlbumName: {a.AlbumName}")
                    .AppendLine($"-ReleaseDate: {a.ReleaseDate}")
                    .AppendLine($"-ProducerName: {a.ProducerName}");

                int counter = 1;

                sb.AppendLine("-Songs:");

                foreach (var s in a.Songs)
                {
                    sb
                        .AppendLine($"---#{counter}")
                        .AppendLine($"---SongName: {s.SongName}")
                        .AppendLine($"---Price: {s.SongPrice}")
                        .AppendLine($"---Writer: {s.WriterName}");

                    counter++;
                }

                sb.AppendLine($"-AlbumPrice: {a.TotalAlbumPrice}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songsInfo = context.Songs
                .ToArray()
                .Where(s => s.Duration.TotalSeconds > duration)
                .ToArray()
                .Select(s => new
                {
                    SongName = s.Name,
                    Performers = s.SongPerformers
                        .Select(sp => $"{sp.Performer.FirstName} {sp.Performer.LastName}")
                        .OrderBy(sp=>sp)
                        .ToArray(),
                    WriterName = s.Writer.Name,
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration.ToString("c")
                })
                .OrderBy(s => s.SongName)
                .ThenBy(s => s.WriterName)
                .ToArray();

            var sb = new StringBuilder();

            int songCounter = 1;

            foreach (var s in songsInfo)
            {
                sb
                    .AppendLine($"-Song #{songCounter}")
                    .AppendLine($"---SongName: {s.SongName}")
                    .AppendLine($"---Writer: {s.WriterName}");

                foreach (var p in s.Performers)
                {
                    sb.AppendLine($"---Performer: {p}");
                }

                sb
                    .AppendLine($"---AlbumProducer: {s.AlbumProducer}")
                    .AppendLine($"---Duration: {s.Duration}");

                songCounter++;
            }

            return sb.ToString().TrimEnd(); 
        }
    }
}
