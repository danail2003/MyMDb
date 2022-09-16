export * from './actions';
export * from './auth.effects';
export * from './reducers';
export * from './selectors';

export interface ICurrentUser {
    currentUser: string;
}

export interface IAuthState {
    user: ICurrentUser
}