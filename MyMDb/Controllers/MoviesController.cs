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

        [HttpGet("top")]
        public async Task<IActionResult> GetTopRated()
        {
            var result = await _moviesService.GetTopRatedMoviesAsync();

            return Ok(result);
        }

        [HttpGet("most")]
        public async Task<IActionResult> GetMostGrossed()
        {
            var result = await _moviesService.GetMostGrossedMoviesAsync();

            return Ok(result);
        }

        [HttpGet("soon")]
        public async Task<IActionResult> GetComingSoon()
        {
            var result = await _moviesService.GetComingSoonMoviesAsync();

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
