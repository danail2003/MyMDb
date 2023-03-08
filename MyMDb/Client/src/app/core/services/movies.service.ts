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

const apiUrl = environment.apiUrl;

@Injectable()
export class MoviesService {

  constructor(private httpClient: HttpClient) { }

  loadTopRatedMovies(body: LoadMoviesDTO): Observable<Movie[]> {
    return this.httpClient.post<Movie[]>(`${apiUrl}/movies/top`, body);
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

  moviesList(): Observable<Movie[]> {
    return this.httpClient.get<Movie[]>(`${apiUrl}/movies/moviesList`);
  }

  removeFromWatchlist(body: RemoveFromWatchlistDTO): Observable<Movie[]> {
    return this.httpClient.post<Movie[]>(`${apiUrl}/movies/removeFromWatchlist`, body);
  }
}
