using System.Threading.Tasks;

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