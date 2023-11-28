using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.Common
{
    public static class ValidationConstants
    {
        public const int BoardgameMaxNameLenght = 20;
        public const int BoardgameMinNameLength = 10;
        public const double BoardgameRatingMinValue = 1;
        public const double BoardGameRatingMaxValue = 10.0;
        public const int BoardgameYearPublishedMinValue = 2018;
        public const int BoardgameYearPublishedMaxValue = 2023;


        public const int SellerNameMaxLength = 20;
        public const int SellerNameMinLength = 5;
        public const int SellerAddressMaxLength = 30;
        public const int SellerAddressMinLength = 2;

        public const int CreatorFirstNameMaxLength = 7;
        public const int CreatorLastNameMaxLength = 7;
        public const int CreatorFirstNameMinLength = 2;
        public const int CreatorLastNameMinLength = 2;

        public const string WebsiteRegex = @"^www\.[a-zA-Z0-9-]+\.com";
    }
}
