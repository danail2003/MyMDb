import { createAction, props } from "@ngrx/store";
import { ITopRatedMovieState } from ".";

const moviesDomain = '[Movies]';
export const loadTopRatedMovies = createAction(`${moviesDomain} Top Rated`);
export const loadTopRatedMoviesSuccess = createAction(`${moviesDomain} Successfully loaded movies`, props<ITopRatedMovieState>());