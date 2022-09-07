import { RouterModule, Routes } from '@angular/router';
import { HomepageComponent } from './shared/homepage/homepage.component';
import { NotFoundPageComponent } from './shared/not-found-page/not-found-page.component';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: HomepageComponent
  },
  {
    path: 'home',
    component: HomepageComponent
  },
  {
    path: '**',
    component: NotFoundPageComponent
  }
];

export const AppRoutingModule = RouterModule.forRoot(routes);
