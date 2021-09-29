using Api.Dtos;
using Interfaces.Repositories;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;            
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _usersService.GetUsers());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsersById(Guid id)
        {
            return Ok(await _usersService.GetUserById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UsersAddDto user)
        {
            var userToBeAdded = new Users()
            {
                User = user.User,
                Pass = user.Pass,
                Activo = user.Activo,
            };
            return Ok(await _usersService.AddUser(userToBeAdded, user.RolId));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateUser([FromBody] UsersUpdateDto user, [FromRoute] Guid id)
        {
            var userToBeUpdated = new Users()
            {
                Id = id,
                User = user.User,
                Pass = user.Pass,
                Activo = user.Activo,
            };
            return Ok(await _usersService.UpdateUser(userToBeUpdated, user.RolId));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            return Ok(await _usersService.DeleteUser(id));
        }
    }
}
