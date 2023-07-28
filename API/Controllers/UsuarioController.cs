using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Data.Dtos.Usuario;
using API.Models;
using API.Services;

namespace API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    internal class UsuarioController : ControllerBase
    {
        private UsuarioService _usuarioService;

        public UsuarioController( UsuarioService service)
        {
            _usuarioService = service;
        }

        [HttpPost("cadastro")]
        public async Task<IActionResult> Cadastro(CreateUsuarioDTO dto)
        {
            await _usuarioService.Cadastra(dto);
            return Ok("Usuário cadastrado");

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
          var token =  await _usuarioService.Login(dto);
            return Ok(token);
        }
    }
}
