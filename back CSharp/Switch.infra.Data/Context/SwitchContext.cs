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
        public DbSet<Amigo> Amigos { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Identificacao> Identificacaos { get; set; }
        public DbSet<InstituicaoEnsino> InstituicaoEnsinos{ get; set; }
        public DbSet<LocalTrabalho> LocalTrabalhos{ get; set; }
        public DbSet<UsuarioGrupo> UsuarioGrupos{ get; set; }
        public DbSet<ProcurandoPor> ProcurandoPors{ get; set; }
        public DbSet<StatusRelacionamento> StatusRelacionamento { get; set; }
        public SwitchContext(DbContextOptions options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AmigoConfiguration());
            modelBuilder.ApplyConfiguration(new ComentarioConfiguration());
            modelBuilder.ApplyConfiguration(new GrupoConfiguration());
            modelBuilder.ApplyConfiguration(new PostagemConfiguration());
            modelBuilder.ApplyConfiguration(new ProcurandoPorConfiguration());
            modelBuilder.ApplyConfiguration(new StatusRelacionamentoConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioGrupoConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
