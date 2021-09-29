using Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Repositories
{
    public interface ICommentsRepository
    {
        Task<ICollection<Comments>> GetComments();
        Task<Comments> GetCommentById(Guid id);
        Task<Comments> AddComment(Comments comment);
        Task<int> DeleteComment(Comments comment);
    }
}
