import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Movie } from 'src/app/core/models/movie'

const apiUrl = environment.apiUrl;

@Injectable()
export class MoviesService {

  constructor(private httpClient: HttpClient) { }

  loadTopRatedMovies(): Observable<Movie[]> {
    return this.httpClient.get<Movie[]>(`${apiUrl}/movies/top`);
  }

  loadMostGrossedMovies(): Observable<Movie[]> {
    return this.httpClient.get<Movie[]>(`${apiUrl}/movies/most`);
  }

  loadComingSoonMovies(): Observable<Movie[]> {
    return this.httpClient.get<Movie[]>(`${apiUrl}/movies/soon`);
  }

  createMovie(body: {
    name: string, country: string, description: string,
    year: number, duration: number, budget: number,
    gross: number, rating: number, video: string, image: string
  }): Observable<Movie> {
    return this.httpClient.post<Movie>(`${apiUrl}/movies`, body);
  }
}
