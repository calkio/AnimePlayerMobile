namespace AnimePlayer.Core.Model
{
    public class Anime
    {
        public static readonly int MIN_YEAR_RELEASE = 1900;
        public static readonly int MAX_YEAR_RELEASE = DateTime.Now.Year;

        public static readonly int MIN_RATING = 0;
        public static readonly int MAX_RATING = 10;


        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public int YearRelease { get; set; }
        public double Rating { get; set; }

        public Anime(string title, string? description, int yearRelease, double rating)
        {
            Title = title;
            Description = description;
            YearRelease = yearRelease;
            Rating = rating;
        }

        public static (Anime, string error) CreateAnime(string title, string? description, int yearRelease, double rating)
        {
            string errorString = string.Empty;

            if (string.IsNullOrEmpty(title))
            {
                errorString = "Нет названия аниме";
            }
            if (yearRelease > MIN_YEAR_RELEASE && yearRelease <= MAX_YEAR_RELEASE)
            {
                errorString = "Год релиза аниме не валидный";
            }
            if (rating > MIN_RATING && rating <= MAX_RATING)
            {
                errorString = "Рейтинг аниме не валидный";
            }

            Anime anime = new Anime(title, description, yearRelease, rating);

            return (anime, errorString);
        }
    }
}
