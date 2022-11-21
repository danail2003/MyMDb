namespace MyMDb.DTO
{
    public class MovieDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Year { get; set; }

        public string Duration { get; set; }

        public double Rating { get; set; }

        public string Image { get; set; }
    }
}
