using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IBooth> booths;

        public Controller()
        {
            this.booths = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            var boothId = this.booths.Models.Count + 1;

            var booth = new Booth(boothId, capacity);

            this.booths.AddModel(booth);

            return string.Format(OutputMessages.NewBoothAdded, boothId, capacity);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            if(cocktailTypeName != nameof(MulledWine) && cocktailTypeName != nameof(Hibernation))
            {
                return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            if(size != "Small" && size != "Middle" && size != "Large")
            {
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            }

            var booth = this.booths.Models.FirstOrDefault(x => x.BoothId == boothId);
            var cocktail = booth.CocktailMenu.Models.FirstOrDefault(x=> x.Name== cocktailTypeName && x.Size == size);

            if(cocktail != null)
            {
                return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }

            if(cocktailTypeName == nameof(MulledWine))
            {
                cocktail = new MulledWine(cocktailName, size);
            }
            else if(cocktailTypeName == nameof(Hibernation))
            {
                cocktail = new Hibernation(cocktailName, size);
            }
            booth.CocktailMenu.AddModel(cocktail);

            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            if (delicacyTypeName != nameof(Stolen) && delicacyTypeName != nameof(Gingerbread))
            {
                return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }

            var booth = this.booths.Models.FirstOrDefault(x => x.BoothId == boothId);
            var delicacy = booth.DelicacyMenu.Models.FirstOrDefault(x => x.Name == delicacyTypeName);

            if (delicacy != null)
            {
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }

            if (delicacyTypeName == nameof(Stolen))
            {
                delicacy = new Stolen(delicacyName);
            }
            else if (delicacyTypeName == nameof(Gingerbread))
            {
                delicacy = new Gingerbread(delicacyName);
            }
            booth.DelicacyMenu.AddModel(delicacy);

            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string BoothReport(int boothId)
        {
            var booth = this.booths.Models.FirstOrDefault(x=> x.BoothId == boothId);

            return booth.ToString();
        }

        public string LeaveBooth(int boothId)
        {
            var booth = this.booths.Models.FirstOrDefault(x=> x.BoothId==boothId);

            //booth.Charge();
            //booth.ChangeStatus();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Bill {booth.CurrentBill:f2} lv");
            sb.AppendLine($"Booth {boothId} is now available!");

            //return sb.ToString().TrimEnd();

            booth.Charge();
            booth.ChangeStatus();
            return sb.ToString().TrimEnd();
        }

        public string ReserveBooth(int countOfPeople)
        {
            var selectedBooths = this.booths.Models.Where(x => x.IsReserved == false && x.Capacity >= countOfPeople).OrderBy(x=> x.Capacity).OrderByDescending(x=> x.BoothId).ToList();

            var booth = selectedBooths.FirstOrDefault();

            if(booth == null)
            {
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }

            booth.ChangeStatus();
    
            return string.Format(OutputMessages.BoothReservedSuccessfully, booth.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            string[] orderInfo = order.Split("/", StringSplitOptions.RemoveEmptyEntries);
            string itemTypeName = orderInfo[0];
            string itemName = orderInfo[1];
            int orderedPiecesCount = int.Parse(orderInfo[2]);

            //Finding booth
            Booth currentBooth = (Booth)booths.Models.First(b => b.BoothId == boothId);

            //Finding Item
            //Cocktail
            if (itemTypeName == "Hibernation" || itemTypeName == "MulledWine")
            {
                string cocktailSize = orderInfo[3];

                if (!currentBooth.CocktailMenu.Models.Any(c => c.Name == itemName))
                {
                    return String.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }

                var desiredCocktail = currentBooth.CocktailMenu.Models
                    .FirstOrDefault
                    (c => c.GetType().Name == itemTypeName && c.Name == itemName && c.Size == cocktailSize);

                if (desiredCocktail == null)
                {
                    return String.Format(OutputMessages.CocktailStillNotAdded, cocktailSize, itemName);
                }

                currentBooth.UpdateCurrentBill(desiredCocktail.Price * orderedPiecesCount);
                return String.Format(OutputMessages.SuccessfullyOrdered, currentBooth.BoothId, orderedPiecesCount, itemName);
            }

            //Delicacy
            else if (itemTypeName == "Gingerbread" || itemTypeName == "Stolen")
            {
                if (!currentBooth.DelicacyMenu.Models.Any(c => c.Name == itemName))
                {
                    return String.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }

                var desiredDelicacy = currentBooth.DelicacyMenu.Models
                    .FirstOrDefault
                    (c => c.GetType().Name == itemTypeName && c.Name == itemName);

                if (desiredDelicacy == null)
                {
                    return String.Format(OutputMessages.DelicacyStillNotAdded, itemTypeName, itemName);
                }

                currentBooth.UpdateCurrentBill(desiredDelicacy.Price * orderedPiecesCount);
                return String.Format(OutputMessages.SuccessfullyOrdered, currentBooth.BoothId, orderedPiecesCount, itemName);
            }
            else
            {
                return String.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }
        }
    }
}
