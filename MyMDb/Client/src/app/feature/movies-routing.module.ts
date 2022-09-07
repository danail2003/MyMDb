import { Routes, RouterModule } from "@angular/router";
import { AdminGuard } from "../auth/admin.guard";
import { MoviesListComponent } from "./movies/movies-list/movies-list.component";
import { PostMoviePageComponent } from "./movies/post-movie-page/post-movie-page.component";

const routes: Routes = [
    {
        path: 'movies/post',
        canActivate: [AdminGuard],
        component: PostMoviePageComponent
    },
    {
        path: 'movies/list',
        component: MoviesListComponent
    }
];

export const MoviesRoutingModule = RouterModule.forChild(routes);