import { RouterModule, Routes } from '@angular/router';
import { PostMoviePageComponent } from '../shared/post-movie-page/post-movie-page.component';

const routes: Routes = [
    {
        path: 'movies/post',
        component: PostMoviePageComponent
    }
]

export const CoreRoutingModule = RouterModule.forRoot(routes);