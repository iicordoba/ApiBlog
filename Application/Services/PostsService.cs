using Interfaces.Repositories;
using Interfaces.Services;
using Models.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Enumeration;

namespace Services
{
    public class PostsService : IPostsService
    {
        private readonly IPostsRepository _postsRepository;
        private readonly IUsersRepository _usersRepository;
        private readonly string _editor = "Editor";
        private readonly string _escritor = "Escritor";



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
                Status = EstadoPost.Pending,
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
        public async Task<int> DeletePost(Guid id, string user, string pass)
        {
            var postToDelete = await _postsRepository.GetPostById(id);
            if (postToDelete == null)
                throw new Exception();

            return await _postsRepository.DeletePost(postToDelete);
            
        }

        public async Task<Posts> GetPostById(Guid id, string user, string pass)
        {
            var givenUser = await _usersRepository.GetUserByUserNameAndPass(user, pass);
            var post = await _postsRepository.GetPostById(id);

            if (givenUser.Rol.Rol == _editor) //devuelvo los posts que se encuentran como "Submitted"
            {
                throw new Exception("Su usuario no posee los permisos necesarios");
            }
            if (givenUser.Rol.Rol == _escritor) //devuelvo los posts que se encuentran como "Pending" y "Rejected"
            {
                throw new Exception("Su usuario no posee los permisos necesarios");
            }
            //el rol del user es lector - devuelvo los posts que se encuentran como "Published"
            if(post.Status == EstadoPost.Published)
                return post;
            throw new Exception("Su usuario no posee los permisos necesarios");
        }

        public async Task<ICollection<Posts>> GetPosts(string user, string pass)
        {
            var givenUser = await _usersRepository.GetUserByUserNameAndPass(user, pass);
            var posts = await _postsRepository.GetPosts();

            if (givenUser.Rol.Rol == _editor) //devuelvo los posts que se encuentran como "Submitted"
            {
                if (posts.Status == EstadoPost.Submitted || posts.Status == EstadoPost.Published)
                    return posts;
                throw new Exception("Su usuario no posee los permisos necesarios");
            }
            if (givenUser.Rol.Rol == _escritor) //devuelvo los posts que se encuentran como "Pending" y "Rejected"
            {
                if (post.Status == EstadoPost.Pending || post.Status == EstadoPost.Published || post.Status == EstadoPost.Rejected)
                    return post;
                throw new Exception("Su usuario no posee los permisos necesarios");
            }
            //el rol del user es lector - devuelvo los posts que se encuentran como "Published"
            if (post.Status == EstadoPost.Published)
                return post;
            throw new Exception("Su usuario no posee los permisos necesarios");
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

        public async Task<int> UpdatePostStatus(Posts post, string user, string pass)
        {
            var givenUser = await _usersRepository.GetUserByUserNameAndPass(user, pass);
            var postToPublish = await _postsRepository.GetPostById(post.Id);
            if (postToPublish == null)
                throw new Exception();

            postToPublish.Status = 1; //VER CUAL ES EL STATUS DE PUBLISH
            postToPublish.PublishedDate = DateTime.Now;
            postToPublish.UpdatedDate = DateTime.Now;
            postToPublish.UpdatedBy = givenUser;

            return await _postsRepository.UpdatePost(postToPublish);
        }
    }
}
