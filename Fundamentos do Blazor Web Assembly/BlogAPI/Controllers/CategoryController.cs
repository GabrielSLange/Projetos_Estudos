using Blog.Data;
using Blog.Extensions;
using Blog.Models;
using Blog.ViewModel;
using Blog.ViewModel.Categories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Blog.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet("v1/categories")]
        public async Task<IActionResult> GetAsync([FromServices] BlogDataContext _context, [FromServices] IMemoryCache _cache)
        {

            try
            {
                var categories = await _context
                    .Categories
                    .AsNoTracking()
                    .ToListAsync();
                return Ok(categories);
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<Category>>("falha interna no servidor"));
            }
        }

        private List<Category> GetCategories(BlogDataContext _context)
        {
            return _context.Categories.ToList();
        }

        [HttpGet("v1/categories/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id, [FromServices] BlogDataContext _context)
        {
            try
            {
                var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
                if (category == null) return NotFound(new ResultViewModel<Category>("Conteudo não encontrado"));

                return Ok(category);
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Category>("falha interna no servidor"));
            }
        }

        [HttpPost("v1/categories")]
        public async Task<IActionResult> PostAsync([FromServices] BlogDataContext _context, [FromBody] EditorCategoryViewModel entity)
        {
            if (!ModelState.IsValid) return BadRequest(new ResultViewModel<Category>(ModelState.GetErrors()));
            try
            {
                Category category = new Category
                {
                    Id = 0,
                    Name = entity.Name,
                    Slug = entity.Slug.ToLower()
                };
                await _context.AddAsync(category);
                await _context.SaveChangesAsync();

                return Created($"v1/categories/{category.Id}", category);
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, new ResultViewModel<Category>("Não foi possivel salvar no banco"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Category>("falha interna no servidor"));
            }
        }

        [HttpPut("v1/categories/{id:int}")]
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] EditorCategoryViewModel entity, [FromServices] BlogDataContext _context)
        {
            try
            {
                var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
                if (category == null) return NotFound(new ResultViewModel<Category>("Entidade não encontrada no banco"));

                category.Name = entity.Name;
                category.Name = entity.Slug;

                _context.Categories.Update(category);
                await _context.SaveChangesAsync();

                return Ok(category);
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, new ResultViewModel<Category>("Não foi possivel atualizar no banco"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Category>("falha interna no servidor"));
            }
        }

        [HttpDelete("v1/categories/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id, [FromServices] BlogDataContext _context)
        {
            try
            {
                var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
                if (category == null) return NotFound(new ResultViewModel<Category>("Entidade não encontrada no banco"));



                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();

                return Ok(new ResultViewModel<Category>(category));
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, new ResultViewModel<Category>("Não foi possivel deletar no banco"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Category>("falha interna no servidor"));
            }
        }
    }
}
