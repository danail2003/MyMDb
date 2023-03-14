namespace MyMDb.DTO
{
    public class PagedResult
    {
        public List<MovieDTO> Movies { get; set; }

        public int Total { get; set; }
    }
}
