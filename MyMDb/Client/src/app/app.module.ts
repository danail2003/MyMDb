import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MoviesService } from './core/services/movies.service';
import { HeaderComponent } from './core/header/header.component';
import { RouterModule } from '@angular/router';
import { CoreModule } from './core/core.module';
import { HomepageComponent } from './shared/homepage/homepage.component';
import { NotFoundPageComponent } from './shared/not-found-page/not-found-page.component';
import { SharedModule } from '../app/shared/shared.module'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FeatureModule } from './feature/feature.module';

@NgModule({
  declarations: [
    AppComponent,
    HomepageComponent,
  ],
  imports: [
    BrowserModule,
    CoreModule,
    RouterModule,
    AppRoutingModule,
    HttpClientModule,
    SharedModule,
    FeatureModule,
    BrowserAnimationsModule
  ],
  providers: [MoviesService],
  bootstrap: [AppComponent, HeaderComponent]
})
export class AppModule { }
