using Models.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IPostsService
    {
        Task<ICollection<Posts>> GetPosts(string user, string pass);
        Task<Posts> GetPostById(Guid id, string user, string pass);
        Task<Posts> AddPost(Posts post, string user, string pass);
        Task<Posts> UpdatePost(Posts post, string user, string pass);
        Task<int> DeletePost(Guid id, string user, string pass);        
    }
}
