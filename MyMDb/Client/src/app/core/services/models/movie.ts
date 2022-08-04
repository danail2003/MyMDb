export interface Movie {
    id: string;
    name: string;
    country: string;
    releaseDate: string;
    description: string;
    year: number;
    duration: number;
    budget: number;
    gross: number;
    rating: number;
    imageId: string;
    movieImages: string[];
    genres: string[];
    actors: string[];
    usersMovie: string[];
}
