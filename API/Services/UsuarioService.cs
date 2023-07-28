using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Data.Dtos.Usuario;
using API.Models;

namespace API.Services
{
    internal class UsuarioService
    {
        private IMapper mapper;
        private UserManager<UsuarioModel> _userManager;
        private SignInManager<UsuarioModel> _signInManager;
        private TokenService _tokenService;
        private UsuarioDbContext  _context;

        public UsuarioService(IMapper map, UserManager<UsuarioModel> userManager, SignInManager<UsuarioModel> signInManager, TokenService tokenService, UsuarioDbContext db)
        {
            mapper = map;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _context = db;
        }

        public async Task Cadastra(CreateUsuarioDTO dto)
        {
            UsuarioModel usuario = mapper.Map<UsuarioModel>(dto);

            var resultado = await _userManager.CreateAsync(usuario, dto.UsuarioSenha);

            if (!resultado.Succeeded)
            {
                throw new ApplicationException("Falha no cadastro");
            }
        }

        public async Task<string> Login (LoginDTO dto)
        {
            var resultado = await _signInManager.PasswordSignInAsync(dto.UsuarioEmail, dto.UsuarioSenha, false, false);

            if (!resultado.Succeeded)
            {
                throw new UnauthorizedAccessException("Login inválido");
            }

            var usuario = _context.Usuario.FirstOrDefault(user => user.NormalizedEmail == dto.UsuarioEmail.ToUpper());

            var token = _tokenService.GenerateToken(usuario);

            return token;
        }   

    }
}
