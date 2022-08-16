import { Component, Input, OnInit } from '@angular/core';
import { Movie } from 'src/app/core/models/movie';

@Component({
  selector: 'app-coming-soon-movies',
  templateUrl: './coming-soon-movies.component.html',
  styleUrls: ['./coming-soon-movies.component.css']
})
export class ComingSoonMoviesComponent implements OnInit {
  @Input() movie!: Movie;

  constructor() { }

  ngOnInit(): void {
  }

}
