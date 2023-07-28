using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Data
{
    public class APIRepository : DbContext
    {
        public APIRepository(DbContextOptions<APIRepository> options) : base(options) { }


        public DbSet<BancosModel> Bancos { get; set; }

        public DbSet<UsuarioModel> Usuario { get; set; }

    }

}
