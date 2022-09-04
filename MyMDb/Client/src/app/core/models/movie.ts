export interface Movie {
    id: string;
    name: string;
    country: string;
    description: string;
    year: number;
    duration: number;
    rating: number;
    image: string;
    genres: string[];
    actors: string[];
    usersMovie: string[];
}
