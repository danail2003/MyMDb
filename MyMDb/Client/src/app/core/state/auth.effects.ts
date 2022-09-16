import { Injectable } from "@angular/core";
import { Actions, createEffect } from "@ngrx/effects";
import { Store } from "@ngrx/store";
import { filter, tap, mergeMap } from "rxjs";
import { IAuthState, loadUser, loadUserSuccess } from ".";
import { AuthService } from "../services/auth.service";

@Injectable()
export class AuthEffects {
    constructor(private actions: Actions, private authService: AuthService, private store: Store<IAuthState>) { }

    onLoadingUser$ = createEffect(() =>
        this.actions.pipe(filter(a => a.type === loadUser().type),
            mergeMap(() => {
                const user = this.authService.currentUser;

                return user;
            }),
            tap(user => {
                this.store.dispatch(loadUserSuccess({ currentUser: user }))
            })),
        {
            dispatch: false
        }
    )
}