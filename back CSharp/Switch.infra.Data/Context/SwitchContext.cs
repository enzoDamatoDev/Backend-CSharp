using Microsoft.EntityFrameworkCore;
using Switch.Domain.Entities;
using Switch.infra.Data.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace Switch.infra.Data.Context
{
    public class SwitchContext: DbContext

    {
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Postagem> Postagens { get; set; }
        public DbSet<Identificacao> Identificacaos { get; set; }
        public DbSet<InstituicaoEnsino> InstituicaoEnsinos{ get; set; }
        public SwitchContext(DbContextOptions options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostagemConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
