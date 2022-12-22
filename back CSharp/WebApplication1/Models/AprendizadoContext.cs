using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class AprendizadoContext : DbContext
    {
        public DbSet<Categoria> categorias { get; set; }

        public AprendizadoContext(DbContextOptions options) : base(options)
        {

        }
    }
}
