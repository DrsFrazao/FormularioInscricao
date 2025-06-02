using Microsoft.EntityFrameworkCore;
using FormularioInscricao.Models;
using System.Collections.Generic;

namespace FormularioInscricao.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Inscricao> Inscricoes { get; set; }
    }
}
