import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { Store } from "@ngrx/store";
import { filter, mergeMap, switchMap, tap } from "rxjs";
import { CreateMovie } from "src/app/core/models/create-movie";
import { MoviesService } from "src/app/core/services/movies.service";
import { IMoviesState } from ".";
import { addToWatchlist, createMovie, loadTopRatedMovies, loadTopRatedMoviesSuccess } from "./actions";

@Injectable()
export class MoviesEffects {
    constructor(private actions$: Actions, private moviesService: MoviesService, private store: Store<IMoviesState>) { }

    onLoadingTopRatedMovies$ = createEffect(() =>
        this.actions$.pipe(ofType(loadTopRatedMovies),
            mergeMap((action) => {
                const movies = this.moviesService.loadTopRatedMovies(action.email);
                return movies;
            }),
            tap(movies => {
                this.store.dispatch(loadTopRatedMoviesSuccess({ movies: movies }));
            })),
        {
            dispatch: false
        }
    )

    onCreateMovies$ = createEffect(() => this.actions$.pipe(
        ofType(createMovie),
        switchMap(movie =>
            this.moviesService.createMovie(movie.model)
        )),
        {
            dispatch: false
        }
    );

    onAddToWatchList$ = createEffect(() => this.actions$.pipe(
        ofType(addToWatchlist),
        switchMap(action =>
            this.moviesService.addToWatchlist(action.movie)
        )),
        {
            dispatch: false
        }
    )
}