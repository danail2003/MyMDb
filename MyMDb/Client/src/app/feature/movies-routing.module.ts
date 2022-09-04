import { Routes, RouterModule } from "@angular/router";
import { AdminGuard } from "../auth/admin.guard";
import { PostMoviePageComponent } from "./movies/post-movie-page/post-movie-page.component";

const routes: Routes = [
    {
        path: 'movies/post',
        canActivate: [AdminGuard],
        component: PostMoviePageComponent
    }
];

export const MoviesRoutingModule = RouterModule.forChild(routes);