namespace MyMDb.Services
{
    using Microsoft.EntityFrameworkCore;

    using MyMDb.DTO;
    using MyMDb.Models;

    public class MoviesService : IMoviesService
    {
        private readonly MyMDbContext context;

        public MoviesService(MyMDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<MovieDTO>> GetComingSoonMoviesAsync()
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

        public async Task<IEnumerable<MovieDTO>> GetMostGrossedMoviesAsync()
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

        public async Task<IEnumerable<MovieDTO>> GetTopRatedMoviesAsync()
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
