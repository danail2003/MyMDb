using MyMDb.DTO;
using MyMDb.Models;

namespace MyMDb.Services
{
    public interface IMoviesService
    {
        Task<Movie> GetMovieAsync(Guid id);

        Task<List<IMDbMovieDTO>> GetTopRatedMoviesAsync();

        Task<Guid> CreateMovie(CreateMovieDTO movieDTO);
    }
}
