using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MovieSeries.ServiceLayer;


[ApiController]
[Route("api/movies")]
public class MovieController : ControllerBase
{
    private readonly IMovieService _movieService;

    public MovieController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMovie(int id)
    {
        var movie = await _movieService.GetMovieByIdAsync(id);
        if (movie == null) return NotFound();
        return Ok(movie);
    }

    [HttpGet("top-rated/{count}")]
    public async Task<IActionResult> GetTopRatedMovies(int count)
    {
        var movies = await _movieService.GetTopRatedMoviesWithSpAsync(count);
        return Ok(movies);
    }
}
