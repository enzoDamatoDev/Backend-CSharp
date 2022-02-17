using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using Switch.Domain.Entities;
using Switch.infra.Data.Context;
using Switch.Infra.CrossCutting.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SwitchAPP
{
    class Program
    {

        static void Main(string[] args)
        {
            Usuario CriarUser(String nome, String sobrenome, String email, String senha)
            {
                return new Usuario()
                {
                    Nome = nome,
                    Sobrenome = sobrenome,
                    Email = email,
                    Senha = senha,
                    DataNascimento = DateTime.Now,
                    Sexo = Switch.Domain.Enum.SexoEnum.Masculino,
                    UrlFoto = @"D:\enzod\downloadJogos\loli\jij"
                };
            }

            var optionsBuilder = new DbContextOptionsBuilder<SwitchContext>();
            optionsBuilder.UseLazyLoadingProxies();
            var conn = "Server = localhost; userid = root; password = lembrei1; database = SwitchDB";
            optionsBuilder.UseMySql(conn, ServerVersion.AutoDetect(conn), m => m.MigrationsAssembly("Switch.Infra.Data"));

            try
            {
                using (var dbcontext = new SwitchContext(optionsBuilder.Options))
                {
                    /////escrever log mo terminal
                    dbcontext.GetService<ILoggerFactory>().AddProvider(new Logger());


                    /////   ADICIONAR VARIOS
                    //dbcontext.usuarios.AddRange(users);
                    //dbcontext.SaveChanges();

                    /////   ADICIONAR UM

                    //var usuario = CriarUser("malu", "ferreira", "maluzita@", "damamor");
                    //usuario.InstituicaoEnsinos.Add(new InstituicaoEnsino() { nome = "mack"});
                    //usuario.Indentificacao = new Identificacao() { Numero = "356513" };
                    //dbcontext.usuarios.Add(usuario);
                    //dbcontext.SaveChanges();


                    /////  PEGAR DA BASE
                    //var resultado = dbcontext.usuarios.ToList();


                    var resultado = dbcontext.usuarios.FirstOrDefault(u => u.Nome.Equals("malu"));
                    var inst = resultado.InstituicaoEnsinos.FirstOrDefault(i => i.nome.Equals("mack"));
                    inst.DataFormacao = DateTime.Now;
                    dbcontext.SaveChanges();


                    //foreach (Usuario user in resultado){
                    //    Console.WriteLine(user.Id.ToString()+ " "+ user.Senha);
                    //}
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
            Console.WriteLine("salvo");

        }
    }
}
