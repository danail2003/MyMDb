import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { Store } from '@ngrx/store';
import { Observable, Subject } from 'rxjs';
import { LoadMoviesDTO } from 'src/app/core/models/loadMoviesDTO';
import { Movie } from 'src/app/core/models/movie';
import { MoviesParams } from 'src/app/core/models/moviesParamas';
import { Paging } from 'src/app/core/models/paging';
import { AuthService } from 'src/app/core/services/auth.service';
import { IMoviesState } from '../state';
import { loadMoviesList, loadTopRatedMovies } from '../state/actions';
import { getTopRatedMoviesSelector, getTotalMoviesCount } from '../state/selectors';

@Component({
  selector: 'app-movies-list',
  templateUrl: './movies-list.component.html',
  styleUrls: ['./movies-list.component.css']
})
export class MoviesListComponent implements OnInit {
  topRatedMovies$: Observable<Movie[]> = this.store.select(getTopRatedMoviesSelector);
  totalMoviesCount$: Observable<number> = this.store.select(getTotalMoviesCount);
  moviesCount: number;
  page: number = 1;
  pageSize: number = 10;
  paging: Subject<{ page: number, pageSize: number }> = new Subject();

  constructor(private store: Store<IMoviesState>, private authService: AuthService) { }

  ngOnInit(): void {
    const paging: Paging = { skip: 0, take: this.pageSize };
    if (this.authService.isLogged) {
      const loadMovies: LoadMoviesDTO = { email: this.authService?.getEmail };
      const params: MoviesParams = { movies: loadMovies, paging: paging };
      this.store.dispatch(loadTopRatedMovies({ params: params }));
    }
    else {
      this.store.dispatch(loadMoviesList({ paging: paging }));
    }

    this.totalMoviesCount$.subscribe(count => this.moviesCount = count);
    this.paging.subscribe(paging => {
      console.log(paging);

    })
  }

  handlePage(event: PageEvent) {
    console.log(event);

  }
}
