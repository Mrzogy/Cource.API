using LearningHub.Core.Data;
using LearningHub.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace LearningHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public List<Category> GitAllCategory()
        {
            return categoryService.GitAllCategory();
        }

        [HttpPost]
        public void CreateCategory(Category category)
        {
            categoryService.CreateCategory(category);
        }

        [HttpPut]
        public void UpdateCategory(Category category)
        {
            categoryService.UpdateCategory(category);
        }
        [HttpDelete]
        public void DeleteCategory(int id)
        {
            categoryService.DeleteCategory(id);
        }
        [HttpGet]
        [Route("getByCategoryId/{id}")]
        public Category GetCategoryById(int id)
        {
            return categoryService.GetCategoryById(id);
        }
    }
}
