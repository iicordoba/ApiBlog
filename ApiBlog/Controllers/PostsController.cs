using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiBlog.Dtos;
using AutoMapper;
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
        private readonly IMapper _mapper;
        public PostsController(IPostsService postsService, IMapper mapper)
        {
            _postsService = postsService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            return Ok(_mapper.Map<List<PostsResponseDto>>(await _postsService.GetPosts(HttpContext.Session.GetString("user"), HttpContext.Session.GetString("pass"))));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostById([FromRoute] Guid id)
        {
            return Ok(_mapper.Map<PostsResponseDto>(await _postsService.GetPostById(id, HttpContext.Session.GetString("user"), HttpContext.Session.GetString("pass"))));
        }

        [HttpPost]
        public async Task<IActionResult> AddPost([FromBody] PostsAddDto post)
        {
            return Ok(_mapper.Map<PostsResponseDto>(await _postsService.AddPost(_mapper.Map<Posts>(post), HttpContext.Session.GetString("user"), HttpContext.Session.GetString("pass"))));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdatePost([FromBody] PostsUpdateDto post)
        {
            return Ok(_mapper.Map<PostsResponseDto>(await _postsService.UpdatePost(_mapper.Map<Posts>(post), HttpContext.Session.GetString("user"), HttpContext.Session.GetString("pass"))));
        }        

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost([FromRoute] Guid id)
        {            
            return Ok(await _postsService.DeletePost(id, HttpContext.Session.GetString("user"), HttpContext.Session.GetString("pass")));
        }
    }
}
