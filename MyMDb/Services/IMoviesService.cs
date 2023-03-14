using MyMDb.DTO;
using MyMDb.Models;

namespace MyMDb.Services
{
    public interface IMoviesService
    {
        Task<Movie> GetMovieAsync(Guid id);

        Task<PagedResult> GetTopRatedMoviesAsync(MoviesParams dto);

        Task<PagedResult> GetMoviesList(Paging paging);

        Task<Guid> CreateMovie(CreateMovieDTO movieDTO);

        Task<bool> AddToWatchlist(AddToWatchlistDTO dto);

        Task<List<MovieDTO>> RemoveFromWatchlist(RemoveFromWatchlistDTO dto);

        Task<List<MovieDTO>> GetMyWatchlist(string email);
    }
}
