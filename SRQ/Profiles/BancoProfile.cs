using AutoMapper;
using API.Data.Dtos.Banco;
using API.Data.Dtos.Bancos;
using API.Models;

namespace API.Profiles
{
    public class BancoProfile : Profile
    {
        public BancoProfile() {
            CreateMap<BancoCreateDTO, BancosModel>();
        }
    }
}
