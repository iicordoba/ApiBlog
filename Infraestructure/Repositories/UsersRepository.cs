using Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Models.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly Context _context;
        public UsersRepository(Context context)
        {
            _context = context;
        }

        public async Task<Users> AddUser(Users user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<int> DeleteUser(Users user)
        {
            _context.Users.Remove(user);
            return await _context.SaveChangesAsync();
        }

        public async Task<Users> GetUserById(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Users>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<int> UpdateUser()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
