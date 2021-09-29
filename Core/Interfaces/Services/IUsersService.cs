using Models.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IUsersService
    {
        Task<ICollection<Users>> GetUsers();
        Task<Users> GetUserById(Guid id);
        Task<Users> AddUser(Users user, Guid rolId);
        Task<int> UpdateUser(Users user, Guid rolId);
        Task<int> DeleteUser(Guid id);
    }
}
