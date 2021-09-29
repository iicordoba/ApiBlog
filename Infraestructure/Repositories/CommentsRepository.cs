using Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CommentsRepository : ICommentsRepository
    {
        private readonly Context _context;
        public CommentsRepository(Context context)
        {
            _context = context;
        }

        public async Task<Comments> AddComment(Comments comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<int> DeleteComment(Comments comment)
        {
            _context.Comments.Remove(comment);
            return await _context.SaveChangesAsync();
        }

        public async Task<Comments> GetCommentById(Guid id)
        {
            return await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Comments>> GetComments()
        {
            return await _context.Comments.ToListAsync();
        }
    }
}
