using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenFlix.Data
{
    public class DataConstants
    {
        public class User
        {
            public const int FullNameMaxLenght = 30;
            public const int FullNameMinLenght = 5;
            public const int PasswordMaxLenght = 100;
            public const int PasswordMinLenght = 6;
        }

        public class Movie
        {
            public const int TitleMaxLenght = 50;
            public const int TitleMinLenght = 2;
            public const int GenreMaxLenght = 30;
            public const int GenreMinLenght = 2;
            public const int DirectorsMaxLenght = 30;
            public const int DirectorsMinLenght = 2;
            public const int WritersMaxLenght = 30;
            public const int WritersMinLenght = 2;
            public const int StarsMaxLenght = 30;
            public const int StarsMinLenght = 2;
            public const int DescriptionMinLenght = 10;
            public const int YearMaxValue = 2050;
            public const int YearMinValue = 1950;
        }

        public class Category
        {
            public const int NameMaxLenght = 30;
        }

        public class Provaider
        {
            public const int NameMaxLenght = 30;
            public const int NameMinLenght = 2;
            public const int PhoneNumberMaxLenght = 30;
            public const int PhoneNumberMinLenght = 6;
        }
    }
}
