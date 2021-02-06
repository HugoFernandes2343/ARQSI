using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIC.DTOs;
using SIC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIC.Controllers
{
    [Route("api/Category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly SICContext _context;

        public CategoryController(SICContext context)
        {
            _context = context;
        }

        // GET: api/Category
        [HttpGet]
        public IEnumerable<Category> GetCategory()
        {
            return _context.Category;
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = await _context.Category.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            Category fatherCat = category.fatherCat;
            return Ok(new CategoryDto(category));
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory([FromRoute] int id, [FromBody] CategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!CategoryExists(id))
            {
                return BadRequest();
            }

            if (CategoryNameExists(categoryDto.name))
            {
                return BadRequest("New Category name already exists");
            }

            var category = await _context.Category.FindAsync(id);
            category.updateName(categoryDto.name);
            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Category
        [HttpPost]
        public async Task<IActionResult> PostCategory([FromBody] CategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Category cate = categoryDto.toCategory();
            List<Category> cats = cate.getFathers();

            foreach (Category cat in cats)
            {
                if (!CategoryNameExists(cat.name))
                {
                    return BadRequest("One of the names already exists");
                }
            }

            var fatherCat = await _context.Category.SingleOrDefaultAsync(e => e.name == cate.fatherCat.name);
            cate.updateFather(fatherCat);
            _context.Category.Add(cate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = cate.CategoryId }, new CategoryDto(cate));
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = await _context.Category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Category.Remove(category);
            await _context.SaveChangesAsync();

            return Ok(new CategoryDto(category));
        }

        private bool CategoryExists(int id)
        {
            return _context.Category.Any(e => e.CategoryId == id);
        }

        private bool CategoryNameExists(string name)
        {
            return _context.Category.Any(e => e.name == name);
        }
    }
}