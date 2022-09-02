using MyMDb.DTO;
using MyMDb.Models;

namespace MyMDb.Services
{
    public interface IMoviesService
    {
        Task<Movie> GetMovieAsync(Guid id);

        Task<IEnumerable<MovieDTO>> GetTopRatedMoviesAsync();

        Task<Guid> CreateMovie(CreateMovieDTO movieDTO);
    }
}
