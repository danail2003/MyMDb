export * from './actions';
export * from './reducers';
export * from './selectors';
export * from './movie.effects';

import { Movie } from "src/app/core/models/movie";

export interface ITopRatedMovieState {
    movies: Movie[];
    total: number;
}

export interface MyWatchList {
    movies: Movie[];
}

export interface IMoviesState {
    topRatedMovies: ITopRatedMovieState;
    watchlist: MyWatchList;
}