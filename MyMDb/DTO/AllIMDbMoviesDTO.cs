namespace MyMDb.DTO
{
    public class AllIMDbMoviesDTO
    {
        public List<IMDbMovieDTO> Items { get; set; }

        public string ErrorMessage { get; set; }
    }
}
