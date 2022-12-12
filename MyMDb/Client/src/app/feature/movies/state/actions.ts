import { createAction, props } from "@ngrx/store";
import { AddToWatchlist } from "src/app/core/models/addToWatchlistDTO";
import { CreateMovie } from "src/app/core/models/create-movie";
import { LoadMoviesDTO } from "src/app/core/models/loadMoviesDTO";
import { ITopRatedMovieState } from ".";

const moviesDomain = '[Movies]';
export const loadTopRatedMovies = createAction(`${moviesDomain} Top Rated`, props<{email: LoadMoviesDTO}>());
export const loadTopRatedMoviesSuccess = createAction(`${moviesDomain} Successfully loaded movies`, props<ITopRatedMovieState>());
export const createMovie = createAction(`${moviesDomain} Create Movie`, props<{model: CreateMovie}>());
export const addToWatchlist = createAction(`${moviesDomain} Add to watchlist`, props<{movie: AddToWatchlist}>());