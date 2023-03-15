import { Movie } from "./movie";

export interface PagedResult {
    data: Movie[];
    total: number;
}