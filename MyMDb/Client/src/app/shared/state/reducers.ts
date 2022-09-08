import { createReducer, on } from "@ngrx/store";
import { decrement, increment, reset } from "./actions";

const initialState: number = 0;

export const countReducer = createReducer<number>(initialState,
    on(increment, state => state + 1),
    on(decrement, state => state - 1),
    on(reset, state => state = 0)
);