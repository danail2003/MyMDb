namespace MyMDb.DTO
{
    public class AddToWatchlistDTO
    {
        public bool IsChecked { get; set; }

        public Guid Id { get; set; }

        public string Email { get; set; }
    }
}
