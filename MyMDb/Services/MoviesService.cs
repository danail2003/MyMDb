namespace MyMDb.Services
{
    using Microsoft.EntityFrameworkCore;
    using MyMDb.Constants;
    using MyMDb.DTO;
    using MyMDb.Models;
    using Newtonsoft.Json;
    using System.Net;

    public class MoviesService : IMoviesService
    {
        private readonly MyMDbContext context;

        public MoviesService(MyMDbContext context)
        {
            this.context = context;
        }

        public async Task<Guid> CreateMovie(CreateMovieDTO movieDTO)
        {
            var movie = new Movie
            {
                Name = movieDTO.Name,
                Description = movieDTO.Description,
                Duration = movieDTO.Duration,
                Year = movieDTO.Year,
                Rating = movieDTO.Rating,
                Image = movieDTO.Image,
            };

            await this.context.AddAsync(movie);
            await this.context.SaveChangesAsync();

            return movie.Id;
        }

        public async Task<Movie> GetMovieAsync(Guid id)
        {
            if (Guid.Empty == id)
            {
                throw new InvalidOperationException("Id is empty.");
            }

            var movie = await this.context.Movies.FirstOrDefaultAsync(x => x.Id == id);

            if (movie == null)
            {
                throw new ArgumentNullException("Id is not valid.");
            }

            return movie;
        }

        public async Task<List<IMDbMovieDTO>> GetTopRatedMoviesAsync()
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format($"{Common.IMDbLink}{Secrets.IMDbAPIKey}"));

            WebReq.Method = "GET";

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            var items = JsonConvert.DeserializeObject<AllIMDbMoviesDTO>(jsonString);

            return items.Items;
        }
    }
}
