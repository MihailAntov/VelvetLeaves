

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
    }
}
