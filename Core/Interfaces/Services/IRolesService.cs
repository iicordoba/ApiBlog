using Models.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interfaces.Services
{
     public interface IRolesService
    {
        Task<ICollection<Roles>> GetRoles();
        Task<Roles> GetRolById(Guid id);
        Task<Roles> AddRol(Roles rol);
        Task<Roles> UpdateRol(Roles rol);
        Task<int> DeleteRol(Guid id);
    }
}
