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
    public class PostsService : IPostsService
    {
        private readonly IPostsRepository _postsRepository;
        
        public PostsService(IPostsRepository postsRepository)
        {
            _postsRepository = postsRepository;
        }
        public async Task<Posts> AddPost(Posts post)
        {
            //var user = await _usersRepository.GetUserById(post.SubmitedBy.Id);
            //if (user == null)
            //    throw;
            var newPost = new Posts() 
            {
                Tittle = post.Tittle,
                Post = post.Post,
                Status = post.Status,
                SubmitedDate = DateTime.Now,
                //SubmitedBy = user,
                UpdatedDate = DateTime.Now,
                //UpdatedBy = user,
                PublishedDate = post.PublishedDate,
                Activo = post.Activo
            };
            return await _postsRepository.AddPost(newPost);
        }

        public async Task<int> DeletePost(Guid id)
        {
            var postToDelete = await _postsRepository.GetPostById(id);

            if (postToDelete == null)
                throw new Exception();

            return await _postsRepository.DeletePost(postToDelete);
        }

        public async Task<Posts> GetPostById(Guid id)
        {
            return await _postsRepository.GetPostById(id);
        }

        public async Task<ICollection<Posts>> GetPosts()
        {
            return await _postsRepository.GetPosts();
        }

        public async Task<Posts> UpdatePost(Posts post)
        {
            var postToUpdate = await _postsRepository.GetPostById(post.Id);
           
            if (postToUpdate == null)
                throw new Exception();

            postToUpdate.Update(post);

            return await _postsRepository.UpdatePost(postToUpdate);
        }
    }
}
