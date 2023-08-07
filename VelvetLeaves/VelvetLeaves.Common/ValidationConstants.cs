

namespace VelvetLeaves.Common
{
    public static class ValidationConstants
    {
        public static class Common
        {
            public const string StringInputRegex = @"[\w\-]+";
            public const string StringInputRegexErrorMessage = "Invalid symbol in name.";
        }
        
        public static class Product
        {
            public const int NameMinLength = 4;
            public const int NameMaxLength = 50;
            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 250;

            public const double MinPrice = 0.01;
            public const double MaxPrice = 999999.99;
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
            public const int IdMaxLength = 24;
        }

        public static class Address
        {
            public const int CityMinLength = 2;
            public const int CityMaxLength = 40;
            public const int CountryMinLength = 3;
            public const int CountryMaxLength = 40;
            public const int StreetAddressMinLength = 5;
            public const int StreetAddressMaxLength = 100;
            public const int ZipCodeMinLength = 3;
            public const int ZipCodeMaxLength = 8;
            public const int FirstNameMinLength = 2;
            public const int FirstNameMaxLength = 20;
            public const int LastNameMinLength = 2;
            public const int LastNameMaxLength = 20;
            public const int PhoneNumberMinLength = 3;
            public const int PhoneNumberMaxLength = 15;

            public const string PhoneRegex = @"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$";

        }

        public static class Color
        {
            public const int ColorLength = 7;
            public const int ColorNameMaxLenth = 40;
            public const int ColorNameMinLength = 3;
        }

        public static class AppPreferences
        {
            public const int RootProductsNameMinLength = 3;
            public const int RootProductsNameMaxLength = 20;
            public const int CurrencyMinLength = 1;
            public const int CurrencyMaxLength = 5;
        }

        public static class Material
        {
            public const int NameMaxLength = 40;
            public const int NameMinLength = 3;
        }

        public static class Tag
		{
            public const int NameMaxLength = 40;
            public const int NameMinLength = 3;
		}

        public static class ProductSeries
        {
            public const int NameMaxLength = 40;
            public const int NameMinLength = 3;
        }

        public static class Order
        {
            public const int NoteMinLength = 0;
            public const int NoteMaxLength = 255;
            public const int EmailMinLength = 5;
            public const int EmailMaxLength = 320;
        }
    }
}
