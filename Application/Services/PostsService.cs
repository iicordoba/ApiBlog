using Interfaces.Repositories;
using Interfaces.Services;
using Models.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class PostsService : IPostsService
    {
        private readonly IPostsRepository _postsRepository;
        private readonly IUsersRepository _usersRepository;
        
        public PostsService(IPostsRepository postsRepository, IUsersRepository usersRepository)
        {
            _postsRepository = postsRepository;
            _usersRepository = usersRepository;
        }
        public async Task<Posts> AddPost(Posts post, Guid userId)
        {
            var user = await _usersRepository.GetUserById(userId);
            if (user == null)
                throw new Exception();
            var newPost = new Posts() 
            {
                Tittle = post.Tittle,
                Post = post.Post,
                Status = post.Status,
                SubmitedDate = DateTime.Now,
                SubmitedBy = user,
                UpdatedDate = DateTime.Now,
                UpdatedBy = user,
                Activo = post.Activo
            };
            return await _postsRepository.AddPost(newPost);
        }

        /// <summary>
        /// Metodo para eliminar un post
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        public async Task<int> UpdatePost(Posts post, Guid userId)
        {
            var postToUpdate = await _postsRepository.GetPostById(post.Id);
            if (postToUpdate == null)
                throw new Exception();

            post.UpdatedBy = await _usersRepository.GetUserById(userId);
            postToUpdate.Update(post);

            return await _postsRepository.UpdatePost(postToUpdate);
        }

        public async Task<int> PublishPost(Guid id, Guid userId)
        {
            var postToPublish = await _postsRepository.GetPostById(id);
            if (postToPublish == null)
                throw new Exception();

            postToPublish.Status = 1; //VER CUAL ES EL STATUS DE PUBLISH
            postToPublish.PublishedDate = DateTime.Now;
            postToPublish.UpdatedDate = DateTime.Now;
            postToPublish.UpdatedBy = await _usersRepository.GetUserById(userId);

            return await _postsRepository.UpdatePost(postToPublish);
        }
    }
}
