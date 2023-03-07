namespace MyMDb.Services
{
    using AngleSharp;
    using AngleSharp.Dom;

    using MyMDb.Constants;
    using MyMDb.Models;

    public class MoviesScraper : IMoviesScraper
    {
        private readonly MyMDbContext _dbContext;
        private readonly IBrowsingContext _context;
        private readonly IConfiguration _config;

        public MoviesScraper(MyMDbContext dbContext)
        {
            _config = Configuration.Default.WithDefaultLoader(new AngleSharp.Io.LoaderOptions { IsResourceLoadingEnabled = true });
            _context = BrowsingContext.New(_config);
            _dbContext = dbContext;
        }

        public void PopulateDbWithMoviesAndTVShows()
        {
            for (int i = Common.BeginingOfScraping; i <= Common.EndOfScraping; i += Common.IncrementingOfScraping)
            {
                ScrapeIMDbMovies(i);
            }
        }

        public void ScrapeIMDbMovies(int number)
        {
            IDocument movies;

            if (number == Common.BeginingOfScraping)
            {
                movies = GetFirstMovies();
            }
            else
            {
                movies = GetMovies(number);
            }

            var movieItems = GetAllNeededItems(movies);

            var genres = GetGenres(movies);

            var actorsDocument = GetActors(movies);

            for (int i = 0; i < movieItems["Title"].Count; i++)
            {
                Console.WriteLine(i);
                SetMovie(movieItems, genres, actorsDocument, i);
            }
        }

        private IDocument GetFirstMovies()
        {
            var document = _context
                .OpenAsync($"https://www.imdb.com/search/title/?groups=top_1000&sort=user_rating,desc&count=100&ref_=adv_prv").GetAwaiter().GetResult();

            return document;
        }

        private IDocument GetMovies(int number)
        {
            Task.Delay(3000);
            var document = _context
                .OpenAsync($"https://www.imdb.com/search/title/?groups=top_1000&sort=user_rating,desc&count=100&start={number}01&ref_=adv_nxt").GetAwaiter().GetResult();

            return document;
        }

        private static Dictionary<string, List<string>> GetAllNeededItems(IDocument document)
        {
            var titles = document.QuerySelectorAll(".lister-item-header").Select(x => x.Children[1].TextContent).ToList();
            var years = document.QuerySelectorAll(".lister-item-header").Select(x => x.Children[2].TextContent
            .Replace("(I) ", "").Replace("(II) ", "").Replace("(III) ", "").Replace("(", "").Replace(")", "")).ToList();
            var descriptions = document.QuerySelectorAll(".lister-item-content").Select(x => x.Children[3].TextContent.Trim()).ToList();
            var ratings = document.QuerySelectorAll(".ratings-imdb-rating").Select(x => x.Children[1].TextContent).ToList();
            var durations = document.QuerySelectorAll(".runtime").Select(x => x.TextContent).ToList();
            var imagesUrl = document.QuerySelectorAll(".lister-item-image > a > img").Select(x => x.GetAttribute("loadlate"));
            var images = new List<string>();

            foreach (var image in imagesUrl)
            {
                images.Add(image);
            }

            var movieItems = new Dictionary<string, List<string>>
            {
                { "Title", titles },
                { "Description", descriptions },
                { "Rating", ratings },
                { "Year", years },
                { "Duration", durations },
                { "Image", images }
            };

            return movieItems;
        }

        private static List<string> GetGenres(IDocument document)
        {
            var genres = document.QuerySelectorAll(".genre").Select(x => x.TextContent.Trim()).ToList();

            return genres;
        }

        private static List<IEnumerable<string>> GetActors(IDocument document)
        {
            var actors = document.QuerySelectorAll(".lister-item-content").Select(x => x.Children[4].Children.Select(x => x.TextContent).Skip(2)).ToList();

            return actors;
        }

        private void SetMovie(Dictionary<string, List<string>> movieItems, List<string> genres, List<IEnumerable<string>> actors, int numberOfMovie)
        {
            if (_dbContext.Movies.Any(x => x.Name.Equals(movieItems["Title"][numberOfMovie])))
            {
                return;
            }

            var movie = new Movie
            {
                Name = movieItems["Title"][numberOfMovie],
                Description = movieItems["Description"][numberOfMovie],
                Duration = movieItems["Duration"][numberOfMovie],
                Image = movieItems["Image"][numberOfMovie],
                Rating = double.Parse(movieItems["Rating"][numberOfMovie]),
                Year = int.Parse(movieItems["Year"][numberOfMovie]),
                Genres = genres[numberOfMovie],
                Actors = string.Join(", ", actors[numberOfMovie]),
            };

            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();
        }
    }
}
