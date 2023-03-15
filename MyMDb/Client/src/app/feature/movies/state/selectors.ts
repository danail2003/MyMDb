import { createFeatureSelector, createSelector } from "@ngrx/store";
import { IMoviesState } from ".";

export const getTopRatedMoviesFeature = createFeatureSelector<IMoviesState>('movie');
export const getTopRatedMoviesSelector = createSelector(getTopRatedMoviesFeature, (state) => state.topRatedMovies.movies);
export const getMyWatchlist = createSelector(getTopRatedMoviesFeature, (state) => state.watchlist.movies);
export const getTotalMoviesCount = createSelector(getTopRatedMoviesFeature, (state) => state.topRatedMovies.total);