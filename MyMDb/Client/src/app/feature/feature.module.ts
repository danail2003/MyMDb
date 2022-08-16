import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MoviesListComponent } from './movies/movies-list/movies-list.component';
import { MatGridListModule } from '@angular/material/grid-list';
import { TopRatedMoviesComponent } from './movies/top-rated-movies/top-rated-movies.component';
import { ComingSoonMoviesComponent } from './movies/coming-soon-movies/coming-soon-movies.component';
import { TopGrossedMoviesComponent } from './movies/top-grossed-movies/top-grossed-movies.component';

@NgModule({
  declarations: [MoviesListComponent, TopRatedMoviesComponent, ComingSoonMoviesComponent, TopGrossedMoviesComponent],
  imports: [
    CommonModule,
    MatGridListModule
  ],
  exports: [MoviesListComponent]
})
export class FeatureModule { }
