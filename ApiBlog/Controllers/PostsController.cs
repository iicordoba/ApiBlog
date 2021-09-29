using System;
using System.Threading.Tasks;
using ApiBlog.Dtos;
using Interfaces.Services;
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
            return Ok(await _postsService.GetPosts());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostById([FromRoute] Guid id)
        {
            return Ok(await _postsService.GetPostById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddPost([FromBody] PostsAddDto post)
        {
            var postToBeAdded = new Posts()
            {
                Tittle = post.Tittle,
                Post = post.Post,
                Status = post.Status,
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
                Status = post.Status,   
                Activo = post.Activo
            };
            return Ok(await _postsService.UpdatePost(postToBeUpdated, post.UpdatedById));
        }

        [HttpPatch("{id}/Publish")]
        public async Task<IActionResult> PublishPost([FromRoute] Guid id)
        {
            var userId = Guid.NewGuid();//set userId
            return Ok(await _postsService.PublishPost(id,userId));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost([FromRoute] Guid id)
        {            
            return Ok(await _postsService.DeletePost(id));
        }
    }
}
