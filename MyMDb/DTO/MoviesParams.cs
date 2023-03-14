namespace MyMDb.DTO
{
    public class MoviesParams
    {
        public Paging Paging { get; set; }

        public LoadMoviesDTO Movies { get; set; }
    }
}
