namespace MyMDb.Services
{
    using AngleSharp;

    public class MoviesScraper : IMoviesScraper
    {
        private readonly IBrowsingContext _context;
        private readonly IConfiguration _config;

        public MoviesScraper()
        {
            _config = Configuration.Default.WithDefaultLoader();
            _context = BrowsingContext.New(_config);
        }

        public async Task<int> ScrapeIMDbMovies()
        {
            var result = GetMovie();

            return result;
        }

        private int GetMovie()
        {
            var document = _context
                .OpenAsync($"https://www.imdb.com/title/tt0068646/?ref_=nv_sr_srsg_0").GetAwaiter().GetResult();

            var all = document.QuerySelector(".sc-b73cd867-0").TextContent;

            return 0;

        }
    }
}
