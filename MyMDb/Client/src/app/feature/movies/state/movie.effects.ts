import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { Store } from "@ngrx/store";
import { filter, mergeMap, tap } from "rxjs";
import { MoviesService } from "src/app/core/services/movies.service";
import { IMoviesState } from ".";
import { loadTopRatedMovies, loadTopRatedMoviesSuccess } from "./actions";

@Injectable()
export class MoviesEffects {
    constructor(private actions: Actions, private moviesService: MoviesService, private store: Store<IMoviesState>) { }

    onLoadingTopRatedMovies$ = createEffect(() =>
        this.actions.pipe(ofType(loadTopRatedMovies),
        tap(x => console.log('hello')),
            mergeMap(() => {
                const movies = this.moviesService.loadTopRatedMovies();
                return movies;
            }),
            tap(movies => {
                this.store.dispatch(loadTopRatedMoviesSuccess({movies: movies}));
            })),
        {
            dispatch: false
        }
    )
}