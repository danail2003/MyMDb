import { LoadMoviesDTO } from "./loadMoviesDTO";
import { Paging } from "./paging";

export interface MoviesParams {
    paging: Paging;
    movies: LoadMoviesDTO;
}