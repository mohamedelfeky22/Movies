namespace Movies.Services
{
    public class MovieService : IMovieService
    {
        private readonly ApplicationDbContext _context;

        public MovieService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Movie Add(Movie movie)
        {
           var x= _context.Add(movie);
            _context.SaveChanges();
            return movie;   
        }

        public void Delete(Movie movie)
        {
            _context.Remove(movie);
            _context.SaveChanges();
        }

        public List<Movie> GetAll(byte categoryId = 0)
        {
            return _context.Movies.Where(m=>m.CategoryId == categoryId || categoryId==0)  
                .Include(m => m.Category).OrderByDescending(C => C.Rate).ToList();
        }

        public Movie GetById(int id)
        {
            return _context.Movies.Include(m => m.Category).SingleOrDefault(m => m.Id == id);
        }

        public Movie Update(Movie movie)
        {
            _context.Update(movie);
            _context.SaveChanges();
            return movie;
        }
    }
}
