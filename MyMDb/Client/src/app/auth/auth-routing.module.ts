import {Routes, RouterModule} from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
    {
        path: 'auth/register',
        component: RegisterComponent
    },
    {
        path: 'auth/login',
        component: LoginComponent
    }
];

export const AuthRoutingModule = RouterModule.forChild(routes);