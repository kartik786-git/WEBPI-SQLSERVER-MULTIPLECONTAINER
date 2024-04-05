using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiefcoremigrationautomatic.Entity;
using WebApiefcoremigrationautomatic.Services;

namespace WebApiefcoremigrationautomatic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blogs = await _blogService.GetAllAsync();
            return Ok(blogs);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blog = await _blogService.GetByIdAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }
        [HttpPost]
        public async Task<ActionResult> Create(Blog blog)
        {
            var createdBlog = await _blogService.CreateAsync(blog);
            return CreatedAtAction(nameof(GetById), new { id = createdBlog.Id }, createdBlog);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Blog updatedBlog)
        {
            var blog = await _blogService.UpdateAsync(id, updatedBlog);
            if (blog == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var blog = await _blogService.DeleteAsync(id);
            if (blog == 0)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
