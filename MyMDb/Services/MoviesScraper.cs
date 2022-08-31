namespace MyMDb.Services
{
    using Microsoft.EntityFrameworkCore;
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
            _config = Configuration.Default.WithDefaultLoader();
            _context = BrowsingContext.New(_config);
            _dbContext = dbContext;
        }

        public void ScrapeIMDbMovies()
        {
            var production = GetMovie();

            var productionItems = GetAllNeededItems(production);

            var genres = GetGenres(production);

            var actorsDocument = GetActors(production);

            List<Actor> actors = new();

            foreach (var actorDocument in actorsDocument)
            {
                var actorElements = GetActorItems(actorDocument);
                var actor = SetActor(actorElements);
                actors.Add(actor.Result);
            }

            var isTVShow = CheckWhetherDocumentIsTVShow(production);

            List<Movie> movies = new();
            List<TVShow> tvShows = new();

            SetProduction(isTVShow, productionItems, genres, actors, movies, tvShows);
        }

        private void SetProduction(bool isTVShow, Dictionary<string, string> productionItems,
            ICollection<string> genres, List<Actor> actors, List<Movie> movies, List<TVShow> tVShows)
        {
            var title = productionItems["Title"];

            if (_dbContext.Movies.Any(x => x.Name == title) || _dbContext.TVShows.Any(x => x.Name == title))
            {
                return;
            }

            if (isTVShow)
            {
                TVShow tvShow = null;

                foreach (var genreName in genres)
                {
                    tvShow.TVShowGenres.Add(new TVShowGenre
                    {
                        Genre = new Genre
                        {
                            Name = genreName,
                        },
                        TVShow = tvShow
                    });
                }

                foreach (var actorName in actors)
                {
                    
                }
            }
            else
            {
                movies.Add(new Movie
                {
                    Name = title,
                    Budget = productionItems["Budget"],
                    Country = productionItems["Country"],
                    Gross = productionItems["Gross"],
                    
                    Description = productionItems["Description"],
                    Duration = productionItems["Duration"],
                    ReleaseDate = DateTime.Parse(productionItems["ReleaseDate"]),
                    Rating = double.Parse(productionItems["Rating"]),
                    Year = int.Parse(productionItems["Year"]),
                    Image = productionItems["Image"],
                    Video = productionItems["Video"],
                    Actors = (ICollection<MovieActor>)actors,
                    IsReleased = DateTime.Parse(productionItems["ReleaseDate"]) > DateTime.Now
                });
            }
        }

        private static ICollection<string> GetGenres(IDocument document)
        {
            var genres = document.QuerySelectorAll(".sc-16ede01-3").Select(x => x.TextContent).ToList();

            return genres;
        }

        private IDocument GetMovie()
        {
            var document = _context
                .OpenAsync($"https://www.imdb.com/title/tt0068646/?ref_=nv_sr_srsg_0").GetAwaiter().GetResult();

            return document;
        }

        private Dictionary<string, string> GetAllNeededItems(IDocument document)
        {
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
            var image = document.QuerySelector(".ipc-image").GetAttribute("src");
            var video = Common.IMDbLink + document.QuerySelector(".sc-f0d4a9ac-2").GetAttribute("href");

            var actorItems = new Dictionary<string, string>();
            actorItems.Add("Title", title);
            actorItems.Add("Country", country);
            actorItems.Add("ReleaseDate", releaseDate);
            actorItems.Add("Budget", budget);
            actorItems.Add("Gross", gross);
            actorItems.Add("Description", description);
            actorItems.Add("Rating", rating);
            actorItems.Add("Year", year);
            actorItems.Add("Duration", duration);
            actorItems.Add("Image", image);
            actorItems.Add("Video", video);

            return actorItems;
        }

        private IHtmlCollection<IElement> GetActors(IDocument document)
        {
            var actors = document.QuerySelectorAll(".sc-36c36dd0-6");

            return actors;
        }

        private Dictionary<string, string> GetActorItems(IElement actorEl)
        {
            var currentActorLink = actorEl.QuerySelector(".ipc-lockup-overlay").GetAttribute("href");

            var actorDocument = _context.OpenAsync(Common.IMDbLink + currentActorLink).GetAwaiter().GetResult();

            var actorFirstAndLastName = actorDocument.QuerySelector(".itemprop").TextContent.Split(' ');
            var actorDescription = actorDocument.QuerySelector(".inline").TextContent.Trim();
            var actorImage = actorDocument.QuerySelector("#name-poster").GetAttribute("src");
            var actorCity = actorDocument.QuerySelector("#name-born-info").Children[2].TextContent.Split(", ").First();
            var actorCountry = actorDocument.QuerySelector("#name-born-info").Children[2].TextContent.Split(", ").Last();
            var actorDateOfBorn = actorDocument.QuerySelector("#name-born-info").Children[1].GetAttribute("datetime");

            var actorItems = new Dictionary<string, string>();
            actorItems.Add("FirstName", actorFirstAndLastName[0]);
            actorItems.Add("LastName", actorFirstAndLastName[1]);
            actorItems.Add("Description", actorDescription);
            actorItems.Add("Image", actorImage);
            actorItems.Add("City", actorCity);
            actorItems.Add("Country", actorCountry);
            actorItems.Add("DateOfBorn", actorDateOfBorn);

            return actorItems;
        }

        private bool CheckWhetherDocumentIsTVShow(IDocument document)
        {
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

            return isTVShow;
        }

        private async Task<Actor> SetActor(Dictionary<string, string> elements)
        {
            var currentActor = await _dbContext.Actors
                .FirstOrDefaultAsync(x => x.FirstName == elements.GetValueOrDefault("FirstName") && x.LastName == elements.GetValueOrDefault("LastName"));
            Actor newActor = null;

            if (currentActor == null)
            {
                var date = elements.GetValueOrDefault("DateOfBorn");
                DateTime result = DateTime.Parse(date);

                newActor = new Actor
                {
                    FirstName = elements.GetValueOrDefault("FirstName"),
                    LastName = elements.GetValueOrDefault("LastName"),
                    Description = elements.GetValueOrDefault("Description"),
                    Image = elements.GetValueOrDefault("Image"),
                    CityBorn = elements.GetValueOrDefault("City"),
                    CountryBorn = elements.GetValueOrDefault("Country"),
                    BornDate = result,
                };
            }
            else
            {
                newActor = currentActor;
            }

            return newActor;
        }
    }
}
