import { createFeatureSelector, createSelector } from "@ngrx/store";
import { IAuthState } from ".";

export const getUserFeature = createFeatureSelector<IAuthState>('auth');
export const getUserSelector = createSelector(getUserFeature, (state) => state.user.currentUser);