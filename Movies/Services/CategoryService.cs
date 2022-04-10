namespace Movies.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Category Add(Category category)
        {
            _context.Add(category); //optional to put the table in the new updtes of entity framework
            _context.SaveChanges();
            return category;
        }

        public void Delete(Category category)
        {
            _context.Remove(category);
            _context.SaveChanges();
        }

        public List<Category> GetAll()
        {
           return _context.Categories.OrderBy(C => C.Name).ToList();
        }

        public Category GetById(byte id)
        {
            return _context.Categories.SingleOrDefault(c => c.Id == id);
        }

        public bool isValidCategory(byte id)
        {
            return _context.Categories.Any(c => c.Id == id);
        }

        public Category Update(Category category)
        {
            _context.Update(category);
            _context.SaveChanges();
            return category;
        }
    }
}
