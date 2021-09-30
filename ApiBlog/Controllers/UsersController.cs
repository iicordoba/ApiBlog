﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiBlog.Dtos;
using AutoMapper;
using Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Domain;

namespace ApiBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly IMapper _mapper;

        public UsersController(IUsersService usersService, IMapper mapper)
        {
            _usersService = usersService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(_mapper.Map<List<UsersResponseDto>>(await _usersService.GetUsers()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsersById(Guid id)
        {
            return Ok(_mapper.Map<UsersResponseDto>(await _usersService.GetUserById(id)));
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UsersAddDto user)
        {
            return Ok(_mapper.Map<UsersResponseDto>(await _usersService.AddUser(_mapper.Map<Users>(user), user.RolId)));
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateUser([FromBody] UsersUpdateDto user)
        {            
            return Ok(_mapper.Map<UsersResponseDto>(await _usersService.UpdateUser(_mapper.Map<Users>(user), user.RolId)));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            return Ok(await _usersService.DeleteUser(id));
        }

        [HttpGet("login")]
        public async Task<IActionResult> Login([FromQuery] string user, string pass)
        {
            var result = await _usersService.Login(user, pass);

            HttpContext.Session.SetString("user", result.User);
            HttpContext.Session.SetString("pass", result.Pass);

            return Ok(result);            
        }

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.SetString("user", null);
            HttpContext.Session.SetString("pass", null);

            return Ok();
        }
    }
}
