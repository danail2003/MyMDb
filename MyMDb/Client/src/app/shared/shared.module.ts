import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { StoreModule } from "@ngrx/store";
import { NotFoundPageComponent } from "./not-found-page/not-found-page.component";
import { ISpinnerState, spinnerReducer } from "./state/spinner/spinner.reducers";

@NgModule({
    declarations: [
        NotFoundPageComponent,
    ],
    imports: [
        CommonModule,
        RouterModule,
        StoreModule.forFeature<ISpinnerState>('spinner', spinnerReducer)
    ],
    exports: [NotFoundPageComponent]
})
export class SharedModule { };