using AutoMapper;
using API.Data.Dtos.Usuario;
using API.Models;

namespace API.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDTO, UsuarioModel>();
        }
    }
}
