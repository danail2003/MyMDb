using MyMDb.DTO;
using MyMDb.Models;

namespace MyMDb.Services
{
    public interface IMoviesService
    {
        Task<Movie> GetMovie(Guid id);

        Task<IEnumerable<MovieDTO>> GetTopRatedMovies();

        Task<IEnumerable<MovieDTO>> GetMostGrossedMovies();

        Task<IEnumerable<MovieDTO>> GetComingSoonMovies();
    }
}
