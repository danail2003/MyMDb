import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { Movie } from 'src/app/core/models/movie';

@Component({
  selector: 'app-movie-list-item',
  templateUrl: './movie-list-item.component.html',
  styleUrls: ['./movie-list-item.component.css']
})
export class MovieListItemComponent implements OnInit {
  @Input() movie!: Movie;
  public displayURL: any;

  constructor(private sanitizer: DomSanitizer) {
    
  }

  ngOnInit(): void {
    this.displayURL = this.sanitizer.bypassSecurityTrustResourceUrl(this.movie.video);
  }

}
