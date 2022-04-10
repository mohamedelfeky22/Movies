namespace Movies.DataTransferObjects
{
    public class UpdateMovieDto:MovieBaseDto
    {
        public IFormFile? Posters { get; set; } 
    }
}
