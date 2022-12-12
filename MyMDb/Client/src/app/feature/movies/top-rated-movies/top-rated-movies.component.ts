import { Component, Input, OnInit } from '@angular/core';
import { MatCheckboxChange } from '@angular/material/checkbox';
import { Store } from '@ngrx/store';
import { AddToWatchlist } from 'src/app/core/models/addToWatchlistDTO';
import { Movie } from 'src/app/core/models/movie';
import { AuthService } from 'src/app/core/services/auth.service';
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
  constructor(private authService: AuthService, private store: Store<IMoviesState>) { }

  ngOnInit(): void {
    this.checked = this.movie.isInWatchlist;
  }

  addToWatchlist(event: MatCheckboxChange, id: string): void {
    const movie: AddToWatchlist = { isChecked: event.checked, id: id, email: this.authService.getEmail };

    this.store.dispatch(addToWatchlist({ movie }));
  }
}
