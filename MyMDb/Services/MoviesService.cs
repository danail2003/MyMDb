namespace MyMDb.Services
{
    using System.Net;

    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;

    using MyMDb.Constants;
    using MyMDb.DTO;
    using MyMDb.Models;

    public class MoviesService : IMoviesService
    {
        private readonly MyMDbContext context;

        public MoviesService(MyMDbContext context)
        {
            this.context = context;
        }

        public async Task<Guid> CreateMovie(CreateMovieDTO movieDTO)
        {
            var movie = new Movie
            {
                Name = movieDTO.Name,
                Description = movieDTO.Description,
                Duration = movieDTO.Duration,
                Year = movieDTO.Year,
                Rating = movieDTO.Rating,
                Image = movieDTO.Image,
            };

            await this.context.AddAsync(movie);
            await this.context.SaveChangesAsync();

            return movie.Id;
        }

        public async Task<Movie> GetMovieAsync(Guid id)
        {
            if (Guid.Empty == id)
            {
                throw new InvalidOperationException("Id is empty.");
            }

            var movie = await this.context.Movies.FirstOrDefaultAsync(x => x.Id == id);

            if (movie == null)
            {
                throw new ArgumentNullException("Id is not valid.");
            }

            return movie;
        }

        public async Task<List<MovieDTO>> GetTopRatedMoviesAsync()
        {
            var result = context.Movies.Select(x => new MovieDTO
            {
                Description = x.Description,
                Id = x.Id,
                Duration = x.Duration,
                Image = x.Image,
                Name = x.Name,
                Rating = x.Rating,
                Year = x.Year
            }).ToList();

            return result;
        }
    }
}
