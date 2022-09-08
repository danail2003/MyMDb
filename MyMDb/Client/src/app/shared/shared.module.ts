import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { NotFoundPageComponent } from "./not-found-page/not-found-page.component";
import { MyCounterComponent } from './my-counter/my-counter.component';

@NgModule({
    declarations: [
        NotFoundPageComponent,
        MyCounterComponent
    ],
    imports: [
        CommonModule,
        RouterModule,
    ],
    exports: [NotFoundPageComponent, MyCounterComponent]
})
export class SharedModule { };