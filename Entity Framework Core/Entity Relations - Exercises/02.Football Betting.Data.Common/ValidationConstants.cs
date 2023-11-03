using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Data.Common
{
    public static class ValidationConstants
    {
        //Team name
        public const int TeamNameMaxLength = 50;

        //Team logo URL
        public const int TeamLogoURLMaxLength = 2000;

        //Team initials 
        public const int TeamInitialsMaxLength = 3;

        //Color name
        public const int ColorNameMaxLength = 30;

        //Town name
        public const int TownNameMaxLength = 100;

        //Country name
        public const int CountryNameMaxLength = 60;

        //Player name
        public const int PlayerNameMaxLength = 30;

        //Position name
        public const int PositionNameMaxLength = 50;

        //Game result
        public const int GameResultLength = 10;

        //User username
        public const int UserUserNameMaxLength = 40;

        //User password
        public const int UserPasswordMaxLength = 256;

        //User email
        public const int UserEmailMaxLength = 256;

        //User name
        public const int UserNameMaxLength = 50;
    }
}
