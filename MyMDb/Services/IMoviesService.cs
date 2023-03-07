using MyMDb.DTO;
using MyMDb.Models;

namespace MyMDb.Services
{
    public interface IMoviesService
    {
        Task<Movie> GetMovieAsync(Guid id);

        Task<List<MovieDTO>> GetTopRatedMoviesAsync(LoadMoviesDTO dto);

        Task<List<MovieDTO>> GetMoviesList();

        Task<Guid> CreateMovie(CreateMovieDTO movieDTO);

        Task<bool> AddToWatchlist(AddToWatchlistDTO dto);

        Task<List<MovieDTO>> GetMyWatchlist(string email);
    }
}
