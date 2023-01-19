import { Routes, RouterModule } from "@angular/router";
import { AdminGuard } from "../auth/admin.guard";
import { MoviesListComponent } from "./movies/movies-list/movies-list.component";
import { PostMoviePageComponent } from "./movies/post-movie-page/post-movie-page.component";
import { WatchlistComponent } from "./movies/watchlist/watchlist.component";

const routes: Routes = [
    {
        path: 'movies/post',
        canActivate: [AdminGuard],
        component: PostMoviePageComponent
    },
    {
        path: 'movies/list',
        component: MoviesListComponent
    },
    {
        path: 'movies/watchlist',
        component: WatchlistComponent
    }
];

export const MoviesRoutingModule = RouterModule.forChild(routes);