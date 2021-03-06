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
    public class CommentController : ControllerBase
    {
        private readonly ICommentsService _commentService;

        public CommentController(ICommentsService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetComments()
        {
            return Ok(await _commentService.GetComments());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentById([FromRoute] Guid id)
        {
            return Ok(await _commentService.GetCommentById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddComment([FromBody] CommentsAddDto comment)
        {
            var commentToBeAdded = new Comments()
            {
                Comment = comment.Comment,
                Name = comment.Name,
                Post = comment.Post,
                Activo = comment.Activo,
            };
            return Ok(await _commentService.AddComment(commentToBeAdded));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment([FromRoute] Guid id)
        {
            return Ok(await _commentService.DeleteComment(id));
        }
    }
}
