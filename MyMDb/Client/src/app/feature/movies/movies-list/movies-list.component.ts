import { Component, OnInit } from '@angular/core';
import { Movie } from 'src/app/core/services/models/movie';
import { MoviesService } from 'src/app/core/services/movies.service';

@Component({
  selector: 'app-movies-list',
  templateUrl: './movies-list.component.html',
  styleUrls: ['./movies-list.component.css']
})
export class MoviesListComponent implements OnInit {
  moviesList!: Movie[];

  constructor(private moviesService: MoviesService) { }

  ngOnInit(): void {
    this.moviesService.loadMovies().subscribe(movies => {
      this.moviesList = movies;
    })
  }
}
