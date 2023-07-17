

namespace VelvetLeaves.Common
{
    public static class ValidationConstants
    {
        public static class Product
        {
            public const int NameMinLength = 4;
            public const int NameMaxLength = 50;
            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 250;
        }

        public static class Category
        {
            public const int NameMinLength = 4;
            public const int NameMaxLength = 25;
        }

        public static class Gallery
        {
            public const int NameMinLength = 4;
            public const int NameMaxLength = 50;
            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 250;
            public const int GalleryMaxItems = 27;

        }

        public static class Image
        {
            public const int UrlMaxLength = 2048;
        }

        public static class Address
        {
            public const int CityMinLength = 2;
            public const int CityMaxLength = 40;
            public const int CountryMinLength = 3;
            public const int CountryMaxLength = 40;
            public const int StreetAddressMinLength = 5;
            public const int StreetAddressMaxLength = 100;        
        }

        public static class Color
        {
            public const int ColorLength = 6;
            public const int ColorNameMaxLenth = 40;
            public const int ColorNameMinLength = 3;
        }

        public static class AppPreferences
        {
            public const int RootProductsNameMinLength = 3;
            public const int RootProductsNameMaxLength = 20;
        }
    }
}
