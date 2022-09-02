namespace MyMDb.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using MyMDb.Services;

    [Route("api/[controller]")]
    [ApiController]
    public class MovieScraperController : ControllerBase
    {
        private readonly IMoviesScraper _movieScraper;

        public MovieScraperController(IMoviesScraper movieScraper)
        {
            _movieScraper = movieScraper;
        }

        [HttpGet]
        public IActionResult ScrapeMovies()
        {
            _movieScraper.PopulateDbWithMoviesAndTVShows();

            return Ok();
        }
    }
}
