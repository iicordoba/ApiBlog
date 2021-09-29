using Interfaces.Repositories;
using Interfaces.Services;
using Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CommentsService : ICommentsService
    {
        private readonly ICommentsRepository _commentsRepository;
        private readonly IPostsRepository _postsRepository;

        public CommentsService(ICommentsRepository commentsRepository, IPostsRepository postsRepository)
        {
            _commentsRepository = commentsRepository;
            _postsRepository = postsRepository;
        }

        public async Task<Comments> AddComment(Comments comment)
        {
            var commentPost = await _postsRepository.GetPostById(comment.Post.Id);
            var newComment = new Comments()
            {
                Comment = comment.Comment,
                Name = comment.Name,
                Post = commentPost,//¿por qué tengo que ir a buscar el post y no pasar directamente el objeto que me viene en comment.post?
                Activo = comment.Activo,
                SubmitedDate = DateTime.Now
            };
            return await _commentsRepository.AddComment(newComment);
        }

        public async Task<int> DeleteComment(Guid id)
        {
            var commentToDelete = await _commentsRepository.GetCommentById(id);
            if (commentToDelete == null)
                throw new Exception();
            return await _commentsRepository.DeleteComment(commentToDelete);
        }

        public async Task<Comments> GetCommentById(Guid id)
        {
            return await _commentsRepository.GetCommentById(id);
        }

        public async Task<ICollection<Comments>> GetComments()
        {
            return await _commentsRepository.GetComments();
        }
    }
}
