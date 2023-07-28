using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using API.Models;

namespace API.Data
{
    public class UsuarioDbContext : IdentityDbContext<UsuarioModel>
    {

        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> opts) : base(opts)
        {
            
        }

        public DbSet<UsuarioModel> Usuario { get; set; }
    }
}
