using System.ComponentModel.DataAnnotations;

namespace API.Data.Dtos.Usuario
{
    public class LoginDTO
    {
        [Required]
        public string UsuarioEmail { get; set; }
        [Required]
        public string UsuarioSenha { get; set; }
    }
}
