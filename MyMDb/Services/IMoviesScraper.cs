namespace MyMDb.Services
{
    public interface IMoviesScraper
    {
        Task<int> ScrapeIMDbMovies();
    }
}
