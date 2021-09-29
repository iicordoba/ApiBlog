﻿using System;
using System.Threading.Tasks;
using ApiBlog.Dtos;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Models.Domain;

namespace ApiBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IRolesService _rolesService;
        public RolesController(IRolesService rolesService)
        {
            _rolesService = rolesService;
        }

        /// <summary>
        /// Obtiene todos los roles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            return Ok(await _rolesService.GetRoles());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRolById([FromRoute] Guid id)
        {
            return Ok(await _rolesService.GetRolById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddRol([FromBody] RolesAddDto rol)
        {
            var rolToBeAdded = new Roles()
            {
                Rol = rol.Rol,
                Activo = rol.Activo
            };
            return Ok(await _rolesService.AddRol(rolToBeAdded));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateRol([FromRoute] Guid id, [FromBody] RolesUpdateDto rol)
        {
            var rolToBeUpdated = new Roles()
            {
                Id = id,
                Rol = rol.Rol,
                Activo = rol.Activo
            };
            return Ok(await _rolesService.UpdateRol(rolToBeUpdated));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRol([FromRoute] Guid id)
        {            
            return Ok(await _rolesService.DeleteRol(id));
        }
    }
}
