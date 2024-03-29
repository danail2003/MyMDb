import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MoviesListComponent } from './movies/movies-list/movies-list.component';
import { MatGridListModule } from '@angular/material/grid-list';
import { TopRatedMoviesComponent } from './movies/top-rated-movies/top-rated-movies.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatOptionModule } from "@angular/material/core";
import { MatSelectModule } from "@angular/material/select";
import { MatInputModule } from "@angular/material/input";
import { MatButtonModule } from "@angular/material/button";
import { PostMoviePageComponent } from './movies/post-movie-page/post-movie-page.component';
import { MoviesRoutingModule } from './movies-routing.module';
import { MatListModule } from '@angular/material/list';
import { StoreModule } from '@ngrx/store';
import { movieReducer } from './movies/state';
import { IMoviesState } from './movies/state';
import { AgGridModule } from 'ag-grid-angular';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { NbSpinnerModule } from '@nebular/theme';
import { NbStatusService } from '@nebular/theme';
import { NbThemeModule } from '@nebular/theme';
import { MatPaginatorModule } from '@angular/material/paginator';
import { WatchlistComponent } from './movies/watchlist/watchlist.component';

@NgModule({
  declarations: [MoviesListComponent, TopRatedMoviesComponent, PostMoviePageComponent, WatchlistComponent],
  imports: [
    CommonModule,
    MoviesRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MatGridListModule,
    MatFormFieldModule,
    MatOptionModule,
    MatSelectModule,
    MatInputModule,
    MatButtonModule,
    MatListModule,
    MatCheckboxModule,
    AgGridModule,
    NbThemeModule,
    NbSpinnerModule,
    MatPaginatorModule,
    StoreModule.forFeature<IMoviesState>('movie', movieReducer)
  ],
  exports: [MoviesListComponent],
  providers: [NbStatusService]
})
export class FeatureModule { }
