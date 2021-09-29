using Api.Dtos;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
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
                Id = Guid.NewGuid(),
                Tittle = post.Tittle,
                Post = post.Post,
                Status = post.Status,
                SubmitedDate = post.SubmitedDate,
                //SubmitedBy = await _context.Users.FindAsync(post.SubmitedById),
                UpdatedDate = post.UpdatedDate,
                //UpdatedBy = await _context.Users.FindAsync(post.UpdatedById),
                PublishedDate = post.PublishedDate,
                Activo = post.Activo
            };                       
            return Ok(await _postsService.AddPost(postToBeAdded));
        }

        [HttpPatch]
        public async Task<IActionResult> UpdatePost([FromBody] PostsUpdateDto post)
        {
            var postToUpdate = new Posts()
            {
                Id = Guid.NewGuid(),
                Tittle = post.Tittle,
                Post = post.Post,
                Status = post.Status,                
                UpdatedDate = post.UpdatedDate,
                //UpdatedBy = await _context.Users.FindAsync(post.UpdatedById),
                PublishedDate = post.PublishedDate,
                Activo = post.Activo
            };
            return Ok(await _postsService.UpdatePost(postToUpdate));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost([FromRoute] Guid id)
        {            
            return Ok(await _postsService.DeletePost(id));
        }
    }
}
