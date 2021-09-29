using Models.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interfaces.Repositories
{
    public interface IPostsRepository
    {
        Task<ICollection<Posts>> GetPosts();
        Task<Posts> GetPostById(Guid id);
        Task<Posts> AddPost(Posts post);
        Task<int> DeletePost(Posts post);
        Task<int> UpdatePost(Posts post);
    }
}
