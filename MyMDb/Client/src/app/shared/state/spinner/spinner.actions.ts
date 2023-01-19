import { createAction, props } from "@ngrx/store";
import { ISpinner } from "./spinner.reducers";

export const startSpinner = createAction('[Spinner] Start', props<{spinnerId: string}>());
export const stopSpinner = createAction('[Spinner] Stop', props<{spinnerId: string}>());