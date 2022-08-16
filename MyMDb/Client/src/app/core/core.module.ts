import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { RouterModule } from '@angular/router';
import { CoreRoutingModule } from './core-routing.module';
import {MatToolbarModule} from '@angular/material/toolbar';

@NgModule({
  declarations: [HeaderComponent],
  imports: [
    CommonModule,
    RouterModule,
    CoreRoutingModule,
    MatToolbarModule
  ],
  exports: [HeaderComponent]
})
export class CoreModule { }
