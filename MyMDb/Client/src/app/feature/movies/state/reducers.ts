import { createReducer, on } from "@ngrx/store";
import { Movie } from "src/app/core/models/movie";
import { RemoveFromWatchlistDTO } from "src/app/core/models/removeFromWatchlistDTO";
import { startSpinner, stopSpinner } from "src/app/shared/state/spinner/spinner.actions";
import { IMoviesState } from ".";
import { addToWatchlist, loadTopRatedMoviesSuccess, loadWatchlistSuccess, removeFromWatchlist } from "./actions";

const loadSpinner = (state: any, action: any, isLoading: boolean) => {
    let movies = [...state.topRatedMovies.movies];
    const index = movies.findIndex(movie => movie.id == action.spinnerId);
    movies[index] = { ...movies[index], isLoading };

    return [...movies];
}

const changeMovie = (state: any, action: any) => {
    const movieId = action.movie.id;
    const movies: Movie[] = [...state.topRatedMovies.movies].map(m => ({ ...m }));

    const index = movies.findIndex(movie => movie.id == movieId);
    const movie: Movie = movies[index];
    movie.isInWatchlist = !movie.isInWatchlist;

    return [...movies];
};

function removeEntry(userMovie: RemoveFromWatchlistDTO, movies: Movie[]): Movie[] {
    const newMovies = movies.filter(m => m.id !== userMovie.movieId);
    return newMovies;
}

export const movieReducer = createReducer<IMoviesState>({
    topRatedMovies: { movies: [] },
    watchlist: { movies: [] }
},
    on(loadTopRatedMoviesSuccess, (state, action) => {
        return {
            topRatedMovies: { movies: action.movies },
            watchlist: { movies: [] }
        }
    }),
    on(addToWatchlist, (state, action) => {
        return {
            topRatedMovies: { movies: changeMovie(state, action) },
            watchlist: { movies: [] }
        }
    }
    ),
    on(startSpinner, (state, action) => {
        return {
            topRatedMovies: { movies: loadSpinner(state, action, true) },
            watchlist: { movies: [] }
        }
    }),
    on(stopSpinner, (state, action) => {
        return {
            topRatedMovies: { movies: loadSpinner(state, action, false) },
            watchlist: { movies: [] }
        }
    }),
    on(loadWatchlistSuccess, (state, action) => {
        return {
            topRatedMovies: { movies: [] },
            watchlist: { movies: action.movies }
        }
    }),
    on(removeFromWatchlist, (state, action) => {
        return {
            topRatedMovies: { movies: [] },
            watchlist: { movies: removeEntry(action.userMovie, state.watchlist.movies) }
        }
    })
)
