namespace MyMDb.Services
{
    using AngleSharp;
    using MyMDb.Constants;

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

            var isTVShow = true;

            try
            {
                var type = document.QuerySelector(".episode-guide-text").TextContent;
            }
            catch (Exception ex)
            {
                isTVShow = false;
                Console.WriteLine(ex.Message);
            }

            var title = document.QuerySelector(".sc-b73cd867-0").TextContent;
            var country = document.QuerySelectorAll(".sc-f65f65be-0 > .ipc-metadata-list > .ipc-metadata-list__item > .ipc-metadata-list-item__content-container")[4].TextContent;
            var indexOfParanthesisOfReleaseDate = document.QuerySelectorAll(".sc-f65f65be-0 > .ipc-metadata-list > .ipc-metadata-list__item > .ipc-metadata-list-item__content-container")[3].TextContent.IndexOf('(');
            var releaseDate = document.QuerySelectorAll(".sc-f65f65be-0 > .ipc-metadata-list > .ipc-metadata-list__item > .ipc-metadata-list-item__content-container")[3].TextContent.Substring(0, indexOfParanthesisOfReleaseDate - 1);
            var indexOfParanthesisOfBudget = document.QuerySelectorAll(".sc-f65f65be-0 > .ipc-metadata-list > .ipc-metadata-list__item > .ipc-metadata-list-item__content-container")[10].TextContent.IndexOf('(');
            var budget = document.QuerySelectorAll(".sc-f65f65be-0 > .ipc-metadata-list > .ipc-metadata-list__item > .ipc-metadata-list-item__content-container")[10].TextContent.Substring(0, indexOfParanthesisOfBudget - 1);
            var gross = document.QuerySelectorAll(".sc-f65f65be-0 > .ipc-metadata-list > .ipc-metadata-list__item > .ipc-metadata-list-item__content-container")[13].TextContent;
            var description = document.QuerySelector(".sc-16ede01-0").TextContent;
            var rating = document.QuerySelector(".sc-7ab21ed2-1").TextContent;
            var year = document.QuerySelector(".sc-8c396aa2-2").TextContent;
            var duration = document.QuerySelector(".sc-8c396aa2-0").ChildNodes.Last().TextContent;
            var genres = document.QuerySelectorAll(".sc-16ede01-3").Select(x => x.TextContent).ToList();
            var image = document.QuerySelector(".ipc-image").GetAttribute("src");
            var video = Common.IMDbLink + document.QuerySelector(".sc-f0d4a9ac-2").GetAttribute("href");

            var actors = document.QuerySelectorAll(".sc-36c36dd0-6");

            foreach (var actor in actors)
            {
                var currentActorLink = actor.QuerySelector(".ipc-lockup-overlay").GetAttribute("href");

                var actorDocument = _context.OpenAsync(Common.IMDbLink + currentActorLink).GetAwaiter().GetResult();
            }

            return 0;

        }
    }
}
