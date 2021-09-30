using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiBlog.Dtos;
using AutoMapper;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Models.Domain;

namespace ApiBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentsService _commentService;
        private readonly IMapper _mapper;

        public CommentController(ICommentsService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetComments()
        {
            return Ok(_mapper.Map<List<CommentsResponseDto>>(await _commentService.GetComments()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentById([FromRoute] Guid id)
        {
            return Ok(_mapper.Map<CommentsResponseDto>(await _commentService.GetCommentById(id)));
        }

        [HttpPost]
        public async Task<IActionResult> AddComment([FromBody] CommentsAddDto comment)
        {
            return Ok(_mapper.Map<CommentsResponseDto>(await _commentService.AddComment(_mapper.Map<Comments>(comment), comment.PostId)));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment([FromRoute] Guid id)
        {
            return Ok(await _commentService.DeleteComment(id));
        }
    }
}
