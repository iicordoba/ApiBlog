using System;
using System.Threading.Tasks;
using ApiBlog.Dtos;
using Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Domain;

namespace ApiBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IPostsService _postsService;
        public PostsController(IPostsService postsService)
        {
            _postsService = postsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            return Ok(await _postsService.GetPosts(HttpContext.Session.GetString("user"), HttpContext.Session.GetString("pass")));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostById([FromRoute] Guid id)
        {
            return Ok(await _postsService.GetPostById(id, HttpContext.Session.GetString("user"), HttpContext.Session.GetString("pass")));
        }

        [HttpPost]
        public async Task<IActionResult> AddPost([FromBody] PostsAddDto post)
        {
            var postToBeAdded = new Posts()
            {
                Tittle = post.Tittle,
                Post = post.Post,
                Status = Models.Enumeration.EstadoPost.Pending,
                Activo = post.Activo
            };                       
            return Ok(await _postsService.AddPost(postToBeAdded,post.SubmitedById));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdatePost([FromRoute] Guid id,[FromBody] PostsUpdateDto post)
        {
            var postToBeUpdated = new Posts()
            {
                Id = id,
                Tittle = post.Tittle,
                Post = post.Post,                  
                Activo = post.Activo
            };
            return Ok(await _postsService.UpdatePost(postToBeUpdated, post.UpdatedById));
        }

        [HttpPatch("{id}/Publish")]
        public async Task<IActionResult> PublishPost([FromRoute] Guid id)
        {
            return Ok(await _postsService.PublishPost(id, HttpContext.Session.GetString("user"), HttpContext.Session.GetString("pass")));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost([FromRoute] Guid id)
        {            
            return Ok(await _postsService.DeletePost(id, HttpContext.Session.GetString("user"), HttpContext.Session.GetString("pass")));
        }
    }
}
