using Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IUsersService
    {
        Task<ICollection<Users>> GetUsers();
        Task<Users> GetUserById(Guid id);
        Task<Users> AddUser(Users user);
        Task<int> UpdateUser(Users user);
        Task<int> DeleteUser(Guid id);
    }
}
