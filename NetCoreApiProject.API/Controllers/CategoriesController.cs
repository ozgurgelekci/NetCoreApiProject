using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetCoreApiProject.API.DTOs.Category;
using NetCoreApiProject.API.Filters;
using NetCoreApiProject.Core.Entities.Concrete;
using NetCoreApiProject.Core.Services;

namespace NetCoreApiProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }

        [ServiceFilter(typeof(NotFoundFilter<Category>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            return Ok(_mapper.Map<CategoryDto>(category));
        }

        [ServiceFilter(typeof(NotFoundFilter<Category>))]
        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetWithProductsById(int id)
        {
            var result = await _categoryService.GetWithProductsByCategoryIdAsync(id);
            return Ok(_mapper.Map<CategoryWithProductsDto>(result));
        }

        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Save(CategoryDto categoryDto)
        {
            var newcategory = await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));
            return Created(string.Empty, _mapper.Map<CategoryDto>(newcategory));
        }

        [ValidationFilter]
        [HttpPut]
        public IActionResult Update(CategoryDto categoryDto)
        {
            _categoryService.Update(_mapper.Map<Category>(categoryDto));
            return NoContent();
        }

        [ServiceFilter(typeof(NotFoundFilter<Category>))]
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var category = _categoryService.GetByIdAsync(id).Result;
            _categoryService.Remove(category);
            return NoContent();
        }

    }
}
