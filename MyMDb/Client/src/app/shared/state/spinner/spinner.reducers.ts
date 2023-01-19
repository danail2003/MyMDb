import { createReducer, on } from "@ngrx/store"
import { startSpinner, stopSpinner } from "./spinner.actions"

export interface ISpinnerState {
    spinner: ISpinner
}

export interface ISpinner {
    isOn: boolean,
}

export const spinnerReducer = createReducer<ISpinnerState>({
    spinner: { isOn: false }
},
    on(startSpinner, (state, action) => {
        return {
            spinner: { isOn: true }
        }
    }),
    on(stopSpinner, (state, action) => {
        return {
            spinner: { isOn: false }
        }
    }))