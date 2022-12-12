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
                Country = movieDTO.Country,
                ReleaseDate = movieDTO.ReleaseDate,
                Video = movieDTO.Video,
                Genres = movieDTO.Genres,
                Actors = movieDTO.Actors,
                Budget = movieDTO.Budget,
                Gross = movieDTO.Gross,
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

        public async Task<List<MovieDTO>> GetTopRatedMoviesAsync(LoadMoviesDTO dto)
        {
            var user = context.Users.FirstOrDefault(x => x.Email == dto.Email);

            if (user == null)
            {
                throw new InvalidOperationException("User does not exists!");
            }

            var result = context.Movies.Select(x => new MovieDTO
            {
                Description = x.Description,
                Id = x.Id,
                Duration = x.Duration,
                Image = x.Image,
                Name = x.Name,
                Rating = x.Rating,
                Year = x.Year,
                IsInWatchlist = context.UsersMovies.FirstOrDefault(m => m.MovieId == x.Id && m.UserId == user.Id) != null
            }).ToList();

            return result;
        }

        public async Task<bool> AddToWatchlist(AddToWatchlistDTO dto)
        {
            var movie = await context.Movies.FirstOrDefaultAsync(x => x.Id == dto.Id);

            if (movie == null)
            {
                throw new InvalidOperationException("Movie does not exists!");
            }

            var user = await this.context.Users.FirstOrDefaultAsync(x => x.Email == dto.Email);

            if (user == null)
            {
                throw new InvalidOperationException("User does not exists!");
            }

            var isInWatchlist = context.UsersMovies.FirstOrDefault(x => x.MovieId == dto.Id && x.UserId == user.Id);

            if (dto.IsChecked && isInWatchlist == null)
            {
                context.UsersMovies.Add(new UserMovie { Movie = movie, User = user });
            }
            else if (!dto.IsChecked && isInWatchlist != null)
            {
                context.UsersMovies.Remove(isInWatchlist);
            }

            await context.SaveChangesAsync();

            return dto.IsChecked;
        }
    }
}
