using System.ComponentModel.DataAnnotations;

namespace API.Data.Dtos.Usuario
{
    public class CreateUsuarioDTO
    {
        [Required]
        [MinLength(4)]
        public string UsuarioNome { get; set; }
        [Required]
        [EmailAddress]
        public string UsuarioEmail { get; set;}
        [Required]
        [MaxLength(16)]
        [MinLength(6)]
        public string UsuarioSenha { get; set;}
    }
}
