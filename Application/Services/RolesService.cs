using Interfaces.Repositories;
using Interfaces.Services;
using Models.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class RolesService : IRolesService
    {
        private readonly IRolesRepository _rolesRepository;

        public RolesService(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }

        public async Task<Roles> AddRol(Roles rol)
        {
            return await _rolesRepository.AddRol(rol);
        }

        public async Task<int> DeleteRol(Guid id)
        {
            var rolToDelete = await _rolesRepository.GetRolById(id);

            if (rolToDelete == null)
                throw new Exception();

            return await _rolesRepository.DeleteRol(rolToDelete);
        }

        public async Task<Roles> GetRolById(Guid id)
        {
            return await _rolesRepository.GetRolById(id);
        }

        public async Task<ICollection<Roles>> GetRoles()
        {
            return await _rolesRepository.GetRoles();
        }

        public async Task<Roles> UpdateRol(Roles rol)
        {
            var rolToUpdate = await _rolesRepository.GetRolById(rol.Id);

            if (rolToUpdate == null)
                throw new Exception();

            rolToUpdate.Update(rol);

            await _rolesRepository.UpdateRol();
            return rol;
        }
    }
}
