using Models.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Repositories
{
    public interface IPostsRepository
    {
        Task<ICollection<Posts>> GetPosts();
        Task<Posts> GetPostById(Guid id);
        Task<Posts> AddPost(Posts post);
        //public async Task<Posts> UpdatePost(Posts post);
        Task<int> DeletePost(Posts post);
        Task<Posts> UpdatePost(Posts post);
    }
}
