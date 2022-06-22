using Microsoft.EntityFrameworkCore;
using MyMDb.DTO;
using MyMDb.Models;

namespace MyMDb.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly MyMDbContext context;

        public MoviesService(MyMDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<MovieDTO>> GetComingSoonMovies()
        {
            return await this.context.Movies.OrderByDescending(x => x.ReleaseDate).Select(x => new MovieDTO
            {
                Id = x.Id,
                Name = x.Name,
                ImageId = x.ImageId,
                Description = x.Description,
                Duration = x.Duration,
                Actors = x.Actors,
                Budget = x.Budget,
                Country = x.Country,
                Genres = x.Genres,
                Gross = x.Gross,
                Rating = x.Rating,
                VideoUrl = x.VideoUrl,
                Year = x.Year,
            }).ToListAsync();
        }

        public async Task<IEnumerable<MovieDTO>> GetMostGrossedMovies()
        {
            return await this.context.Movies.OrderByDescending(x => x.Gross).Take(50).Select(x => new MovieDTO
            {
                Id = x.Id,
                Name = x.Name,
                ImageId = x.ImageId,
                Description = x.Description,
                Duration = x.Duration,
                Actors = x.Actors,
                Budget = x.Budget,
                Country = x.Country,
                Genres = x.Genres,
                Gross = x.Gross,
                Rating = x.Rating,
                VideoUrl = x.VideoUrl,
                Year = x.Year,
            }).ToListAsync();
        }

        public async Task<Movie> GetMovie(Guid id)
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

        public async Task<IEnumerable<MovieDTO>> GetTopRatedMovies()
        {
            return await this.context.Movies.OrderByDescending(x => x.Rating).Select(x => new MovieDTO
            {
                Id = x.Id,
                Name = x.Name,
                ImageId = x.ImageId,
                Description = x.Description,
                Duration = x.Duration,
                Actors = x.Actors,
                Budget = x.Budget,
                Country = x.Country,
                Genres = x.Genres,
                Gross = x.Gross,
                Rating = x.Rating,
                VideoUrl = x.VideoUrl,
                Year = x.Year,
            }).ToListAsync();
        }
    }
}
