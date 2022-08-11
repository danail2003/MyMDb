using MyMDb.DTO;
using MyMDb.Models;

namespace MyMDb.Services
{
    public interface IMoviesService
    {
        Task<Movie> GetMovieAsync(Guid id);

        Task<IEnumerable<MovieDTO>> GetTopRatedMoviesAsync();

        Task<IEnumerable<MovieDTO>> GetMostGrossedMoviesAsync();

        Task<IEnumerable<MovieDTO>> GetComingSoonMoviesAsync();

        Task<Guid> CreateMovie(CreateMovieDTO movieDTO);
    }
}
