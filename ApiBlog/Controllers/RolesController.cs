using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiBlog.Dtos;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public RolesController(IRolesService rolesService, IMapper mapper)
        {
            _rolesService = rolesService;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtiene todos los roles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            return Ok(_mapper.Map<List<RolesResponseDto>>(await _rolesService.GetRoles()));
        }

        /// <summary>
        /// Obtiene un rol por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRolById([FromRoute] Guid id)
        {
            return Ok(_mapper.Map<RolesResponseDto>(await _rolesService.GetRolById(id)));
        }

        [HttpPost]
        public async Task<IActionResult> AddRol([FromBody] RolesAddDto rol)
        {                  
            return Ok(_mapper.Map<RolesResponseDto>(await _rolesService.AddRol(_mapper.Map<Roles>(rol))));            
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateRol([FromBody] RolesUpdateDto rol)
        {
            return Ok(_mapper.Map<RolesResponseDto>(await _rolesService.UpdateRol(_mapper.Map<Roles>(rol))));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRol([FromRoute] Guid id)
        {            
            return Ok(await _rolesService.DeleteRol(id));
        }
    }
}
