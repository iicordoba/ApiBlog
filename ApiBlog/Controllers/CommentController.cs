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
                Activo = comment.Activo,
            };
            return Ok(await _commentService.AddComment(commentToBeAdded, comment.PostId));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment([FromRoute] Guid id)
        {
            return Ok(await _commentService.DeleteComment(id));
        }
    }
}
