import { createAction, props } from "@ngrx/store";
import { AddToWatchlist } from "src/app/core/models/addToWatchlistDTO";
import { CreateMovie } from "src/app/core/models/create-movie";
import { LoadMoviesDTO } from "src/app/core/models/loadMoviesDTO";
import { MoviesParams } from "src/app/core/models/moviesParamas";
import { Paging } from "src/app/core/models/paging";
import { RemoveFromWatchlistDTO } from "src/app/core/models/removeFromWatchlistDTO";
import { ITopRatedMovieState, MyWatchList } from ".";

const moviesDomain = '[Movies]';
export const loadTopRatedMovies = createAction(`${moviesDomain} Top Rated`, props<{ params: MoviesParams }>());
export const loadTopRatedMoviesSuccess = createAction(`${moviesDomain} Successfully loaded movies`, props<ITopRatedMovieState>());
export const createMovie = createAction(`${moviesDomain} Create Movie`, props<{ model: CreateMovie }>());
export const addToWatchlist = createAction(`${moviesDomain} Add to watchlist`, props<{ movie: AddToWatchlist }>());
export const loadMoviesList = createAction(`${moviesDomain} Load MoviesList`, props<{ paging: Paging }>());
export const removeFromWatchlist = createAction(`${moviesDomain} Remove from watchlist`, props<{ userMovie: RemoveFromWatchlistDTO }>());
export const loadWatchlist = createAction(`${moviesDomain} Load watchlist`, props<{ email: string }>())
export const loadWatchlistSuccess = createAction(`${moviesDomain} Successfully loaded watchlist`, props<MyWatchList>());
export const totalMoviesCount = createAction(`${moviesDomain} Movies count`, props<{ count: number }>());