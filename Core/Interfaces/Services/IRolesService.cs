using Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
     public interface IRolesService
    {
        Task<ICollection<Roles>> GetRoles();
        Task<Roles> GetRolById(Guid id);
        Task<Roles> AddRol(Roles rol);
        Task<int> UpdateRol(Roles rol);
        Task<int> DeleteRol(Guid id);
    }
}
