import { Routes, RouterModule } from "@angular/router";
import { PostMoviePageComponent } from "./movies/post-movie-page/post-movie-page.component";

const routes: Routes = [
    {
        path: 'movies/post',
        component: PostMoviePageComponent
    }
];

export const MoviesRoutingModule = RouterModule.forChild(routes);