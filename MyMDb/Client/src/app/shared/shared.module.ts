import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";
import { MovieListItemComponent } from "../feature/movies/movie-list-item/movie-list-item.component";
import { MoviesListComponent } from "../feature/movies/movies-list/movies-list.component";
import { PostMoviePageComponent } from "./post-movie-page/post-movie-page.component";
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatOptionModule } from "@angular/material/core";
import { MatSelectModule } from "@angular/material/select";
import { MatInputModule } from "@angular/material/input";
import { MatButtonModule } from "@angular/material/button";
import { NotFoundPageComponent } from "./not-found-page/not-found-page.component";

@NgModule({
    declarations: [
        NotFoundPageComponent,
        PostMoviePageComponent
    ],
    imports: [
        CommonModule,
        RouterModule,
        FormsModule,
        ReactiveFormsModule,
        MatFormFieldModule,
        MatOptionModule,
        MatSelectModule,
        MatInputModule,
        MatButtonModule
    ],
    exports: [PostMoviePageComponent, NotFoundPageComponent]
})
export class SharedModule { };