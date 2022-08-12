import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { MovieListItemComponent } from "../feature/movies/movie-list-item/movie-list-item.component";
import { MoviesListComponent } from "../feature/movies/movies-list/movies-list.component";
import { PostMoviePageComponent } from "./post-movie-page/post-movie-page.component";

@NgModule({
    declarations: [
        MoviesListComponent,
        MovieListItemComponent,
        PostMoviePageComponent
    ],
    imports: [
        CommonModule,
        RouterModule
    ],
    exports: [MovieListItemComponent, MoviesListComponent, PostMoviePageComponent]
})
export class SharedModule { };