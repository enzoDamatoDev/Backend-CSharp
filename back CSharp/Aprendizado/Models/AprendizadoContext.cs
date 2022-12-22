using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aprendizado.Models
{
    public class AprendizadoContext : DbContext
    {
        public DbSet<CategoriaModel> Categorias { get; set; }

        public AprendizadoContext(DbContextOptions<AprendizadoContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
