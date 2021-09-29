using Models.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IPostsService
    {
        Task<ICollection<Posts>> GetPosts();
        Task<Posts> GetPostById(Guid id);
        Task<Posts> AddPost(Posts post);
        Task<Posts> UpdatePost(Posts post);
        Task<int> DeletePost(Guid id);
    }
}
