using WebApplication1.Model;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Pessoa> Pessoa => Set<Pessoa>();
        public DbSet<Endereco> Endereco => Set<Endereco>();
    }
}