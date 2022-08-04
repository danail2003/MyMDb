import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MoviesService } from './core/services/movies.service';
import { MoviesListComponent } from './feature/movies/movies-list/movies-list.component';
import { MovieListItemComponent } from './feature/movies/movie-list-item/movie-list-item.component';

@NgModule({
  declarations: [
    AppComponent,
    MoviesListComponent,
    MovieListItemComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [MoviesService],
  bootstrap: [AppComponent]
})
export class AppModule { }
