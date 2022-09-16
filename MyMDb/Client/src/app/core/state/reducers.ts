import { createReducer, on } from "@ngrx/store";
import { IAuthState, loadUser, loadUserSuccess } from ".";

export const loadUserReducer = createReducer<IAuthState>({
    user: { currentUser: '' }
},
    on(loadUserSuccess, (state, action) => {
        return {
            user: { currentUser: action.currentUser }
        }
    })
)