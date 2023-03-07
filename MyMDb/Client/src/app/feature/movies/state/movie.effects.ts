import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { Store } from "@ngrx/store";
import { filter, map, mergeMap, Observable, switchMap, tap } from "rxjs";
import { CreateMovie } from "src/app/core/models/create-movie";
import { MoviesService } from "src/app/core/services/movies.service";
import { startSpinner, stopSpinner } from "src/app/shared/state/spinner/spinner.actions";
import { ISpinnerState } from "src/app/shared/state/spinner/spinner.reducers";
import { IMoviesState } from ".";
import { addToWatchlist, createMovie, loadMoviesList, loadTopRatedMovies, loadTopRatedMoviesSuccess } from "./actions";

@Injectable()
export class MoviesEffects {
    constructor(private actions$: Actions, private moviesService: MoviesService, private store: Store<IMoviesState>, private spinnerStore: Store<ISpinnerState>) { }

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
        tap((action) => this.spinnerStore.dispatch(startSpinner({spinnerId: action.movie.id}))),
        switchMap((action): Observable<any> => 
            { return this.moviesService.addToWatchlist(action.movie).pipe(map((data) => [data, action]))}
        ),
        tap((data) => this.spinnerStore.dispatch(stopSpinner({spinnerId: data[1].movie.id})))),
        {
            dispatch: false
        }
    )

    onLoadMoviesList$ = createEffect(()=> this.actions$.pipe(
        ofType(loadMoviesList),
        switchMap((action): Observable<any> => {
            const movies = this.moviesService.moviesList();
            return movies;
        }),
        tap(movies => {
            this.store.dispatch(loadTopRatedMoviesSuccess({movies: movies}));
        })
    ),
    {
        dispatch: false
    })
}