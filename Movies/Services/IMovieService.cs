namespace Movies.Services
{
    public interface IMovieService
    {

        List<Movie> GetAll(byte categoryId=0);
        Movie GetById(int id);
        Movie Add(Movie movie);
        Movie Update(Movie movie);
        void Delete(Movie movie);
    }
}
