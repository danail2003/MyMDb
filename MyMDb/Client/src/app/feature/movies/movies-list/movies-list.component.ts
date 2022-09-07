import { Component, OnInit } from '@angular/core';
import { Movie } from 'src/app/core/models/movie';
import { MoviesService } from 'src/app/core/services/movies.service';

@Component({
  selector: 'app-movies-list',
  templateUrl: './movies-list.component.html',
  styleUrls: ['./movies-list.component.css']
})
export class MoviesListComponent implements OnInit {
  topRatedMovies!: Movie[];

  constructor(private moviesService: MoviesService) { }

  ngOnInit(): void {
    this.moviesService.loadTopRatedMovies().subscribe(movies => {
      this.topRatedMovies = movies;
      console.log(this.topRatedMovies);
      
    });
  }
}
