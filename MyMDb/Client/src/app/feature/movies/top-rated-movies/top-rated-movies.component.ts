import { Component, Input, OnInit } from '@angular/core';
import { MatCheckboxChange } from '@angular/material/checkbox';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { AddToWatchlist } from 'src/app/core/models/addToWatchlistDTO';
import { Movie } from 'src/app/core/models/movie';
import { AuthService } from 'src/app/core/services/auth.service';
import { startSpinner, stopSpinner } from 'src/app/shared/state/spinner/spinner.actions';
import { ISpinnerState } from 'src/app/shared/state/spinner/spinner.reducers';
import { getIsSpinnerLoading } from 'src/app/shared/state/spinner/spinner.selectors';
import { addToWatchlist, IMoviesState } from '../state';

@Component({
  selector: 'app-top-rated-movies',
  templateUrl: './top-rated-movies.component.html',
  styleUrls: ['./top-rated-movies.component.css']
})
export class TopRatedMoviesComponent implements OnInit {
  @Input() movie!: Movie;
  @Input() index!: number;
  public checked!: boolean;
  public isLoading$: Observable<boolean>;
  public isLoading: boolean = false;
  constructor(private authService: AuthService, private store: Store<IMoviesState>, private spinnerStore: Store<ISpinnerState>) { }

  ngOnInit(): void {
    this.isLoading$ = this.spinnerStore.pipe(select(getIsSpinnerLoading));
    this.isLoading$.subscribe(value => this.isLoading = value);
  }
  
  addToWatchlist(event: MatCheckboxChange, id: string): void {
    const movie: AddToWatchlist = { isChecked: event.checked, id: id, email: this.authService?.getEmail };
    this.store.dispatch(addToWatchlist({ movie }));  
  }
}
