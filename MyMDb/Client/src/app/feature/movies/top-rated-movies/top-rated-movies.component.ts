import { Component, Input, OnInit } from '@angular/core';
import { Movie } from 'src/app/core/models/movie';

@Component({
  selector: 'app-top-rated-movies',
  templateUrl: './top-rated-movies.component.html',
  styleUrls: ['./top-rated-movies.component.css']
})
export class TopRatedMoviesComponent implements OnInit {
  @Input() movie!: Movie;
  @Input() index!: number;
  public checked: boolean = false;
  constructor() { }

  ngOnInit(): void {

  }

}
