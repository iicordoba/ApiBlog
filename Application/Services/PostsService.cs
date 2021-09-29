﻿using Interfaces.Repositories;
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

        public async Task<int> UpdatePost(Posts post, Guid userId)
        {
            var postToUpdate = await _postsRepository.GetPostById(post.Id);
            var user = await _usersRepository.GetUserById(userId);
            if (postToUpdate == null)
                throw new Exception();

            postToUpdate.Update(post,user);

            return await _postsRepository.UpdatePost(postToUpdate);
        }

        public async Task<int> PublishPost(Guid id, Guid userId)
        {
            var postToPublish = await _postsRepository.GetPostById(id);
            var user = await _usersRepository.GetUserById(userId);
            if (postToPublish == null)
                throw new Exception();

            postToPublish.Publish(postToPublish,user);


            return await _postsRepository.UpdatePost(postToPublish);
        }
    }
}
