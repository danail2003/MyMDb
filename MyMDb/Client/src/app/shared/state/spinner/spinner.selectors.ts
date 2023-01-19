import { createFeatureSelector, createSelector } from "@ngrx/store";
import { ISpinnerState } from "./spinner.reducers";

export const getSpinner = createFeatureSelector<ISpinnerState>('spinner');

export const getIsSpinnerLoading = createSelector(getSpinner, (state) => state.spinner.isOn);