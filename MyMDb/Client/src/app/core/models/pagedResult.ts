import { Movie } from "./movie";

export interface PagedResult {
    movies: Movie[];
    total: number;
}