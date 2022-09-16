import { createAction, props } from "@ngrx/store";
import { ICurrentUser } from ".";

export const loadUser = createAction('[User] Load user');
export const loadUserSuccess = createAction('[User] Load user successfully', props<ICurrentUser>());