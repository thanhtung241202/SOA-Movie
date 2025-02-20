using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSeries.CoreLayer.Entities;
using MovieSeries.ServiceLayer;

namespace Movies.ServiceLayer
{
    internal class ServiceLayer
    {
        private readonly IMovieRepository _movieRepository;
        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return await _movieRepository.GetAllMoviesAsync();
        }
        public async Task<IEnumerable<Movie>> GetTopRatedMoviesWithSpAsync(int
        topCount)
        {
            return await _movieRepository.GetTopRatedMoviesWithSpAsync(topCount);
        }
    }
}
