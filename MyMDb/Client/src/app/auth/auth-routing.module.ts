import {Routes, RouterModule} from '@angular/router';
import { LoggedUsersGuard } from './logged-users.guard';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
    {
        path: 'auth/register',
        canActivate: [LoggedUsersGuard],
        component: RegisterComponent
    },
    {
        path: 'auth/login',
        canActivate: [LoggedUsersGuard],
        component: LoginComponent
    }
];

export const AuthRoutingModule = RouterModule.forChild(routes);