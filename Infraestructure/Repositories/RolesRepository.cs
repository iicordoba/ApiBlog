using Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RolesRepository : IRolesRepository
    {
        private readonly Context _context;
        public RolesRepository(Context context)
        {
            _context = context;
        }

        public async Task<Roles> AddRol(Roles rol)
        {
            _context.Roles.Add(rol);
            await _context.SaveChangesAsync();
            return rol;
        }

        public async Task<int> DeleteRol(Roles rol)
        {
            _context.Roles.Remove(rol);
            return await _context.SaveChangesAsync();
        }

        public async Task<Roles> GetRolById(Guid id)
        {
            return await _context.Roles.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Roles>> GetRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<int> UpdateRol()
        {
            return await _context.SaveChangesAsync();       
        }
    }
}
