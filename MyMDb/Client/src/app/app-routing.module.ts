import { RouterModule, Routes } from '@angular/router';
import { HomepageComponent } from './shared/homepage/homepage.component';
import { NotFoundPageComponent } from './shared/not-found-page/not-found-page.component';
import { PostMoviePageComponent } from './shared/post-movie-page/post-movie-page.component';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'home'
  },
  {
    path: 'home',
    component: HomepageComponent
  },
  {
    path: 'movies/post',
    component: PostMoviePageComponent
  },
  {
    path: '**',
    component: NotFoundPageComponent
  }
];

export const AppRoutingModule = RouterModule.forRoot(routes);
