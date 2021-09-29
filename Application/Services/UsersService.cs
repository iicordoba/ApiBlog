﻿using Interfaces.Repositories;
using Interfaces.Services;
using Models.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IRolesRepository _rolesRepository;

        public UsersService(IUsersRepository usersRepository, IRolesRepository rolesRepository)
        {
            _usersRepository = usersRepository;
            _rolesRepository = rolesRepository;
        }

        public async Task<Users> AddUser(Users user, Guid rolId)
        {
            var userRol = await _rolesRepository.GetRolById(rolId);
            var newUser = new Users()
            {
                User = user.User,
                Pass = user.Pass,
                Activo = user.Activo,
                Rol = userRol
            };
            return await _usersRepository.AddUser(newUser);
        }

        public async Task<int> DeleteUser(Guid id)
        {
            var userToDelete = await _usersRepository.GetUserById(id);

            if (userToDelete == null)
                throw new Exception();

            return await _usersRepository.DeleteUser(userToDelete);
        }

        public async Task<Users> GetUserById(Guid id)
        {
            return await _usersRepository.GetUserById(id);
        }

        public async Task<ICollection<Users>> GetUsers()
        {
            return await _usersRepository.GetUsers();
        }

        public async Task<int> UpdateUser(Users user, Guid rolId)
        {
            var userToUpdate = await _usersRepository.GetUserById(user.Id);
            var userRol = await _rolesRepository.GetRolById(rolId);
            if (userToUpdate == null)
                throw new Exception();

            userToUpdate.Update(user);
            userToUpdate.Rol = userRol;

            return await _usersRepository.UpdateUser();
        }
    }
}
