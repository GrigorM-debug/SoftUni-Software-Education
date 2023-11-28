using System.Net.WebSockets;
using System.Text;
using Boardgames.Data.Models;
using Boardgames.Data.Models.Enums;
using Boardgames.DataProcessor.ImportDto;
using Boardgames.Extensions;

namespace Boardgames.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using Boardgames.Data;
   
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
            var creatorsDtos = XmlSerilizationExtention.DeserializeFromXml<ImportCreatorDto[]>(xmlString, "Creators");

            var validCreators = new HashSet<Creator>();

            var sb = new StringBuilder();

            foreach (var creatorDto in creatorsDtos)
            {
                if (!IsValid(creatorDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var creator = new Creator()
                {
                    FirstName = creatorDto.FirstName,
                    LastName = creatorDto.LastName,
                };

                foreach (var boardGameDto in creatorDto.Boardgames)
                {
                    if (!IsValid(boardGameDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var boardGame = new Boardgame()
                    {
                        Name = boardGameDto.Name,
                        Rating = boardGameDto.Rating,
                        YearPublished = boardGameDto.YearPublished,
                        CategoryType = (CategoryType)boardGameDto.CategoryType,
                        Mechanics = boardGameDto.Mechanics,
                    };

                    creator.Boardgames.Add(boardGame);
                }
                validCreators.Add(creator);

                sb.AppendLine(string.Format(SuccessfullyImportedCreator, creator.FirstName, creator.LastName,
                    creator.Boardgames.Count));
            }

            context.Creators.AddRange(validCreators);

            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var sellersDtos = JsonSerilizationExtension.DeserializeFromJson<ImportSellerDto[]>(jsonString);

            var validSellers = new HashSet<Seller>();

            var boardgamesIds = context.Boardgames.Select(x => x.Id).ToArray();

            foreach (var sellerDto in sellersDtos)
            {
                if (!IsValid(sellerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var seller = new Seller()
                {
                    Name = sellerDto.Name,
                    Address = sellerDto.Address,
                    Country = sellerDto.Country,
                    Website = sellerDto.Website,
                };

                foreach (var boardgameID in sellerDto.Boardgames.Distinct())
                {
                    if (!boardgamesIds.Contains(boardgameID))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var boardgameSeller = new BoardgameSeller()
                    {
                        Seller = seller,
                        BoardgameId = boardgameID
                    };

                    seller.BoardgamesSellers.Add(boardgameSeller);
                }
                sb.AppendLine(
                    string.Format(SuccessfullyImportedSeller, seller.Name, seller.BoardgamesSellers.Count));

                validSellers.Add(seller);
            }

            context.Sellers.AddRange(validSellers);

            context.SaveChanges();

            return sb.ToString();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
