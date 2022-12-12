import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { LoadMoviesDTO } from 'src/app/core/models/loadMoviesDTO';
import { Movie } from 'src/app/core/models/movie';
import { AuthService } from 'src/app/core/services/auth.service';
import { IMoviesState } from '../state';
import { loadTopRatedMovies } from '../state/actions';
import { getTopRatedMoviesSelector } from '../state/selectors';

@Component({
  selector: 'app-movies-list',
  templateUrl: './movies-list.component.html',
  styleUrls: ['./movies-list.component.css']
})
export class MoviesListComponent implements OnInit {
  topRatedMovies$: Observable<Movie[]> = this.store.select(getTopRatedMoviesSelector);

  constructor(private store: Store<IMoviesState>, private authService: AuthService) { }

  ngOnInit(): void {
    const loadMovies: LoadMoviesDTO = {email: this.authService.getEmail};
    this.store.dispatch(loadTopRatedMovies({email: loadMovies}));
  }
}
