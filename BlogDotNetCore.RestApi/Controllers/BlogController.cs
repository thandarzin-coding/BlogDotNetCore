using BlogDotNetCore.ConsoleApp.Db;
using BlogDotNetCore.ConsoleApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace BlogDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly AppDbContext _dbContext = new AppDbContext();

        [HttpGet]
        public IActionResult GetBlogs()
        {
            var lst = _dbContext.Blogs.ToList();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            BlogDataModel? item = _dbContext.Blogs.AsTracking().FirstOrDefault(x => x.Blog_Id == id);
            if (item is null)
            {
                return NotFound("No Data Found");
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateBlog(BlogDataModel model)
        {
            _dbContext.Blogs.Add(model);

            int result = _dbContext.SaveChanges();
            string message = result > 0 ? "Blog Saving successful " : "Saving Failed";
            return Ok(message);

        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogDataModel model)
        {
            BlogDataModel? item = _dbContext.Blogs.AsTracking().FirstOrDefault(x => x.Blog_Id == id);
            if (item is null)
            {
                return NotFound("No Data Found");
            }
            if (string.IsNullOrEmpty(model.Blog_Title))
            {
                return BadRequest("Blog Title is required");
            }
            if(string.IsNullOrEmpty(model.Blog_Author))
            {
                return BadRequest("Blog Author is required");
            }
            if(string.IsNullOrEmpty(model.Blog_Content))
            {
                return BadRequest("Blog Content is required");
            }
            item.Blog_Title = model.Blog_Title;
            item.Blog_Author = model.Blog_Author;
            item.Blog_Content = model.Blog_Content;
            int result = _dbContext.SaveChanges();
            string message = result > 0 ? "Blog Updating successful " : "Updated Failed";
            return Ok(message);

        }

        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id, BlogDataModel model)
        {
            BlogDataModel? item = _dbContext.Blogs.AsTracking().FirstOrDefault(x => x.Blog_Id == id);
            if (item is null)
            {
                return NotFound("No Data Found");
            }
            if (!string.IsNullOrEmpty(model.Blog_Title))
            {
                item.Blog_Title = model.Blog_Title;
            }
            if (!string.IsNullOrEmpty(model.Blog_Author))
            {
                item.Blog_Author = model.Blog_Author;
            }
            if (!string.IsNullOrEmpty(model.Blog_Content))
            {
                item.Blog_Content = model.Blog_Content;
            }
            int result = _dbContext.SaveChanges();
            string message = result > 0 ? "Blog Updating successful " : "Updated Failed";
            return Ok(message);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            BlogDataModel? item = _dbContext.Blogs.AsTracking().FirstOrDefault(x => x.Blog_Id == id);
            if (item is null)
            {
                return NotFound("No Data Found");
            }
            _dbContext.Blogs.Remove(item);
            int result = _dbContext.SaveChanges();
            string message = result > 0 ? "Deleted successful " : "Deleting Failed";
            return Ok(message);

        }
    }
}
