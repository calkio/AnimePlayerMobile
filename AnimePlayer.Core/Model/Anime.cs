namespace AnimePlayer.Core.Domain
{
    public class Anime
    {
        public int Id { get; private set; }
        public string ImageUrl { get; private set; }
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public int YearRelease { get; private set; }
        public double Rating { get; private set; }

        public const int MIN_YEAR_RELEASE = 1900;
        public const int MAX_YEAR_RELEASE = 2100;
        public const double MIN_RATING = 0;
        public const double MAX_RATING = 10;

        private Anime() { } // Для EF Core

        private Anime(string imageUrl, string title, string? description, int yearRelease, double rating)
        {
            ImageUrl = imageUrl;
            Title = title;
            Description = description;
            YearRelease = yearRelease;
            Rating = rating;
        }

        public static (Anime anime, string error) Create(
            string imageUrl,
            string title,
            string? description,
            int yearRelease,
            double rating)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(imageUrl))
                errors.Add("Нет фото");

            if (string.IsNullOrWhiteSpace(title))
                errors.Add("Название аниме обязательно");

            if (yearRelease < MIN_YEAR_RELEASE || yearRelease > MAX_YEAR_RELEASE)
                errors.Add($"Год релиза должен быть между {MIN_YEAR_RELEASE} и {MAX_YEAR_RELEASE}");

            if (rating < MIN_RATING || rating > MAX_RATING)
                errors.Add($"Рейтинг должен быть между {MIN_RATING} и {MAX_RATING}");

            if (errors.Any())
                return (null, string.Join("; ", errors));

            return (new Anime(imageUrl, title, description, yearRelease, rating), null);
        }

        public (bool success, string error) Update(
            string imageUrl,
            string title,
            string? description,
            int yearRelease,
            double rating)
        {
            var (anime, error) = Create(imageUrl, title, description, yearRelease, rating);
            if (!string.IsNullOrEmpty(error))
                return (false, error);

            ImageUrl = imageUrl;
            Title = title;
            Description = description;
            YearRelease = yearRelease;
            Rating = rating;

            return (true, null);
        }
    }

}