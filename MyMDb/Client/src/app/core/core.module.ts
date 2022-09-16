import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { RouterModule } from '@angular/router';
import { MatToolbarModule } from '@angular/material/toolbar';
import { AuthService } from './services/auth.service';
import { MoviesService } from './services/movies.service';
import { MatMenuModule } from '@angular/material/menu';
import { MatButtonModule } from '@angular/material/button';
import { StoreModule } from '@ngrx/store';
import { loadUserReducer } from './state';

@NgModule({
  declarations: [HeaderComponent],
  imports: [
    CommonModule,
    RouterModule,
    MatToolbarModule,
    MatMenuModule,
    MatButtonModule,
    StoreModule.forFeature('auth', loadUserReducer)
  ],
  providers: [AuthService, MoviesService],
  exports: [HeaderComponent]
})
export class CoreModule { }
