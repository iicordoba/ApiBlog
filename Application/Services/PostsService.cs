using Interfaces.Repositories;
using Interfaces.Services;
using Models.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Enumeration;
using System.Linq;

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
        public async Task<Posts> AddPost(Posts post, string user, string pass)
        {
            var givenUser = await _usersRepository.GetUserByUserNameAndPass(user, pass);
            if (givenUser == null)
                throw new Exception();
            if (givenUser.Rol.TipoRol != TipoRol.Writer)
                throw new Exception("Su usuario no posee los permisos necesarios");
            var newPost = new Posts() 
            {
                Tittle = post.Tittle,
                Post = post.Post,
                Status = EstadoPost.Pending,
                SubmitedDate = DateTime.Now,
                SubmitedBy = givenUser,
                UpdatedDate = DateTime.Now,
                UpdatedBy = givenUser,
                Activo = post.Activo
            };
            return await _postsRepository.AddPost(newPost);
        }

        /// <summary>
        /// Metodo para eliminar un post
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> DeletePost(Guid id, string user, string pass)// chequar que Writer solo borra
        {
            var givenUser = await _usersRepository.GetUserByUserNameAndPass(user, pass);

            if (givenUser == null)
                throw new Exception();
            if (givenUser.Rol.TipoRol != TipoRol.Writer)
                throw new Exception("Su usuario no posee los permisos necesarios");

            var postToDelete = await _postsRepository.GetPostById(id);

            if (postToDelete == null)
                throw new Exception();

            return await _postsRepository.DeletePost(postToDelete);            
        }

        public async Task<Posts> GetPostById(Guid id, string user, string pass)
        {
            var givenUser = await _usersRepository.GetUserByUserNameAndPass(user, pass);
            var post = await _postsRepository.GetPostById(id);

            if (givenUser == null)
            {
                if (post.Status == EstadoPost.Published && post.Activo is true)
                    return post;
                throw new Exception("Su usuario no posee los permisos necesarios");
            }
            if (givenUser.Rol.TipoRol == TipoRol.Editor) 
            {
                if (post.Status == EstadoPost.Submitted || post.Status == EstadoPost.Published)
                    return post;
                throw new Exception("Su usuario no posee los permisos necesarios");
            }
            if (givenUser.Rol.TipoRol == TipoRol.Writer) 
            {
                if((post.Status == EstadoPost.Pending || post.Status == EstadoPost.Rejected) && post.Activo is true)
                    return post;
                throw new Exception("Su usuario no posee los permisos necesarios");
            }
            throw new Exception("Su usuario no posee los permisos necesarios");
        }

        public async Task<ICollection<Posts>> GetPosts(string user, string pass)
        {
            var givenUser = await _usersRepository.GetUserByUserNameAndPass(user, pass);
            var posts = await _postsRepository.GetPosts();
            
            if (givenUser == null)
                return posts.Where(x => x.Status == EstadoPost.Published && x.Activo is true).ToList();

            if (givenUser.Rol.TipoRol == TipoRol.Editor) 
                return posts.Where(x => x.Status == EstadoPost.Submitted || x.Status == EstadoPost.Published).ToList();
            
            return posts.Where(x => (x.Status == EstadoPost.Pending || x.Status == EstadoPost.Rejected) && x.Activo is true).ToList();            
        }

        public async Task<Posts> UpdatePost(Posts post, string user, string pass)
        {
            var givenUser = await _usersRepository.GetUserByUserNameAndPass(user, pass);
            
            if (givenUser == null)
                throw new Exception("Su usuario no posee los permisos necesarios");

            var postToUpdate = await _postsRepository.GetPostById(post.Id);

            if (postToUpdate == null)
                throw new Exception();

            if (givenUser.Rol.TipoRol == TipoRol.Editor)
            {
                if (postToUpdate.Status == EstadoPost.Submitted)
                {
                    if (post.Status == EstadoPost.Published || post.Status == EstadoPost.Rejected)
                    {
                        postToUpdate.Status = post.Status;
                        if (post.Status == EstadoPost.Published)
                            postToUpdate.PublishedDate = DateTime.Now;
                    }                        
                }
                postToUpdate.Activo = post.Activo;
            }
            if (givenUser.Rol.TipoRol == TipoRol.Writer)
            {
                if (postToUpdate.Status == EstadoPost.Pending || postToUpdate.Status == EstadoPost.Rejected)
                {
                    if (post.Status == EstadoPost.Pending || post.Status == EstadoPost.Submitted)
                        postToUpdate.Status = post.Status;
                }
                postToUpdate.Tittle = post.Tittle;
                postToUpdate.Post = post.Post;
            }

            postToUpdate.UpdatedDate = DateTime.Now;
            postToUpdate.UpdatedBy = givenUser;

            await _postsRepository.UpdatePost(postToUpdate);

            return postToUpdate;
        }
    }
}
