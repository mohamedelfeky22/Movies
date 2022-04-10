

namespace Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly ICategoryService _categoryService;
        private readonly long _maxallowedSize;
        private readonly List<string> _allowedExtentions;
        private readonly IMapper _mapper;

        public MovieController(IMovieService movieService, ICategoryService categoryService, IConfiguration configuration, IMapper mapper)
        {
            _movieService = movieService;
            _categoryService = categoryService;
            _maxallowedSize = long.Parse(configuration.GetSection("MaxAllowedSize").Value);
            _allowedExtentions = configuration.GetSection("AllowedExtentions").Get<List<string>>();
            _mapper = mapper;
        }

        [HttpGet]

        public IActionResult GetAll ()
        {
            var movies = _movieService.GetAll();
            return Ok(movies);
        }

        [HttpGet("id")]

        public IActionResult Get (int id)
        {
            var movie = _movieService.GetById(id);

            if (movie == null)
                return NotFound($"No movie was found with Id:{id}");

            return Ok(movie);
        }


        [HttpGet("categoryId")]
        public IActionResult GetByCategoryId(byte categoryId)
        {
            var movies = _movieService.GetAll(categoryId);
            return Ok(movies);
        }


        [HttpPost]
        public IActionResult Add([FromForm] CreateMovieDto movieDto) //from form to upload images 
        {
            if (movieDto == null)
                return BadRequest();

            if (!_allowedExtentions.Contains(Path.GetExtension(movieDto.Posters.FileName).ToLower()))
                return BadRequest("Only PNG and JPG Images are allowed");

            if(movieDto.Posters.Length > _maxallowedSize)
                return BadRequest("Max allowed size for poster 1 MB");

            var isValidCategory = _categoryService.isValidCategory(movieDto.CategoryId);
            if (!isValidCategory)
                return BadRequest("Invalid Category Id");

            var datastream = new MemoryStream();
                movieDto.Posters.CopyToAsync(datastream);
            //using automapper
            var movie = _mapper.Map<Movie>(movieDto);
            movie.Posters = datastream.ToArray();
            _movieService.Add(movie);
                return Ok(movie);

        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromForm] UpdateMovieDto movieDto)
        {
            var movie = _movieService.GetById(id);

            if (movie == null)
                return NotFound($"No movie was found with Id:{id}");

            if (movieDto.CategoryId != null)
            {
                var isValidCategory = _categoryService.isValidCategory(movieDto.CategoryId);
                if (!isValidCategory)
                    return BadRequest("Invalid Category Id");
            }

            if (movieDto.Posters != null)
            {
                if (!_allowedExtentions.Contains(Path.GetExtension(movieDto.Posters.FileName).ToLower()))
                    return BadRequest("Only PNG and JPG Images are allowed");

                if (movieDto.Posters.Length > _maxallowedSize)
                    return BadRequest("Max allowed size for poster 1 MB");
                var datastream = new MemoryStream();
                movieDto.Posters.CopyToAsync(datastream);
                movie.Posters = datastream.ToArray();
            }

            movie.Title = movieDto.Title;
            movie.Rate = movieDto.Rate;
            movie.Story = movieDto.Story;
            movie.Year = movieDto.Year;
            movie.CategoryId = movieDto.CategoryId;

            _movieService.Update(movie);
            return Ok(movie);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var movie = _movieService.GetById(id);
            if (movie == null)
                return NotFound($"Not category was found with Id:{id}");
            _movieService.Delete(movie);
            return Ok();
        }

    }
}
