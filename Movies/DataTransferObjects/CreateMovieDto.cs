namespace Movies.DataTransferObjects
{
    public class CreateMovieDto :MovieBaseDto
    {
        public IFormFile Posters { get; set; } //iframe to accept images
    }
}
