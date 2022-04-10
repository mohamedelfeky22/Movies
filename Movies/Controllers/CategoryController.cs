

namespace Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = _categoryService.GetAll(); 
            return Ok(categories);
        }
        [HttpPost]
        public IActionResult Add(CategoryDto categoryDto)
        {
            if (categoryDto == null)
                return BadRequest();

            Category category = new() { Name = categoryDto.Name }; //optional to put target type (Category) after new 
            _categoryService.Add(category);
            return Ok(category);
        }

        [HttpPut("{id}")]
        public IActionResult Update(byte id, [FromBody] CategoryDto categoryDto)
        {
            var category = _categoryService.GetById(id);

            if (category == null)
                return NotFound($"No category was found with Id:{id}");

            category.Name = categoryDto.Name;
            _categoryService.Update(category);
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(byte id)
        {
            var category = _categoryService.GetById(id);
            if (category == null)
                return NotFound($"Not category was found with Id:{id}");

            _categoryService.Delete(category);
            return Ok();
        }

    }
}
