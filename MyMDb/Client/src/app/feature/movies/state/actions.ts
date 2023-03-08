import { createAction, props } from "@ngrx/store";
import { AddToWatchlist } from "src/app/core/models/addToWatchlistDTO";
import { CreateMovie } from "src/app/core/models/create-movie";
import { LoadMoviesDTO } from "src/app/core/models/loadMoviesDTO";
import { RemoveFromWatchlistDTO } from "src/app/core/models/removeFromWatchlistDTO";
import { ITopRatedMovieState, MyWatchList } from ".";

const moviesDomain = '[Movies]';
export const loadTopRatedMovies = createAction(`${moviesDomain} Top Rated`, props<{email: LoadMoviesDTO}>());
export const loadTopRatedMoviesSuccess = createAction(`${moviesDomain} Successfully loaded movies`, props<ITopRatedMovieState>());
export const createMovie = createAction(`${moviesDomain} Create Movie`, props<{model: CreateMovie}>());
export const addToWatchlist = createAction(`${moviesDomain} Add to watchlist`, props<{movie: AddToWatchlist}>());
export const loadMoviesList = createAction(`${moviesDomain} Load MoviesList`);
export const removeFromWatchlist = createAction(`${moviesDomain} Remove from watchlist`, props<{userMovie: RemoveFromWatchlistDTO}>());
export const loadWatchlistSuccess = createAction(`${moviesDomain} Successfully loaded watchlist`, props<MyWatchList>());