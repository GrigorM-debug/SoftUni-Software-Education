using Boardgames.DataProcessor.ExportDto;
using Boardgames.Extensions;

namespace Boardgames.DataProcessor
{
    using Boardgames.Data;

    public class Serializer
    {
        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            var creators = context.Creators
                .Where(c => c.Boardgames.Any())
                .Select(c => new ExportCreatorDto()
                {
                    CreatorName = c.FirstName + " " + c.LastName,
                    BoardgamesCount = c.Boardgames.Count,
                    Boardgames = c.Boardgames
                        .Select(b=> new ExportBoardGameInfoDto()
                        {
                            BoardgameName = b.Name,
                            BoardgameYearPublished = b.YearPublished
                        })
                        .OrderBy(b=> b.BoardgameName)
                        .ToArray()
                })
                .OrderByDescending(c=> c.BoardgamesCount)
                .ThenBy(c=> c.CreatorName)
                .ToArray();

            return creators.SerializeToXml<ExportCreatorDto[]>("Creators");
        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {
            var sellers = context.Sellers
                .Where(s => s.BoardgamesSellers.Any(x => x.Boardgame.YearPublished >= year && x.Boardgame.Rating <= rating))
                .Select(s => new ExportSellerDto()
                {
                    Name = s.Name,
                    Website = s.Website,
                    Boardgames = s.BoardgamesSellers
                        .Where(b=> b.Boardgame.YearPublished >= year && b.Boardgame.Rating <= rating)
                        .Select(b => new ExportBoardGameDto()
                    {
                        Name = b.Boardgame.Name,
                        Rating = b.Boardgame.Rating,
                        Mechanics = b.Boardgame.Mechanics,
                        Category = b.Boardgame.CategoryType.ToString()
                    })
                        .OrderByDescending(b=> b.Rating)
                        .ThenBy(b=> b.Name)
                        .ToArray()
                })
                .OrderByDescending(s=> s.Boardgames.Length)
                .ThenBy(s => s.Name)
                .Take(5)
                .ToArray();

            return sellers.SerializeToJson<ExportSellerDto[]>();
        }
    }
}