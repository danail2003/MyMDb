export interface Movie {
    id: string;
    isLoading: boolean;
    rating: number;
    name: string;
    country: string;
    description: string;
    year: number;
    duration: number;
    image: string;
    genres: string[];
    actors: string[];
    isInWatchlist: boolean;
}