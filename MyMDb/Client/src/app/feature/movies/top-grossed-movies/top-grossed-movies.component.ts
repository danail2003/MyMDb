import { Component, Input, OnInit } from '@angular/core';
import { Movie } from 'src/app/core/models/movie';

@Component({
  selector: 'app-top-grossed-movies',
  templateUrl: './top-grossed-movies.component.html',
  styleUrls: ['./top-grossed-movies.component.css']
})
export class TopGrossedMoviesComponent implements OnInit {
  @Input() movie!: Movie;

  constructor() { }

  ngOnInit(): void {
  }

}
