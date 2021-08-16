namespace LeadersCorner.Data.Common
{
    public class DataConstants
    {
        public class Author
        {
            public const int NameMin = 3;
            public const int NameMax = 25;
        }

        public class Article
        {
            public const int TitleMinLength = 10;
            public const int TitleMaxLength = 50;
            public const int ContentMinLength = 100;
        }

        public class Comment
        {
            public const int ContentMinLength = 2;
        }
      
        public class Course
        {
            public const int TitleMinLength = 7;
            public const int TitleMaxLength = 40;
            public const int ContentMinLength = 70;
        }
    }
}
