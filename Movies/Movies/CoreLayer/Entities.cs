using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSeries.CoreLayer.Entities;

namespace MovieSeries.CoreLayer.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public ICollection<MovieSeriesTag> MovieSeriesTags { get; set; }
    }
}
namespace MovieSeries.CoreLayer.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public string ReviewText { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}

namespace MovieSeries.CoreLayer.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<Review> Reviews { get; set; }
        public ICollection<Rating> Ratings { get; set; }
    }
}
namespace MovieSeries.CoreLayer.Entities
{
    public class Rating
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public decimal Value { get; set; }

        public User User { get; set; }
        public Movie Movie { get; set; }
    }
}

namespace MovieSeries.CoreLayer.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<MovieSeriesTag> MovieSeriesTags { get; set; }
    }
}

namespace MovieSeries.CoreLayer.Entities
{
    public class MovieSeriesTag
    {
        public int MovieSeriesId { get; set; }
        public int TagId { get; set; }

        public Movie Movie { get; set; }
        public Tag Tag { get; set; }
    }
}

namespace MovieSeries.CoreLayer.Services
{
    public interface IMovieService
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task<IEnumerable<Movie>> GetTopRatedMoviesWithSpAsync(int count);
    }
}








