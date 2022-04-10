namespace Movies.Services
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category GetById(byte id);
        Category Add(Category category);
        Category Update(Category category);
        void Delete(Category category);

        bool isValidCategory (byte id);
    }
}
