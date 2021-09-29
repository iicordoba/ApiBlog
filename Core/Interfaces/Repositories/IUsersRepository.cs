using Models.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interfaces.Repositories
{
    public interface IUsersRepository
    {
        Task<ICollection<Users>> GetUsers();
        Task<Users> GetUserById(Guid id);
        Task<Users> AddUser(Users user);
        Task<int> UpdateUser();
        Task<int> DeleteUser(Users user);
    }
}
