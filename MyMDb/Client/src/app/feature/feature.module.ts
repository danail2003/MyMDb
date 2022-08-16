import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MoviesListComponent } from './movies/movies-list/movies-list.component';
import { MovieListItemComponent } from './movies/movie-list-item/movie-list-item.component';
import { MatGridListModule } from '@angular/material/grid-list';

@NgModule({
  declarations: [MoviesListComponent, MovieListItemComponent],
  imports: [
    CommonModule,
    MatGridListModule
  ],
  exports: [MoviesListComponent, MovieListItemComponent]
})
export class FeatureModule { }
