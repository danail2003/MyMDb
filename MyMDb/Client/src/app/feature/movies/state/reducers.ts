import { createReducer, on } from "@ngrx/store";
import { IMoviesState } from ".";
import { loadTopRatedMoviesSuccess } from "./actions";

export const movieReducer = createReducer<IMoviesState>({
    topRatedMovies: { movies: [] }
},
    on(loadTopRatedMoviesSuccess, (state, action) => {
        return {
            topRatedMovies: { movies: action.movies }
        }
    })
)