import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { CreateMovie } from 'src/app/core/models/create-movie';
import { Movie } from 'src/app/core/models/movie';
import { AddToWatchlist } from '../models/addToWatchlistDTO';
import { LoadMoviesDTO } from '../models/loadMoviesDTO';
import { GetMyWatchlistDTO } from '../models/getMyWatchlistDTO';
import { RemoveFromWatchlistDTO } from '../models/removeFromWatchlistDTO';
import { PagedResult } from '../models/pagedResult';
import { MoviesParams } from '../models/moviesParamas';
import { Paging } from '../models/paging';

const apiUrl = environment.apiUrl;

@Injectable()
export class MoviesService {

  constructor(private httpClient: HttpClient) { }

  loadTopRatedMovies(params: MoviesParams): Observable<PagedResult> {
    return this.httpClient.post<PagedResult>(`${apiUrl}/movies/top`, params);
  }

  createMovie(body: CreateMovie): Observable<CreateMovie> {
    return this.httpClient.post<CreateMovie>(`${apiUrl}/movies`, body);
  }

  addToWatchlist(body: AddToWatchlist): Observable<AddToWatchlist> {
    return this.httpClient.post<AddToWatchlist>(`${apiUrl}/movies/watchlist`, body);
  }

  myWatchlist(body: GetMyWatchlistDTO): Observable<Movie[]> {
    return this.httpClient.post<Movie[]>(`${apiUrl}/movies/myWatchlist`, body);
  }

  moviesList(paging: Paging): Observable<PagedResult> {
    return this.httpClient.post<PagedResult>(`${apiUrl}/movies/moviesList`, paging);
  }

  removeFromWatchlist(body: RemoveFromWatchlistDTO): Observable<Movie[]> {
    return this.httpClient.post<Movie[]>(`${apiUrl}/movies/removeFromWatchlist`, body);
  }
}
