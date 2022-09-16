import { HttpClientModule } from '@angular/common/http';
import { APP_INITIALIZER, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './core/header/header.component';
import { RouterModule } from '@angular/router';
import { CoreModule } from './core/core.module';
import { HomepageComponent } from './shared/homepage/homepage.component';
import { SharedModule } from '../app/shared/shared.module'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FeatureModule } from './feature/feature.module';
import { AuthModule } from './auth/auth.module';
import { AuthService } from './core/services/auth.service';
import { StoreModule } from '@ngrx/store';
import { countReducer, IRootState } from './shared/state';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { environment } from '../environments/environment';
import { EffectsModule } from '@ngrx/effects';
import { MoviesEffects } from './feature/movies/state/movie.effects';
import { AuthEffects } from './core/state';

@NgModule({
  declarations: [
    AppComponent,
    HomepageComponent,
  ],
  imports: [
    BrowserModule,
    RouterModule,
    CoreModule,
    FeatureModule,
    AuthModule,
    AppRoutingModule,
    HttpClientModule,
    SharedModule,
    BrowserAnimationsModule,
    StoreModule.forRoot<IRootState>({
      counter: countReducer
    }),
    StoreDevtoolsModule.instrument({ maxAge: 25, logOnly: environment.production }),
    StoreModule.forRoot({}, {}),
    EffectsModule.forRoot([MoviesEffects]),
    EffectsModule.forRoot([AuthEffects])
  ],
  providers: [
    {
      provide: APP_INITIALIZER,
      useFactory: (authService: AuthService) => {
        return () => authService.authenticate();
      },
      deps: [AuthService],
      multi: true
    }
  ],
  bootstrap: [AppComponent, HeaderComponent]
})
export class AppModule { }
