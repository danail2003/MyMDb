import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MoviesListComponent } from './movies/movies-list/movies-list.component';
import { MatGridListModule } from '@angular/material/grid-list';
import { TopRatedMoviesComponent } from './movies/top-rated-movies/top-rated-movies.component';
import { ComingSoonMoviesComponent } from './movies/coming-soon-movies/coming-soon-movies.component';
import { TopGrossedMoviesComponent } from './movies/top-grossed-movies/top-grossed-movies.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatOptionModule } from "@angular/material/core";
import { MatSelectModule } from "@angular/material/select";
import { MatInputModule } from "@angular/material/input";
import { MatButtonModule } from "@angular/material/button";
import { PostMoviePageComponent } from './movies/post-movie-page/post-movie-page.component';

@NgModule({
  declarations: [MoviesListComponent, TopRatedMoviesComponent, ComingSoonMoviesComponent, TopGrossedMoviesComponent, PostMoviePageComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatGridListModule,
    MatFormFieldModule,
    MatOptionModule,
    MatSelectModule,
    MatInputModule,
    MatButtonModule
  ],
  exports: [MoviesListComponent]
})
export class FeatureModule { }
