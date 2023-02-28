export interface CreateMovie {
    name: string;
    description: string;
    year: number;
    duration: number;
    rating: number;
    image: string;
    genres: string[];
    actors: string[];
}
