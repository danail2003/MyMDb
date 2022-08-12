namespace MyMDb.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MyMDb.DTO;
    using MyMDb.Services;

    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesService _moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTopRatedMovies()
        {
            var result = await _moviesService.GetTopRatedMoviesAsync();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie(CreateMovieDTO dto)
        {
            var result = await _moviesService.CreateMovie(dto);

            return Ok(result);
        }
    }
}
