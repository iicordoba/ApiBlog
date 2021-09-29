using Models.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface ICommentsService
    {
        Task<ICollection<Comments>> GetComments();
        Task<Comments> GetCommentById(Guid id);
        Task<Comments> AddComment(Comments comment, Guid postId);
        Task<int> DeleteComment(Guid id);
    }
}
