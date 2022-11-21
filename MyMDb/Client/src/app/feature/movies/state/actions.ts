import { createAction, props } from "@ngrx/store";
import { CreateMovie } from "src/app/core/models/create-movie";
import { ITopRatedMovieState } from ".";

const moviesDomain = '[Movies]';
export const loadTopRatedMovies = createAction(`${moviesDomain} Top Rated`);
export const loadTopRatedMoviesSuccess = createAction(`${moviesDomain} Successfully loaded movies`, props<ITopRatedMovieState>());
export const createMovie = createAction(`${moviesDomain} Create Movie`, props<{model: CreateMovie}>());