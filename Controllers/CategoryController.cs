using AutoMapper;
using MapperStaticApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MapperStaticApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private static List<Category> _categories = new List<Category>();
        private readonly IMapper _mapper;

        public CategoryController(IMapper mapper)
        {
          _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryDto>> GetAllcategory()
        {
            var categoryResponse = _mapper.Map<IEnumerable<CategoryDto>>(_categories);
            return Ok(categoryResponse);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<CategoryDto>> GetById(int id)
        {
            var categoryresponse = _mapper.Map<CategoryDto>(_categories.FirstOrDefault(x => x.Id == id));
            return Ok(categoryresponse);
        }

        [HttpPost]
        public IActionResult Addcategory(Category category)
        {

            category.Id = _categories.Count() + 1;
            _categories.Add(category);

            return Ok(_categories);

        }

        [HttpPut("{id}")]
        public IActionResult Updatecategory(int id, Category category)
        {
            var existingcategory = _categories.FirstOrDefault(x => x.Id == id);
            if (existingcategory == null)
            {
                return NotFound();
            }
            else
            {
                existingcategory.Name = category.Name;
                existingcategory.Description = category.Description;

                return Ok(existingcategory);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletecategory(int id)
        {
            var existingcategory = _categories.FirstOrDefault(x => x.Id == id);
            if (existingcategory == null)
            {
                return NotFound();
            }
            else
            {
                _categories.Remove(existingcategory);
                return Ok(_categories);
            }
        }
    }
}
