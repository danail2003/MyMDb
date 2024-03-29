﻿namespace MyMDb.Controllers
{
    using Microsoft.AspNetCore.Authorization;
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

        [HttpPost("moviesList")]
        public async Task<IActionResult> MoviesList(Paging paging)
        {
            var result = await _moviesService.GetMoviesList(paging);

            return Ok(result);
        }

        [HttpPost("top")]
        public async Task<IActionResult> GetTopRated(MoviesParams dto)
        {
            var result = await _moviesService.GetTopRatedMoviesAsync(dto);

            return Ok(result);
        }

        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateMovie(CreateMovieDTO dto)
        {
            var result = await _moviesService.CreateMovie(dto);

            return Ok(result);
        }

        [HttpPost("watchlist")]
        public async Task<IActionResult> AddToWatchlist(AddToWatchlistDTO dto)
        {
            var result = await _moviesService.AddToWatchlist(dto);

            return Ok(result);
        }

        [HttpPost("myWatchlist")]
        public async Task<IActionResult> MyWatchlist(GetMyWatchlistDTO dto)
        {
            var result = await _moviesService.GetMyWatchlist(dto.Email);

            return Ok(result);
        }

        [HttpPost("removeFromWatchlist")]
        public async Task<IActionResult> RemoveFromWatchlist(RemoveFromWatchlistDTO dto)
        {
            var result = await _moviesService.RemoveFromWatchlist(dto);

            return Ok(result);
        }
    }
}
