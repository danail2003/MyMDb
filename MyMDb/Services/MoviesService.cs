namespace MyMDb.Services
{
    using System.Globalization;
    using Microsoft.EntityFrameworkCore;

    using MyMDb.DTO;
    using MyMDb.Models;
    using MyMDb.Constants;

    public class MoviesService : IMoviesService
    {
        private readonly MyMDbContext context;

        public MoviesService(MyMDbContext context)
        {
            this.context = context;
        }

        public async Task<Guid> CreateMovie(CreateMovieDTO movieDTO)
        {
            var embedVideoUrl = movieDTO.Video.Replace(Common.ReplacedValueOfVideoUrl, Common.EmbedOfVideoUrl);

            DateTime? releaseDate = DateTime.UtcNow;

            if (!string.IsNullOrWhiteSpace(movieDTO.ReleaseDate))
            {
                var isDateTimeValid = DateTime.TryParseExact(movieDTO.ReleaseDate, "d", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime nonNullDate);

                if (isDateTimeValid)
                {
                    releaseDate = nonNullDate;
                }
                else
                {
                    releaseDate = null;
                }
            }

            var movie = new Movie
            {
                Name = movieDTO.Name,
                Description = movieDTO.Description,
                Duration = movieDTO.Duration,
                Budget = movieDTO.Budget,
                Country = movieDTO.Country,
                Year = movieDTO.Year,
                Gross = movieDTO.Gross,
                Rating = movieDTO.Rating,
                Image = movieDTO.Image,
                Video = embedVideoUrl,
                ReleaseDate = releaseDate,
                IsReleased = movieDTO.IsReleased,
                //Genres = movieDTO.Genres,
                //Actors = movieDTO.Actors,
            };

            await this.context.AddAsync(movie);
            await this.context.SaveChangesAsync();

            return movie.Id;
        }

        public async Task<IEnumerable<MovieDTO>> GetComingSoonMoviesAsync()
        {
            return await this.context.Movies.OrderByDescending(x => x.ReleaseDate).Select(x => new MovieDTO
            {
                Id = x.Id,
                Name = x.Name,
                Image = x.Image,
                Description = x.Description,
                Duration = x.Duration,
                Actors = x.Actors,
                Budget = x.Budget,
                Country = x.Country,
                Genres = x.Genres,
                Gross = x.Gross,
                Rating = x.Rating,
                Video = x.Video,
                Year = x.Year,
            }).ToListAsync();
        }

        public async Task<IEnumerable<MovieDTO>> GetMostGrossedMoviesAsync()
        {
            return await this.context.Movies.OrderByDescending(x => x.Gross).Take(50).Select(x => new MovieDTO
            {
                Id = x.Id,
                Name = x.Name,
                Image = x.Image,
                Description = x.Description,
                Duration = x.Duration,
                Actors = x.Actors,
                Budget = x.Budget,
                Country = x.Country,
                Genres = x.Genres,
                Gross = x.Gross,
                Rating = x.Rating,
                Video = x.Video,
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
            return await this.context.Movies.OrderByDescending(x => x.Rating).Take(250).Select(x => new MovieDTO
            {
                Id = x.Id,
                Name = x.Name,
                Image = x.Image,
                Description = x.Description,
                Duration = x.Duration,
                Actors = x.Actors,
                Budget = x.Budget,
                Country = x.Country,
                Genres = x.Genres,
                Gross = x.Gross,
                Rating = x.Rating,
                Video = x.Video,
                Year = x.Year,
            }).ToListAsync();
        }
    }
}
