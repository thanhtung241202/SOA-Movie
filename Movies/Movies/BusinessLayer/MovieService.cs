using MovieSeries.CoreLayer.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieSeries.ServiceLayer
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetAllMoviesAsync();
        Task<Movie> GetMovieByIdAsync(int id);
        Task<IEnumerable<Movie>> GetTopRatedMoviesWithSpAsync(int topCount); // 👈 Thêm dòng này
    }

    namespace MovieSeries.BusinessLayer.Services
    {
        public class MovieService : IMovieService
        {
            private readonly IMovieRepository _movieRepository;
            public MovieService(IMovieRepository movieRepository)
            {
                _movieRepository = movieRepository;
            }

            public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
            {
                return await _movieRepository.GetAllMoviesAsync();
            }

            public async Task<IEnumerable<Movie>> GetTopRatedMoviesWithSpAsync(int topCount)
            {
                return await _movieRepository.GetTopRatedMoviesWithSpAsync(topCount);
            }

            public Task<Movie> GetMovieByIdAsync(int id)
            {
                return _movieRepository.GetMovieByIdAsync(id);
            }
        }
    }
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllMoviesAsync();
        Task<Movie> GetMovieByIdAsync(int id);
        Task<IEnumerable<Movie>> GetTopRatedMoviesWithSpAsync(int topCount); // Thêm phương thức này
    }


}
