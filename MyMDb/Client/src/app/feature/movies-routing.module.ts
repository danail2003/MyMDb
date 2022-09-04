import { Routes, RouterModule } from "@angular/router";
import { AuthGuard } from "../auth/auth.guard";
import { PostMoviePageComponent } from "./movies/post-movie-page/post-movie-page.component";

const routes: Routes = [
    {
        path: 'movies/post',
        canActivate: [AuthGuard],
        component: PostMoviePageComponent
    }
];

export const MoviesRoutingModule = RouterModule.forChild(routes);