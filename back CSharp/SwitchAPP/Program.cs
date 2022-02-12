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
                    //Sobrenome = sobrenome,
                    //Email = email,
                    //Senha = senha,
                    //DataNascimento = DateTime.Now,
                    //Sexo = Switch.Domain.Enum.SexoEnum.Masculino,
                    //UrlFoto = @"D:\enzod\downloadJogos\loli\jij"
                };
            }

            Usuario user1 = CriarUser("enzo", "damis", "enzo@out", "lembra");
            Usuario user2 = CriarUser("luan", "damis", "luan@out", "lembra");
            Usuario user3 = CriarUser("paipa", "damis", "paipa@out", "lembra");
            Usuario user4 = CriarUser("dani", "damis", "dani@out", "lembra");
            Usuario user5 = CriarUser("bamba", "damis", "bamba@out", "lembra");

            List<Usuario> users = new List<Usuario>() { user1, user2, user3, user4, user5 };

            var optionsBuilder = new DbContextOptionsBuilder<SwitchContext>();
            optionsBuilder.UseLazyLoadingProxies();
            var conn = "Server = localhost; userid = root; password = lembrei1; database = SwitchDB";
            optionsBuilder.UseMySql(conn, ServerVersion.AutoDetect(conn), m => m.MigrationsAssembly("Switch.Infra.Data"));

            try
            {
                using (var dbcontext = new SwitchContext(optionsBuilder.Options))
                {
                    dbcontext.GetService<ILoggerFactory>().AddProvider(new Logger());

                    /////  PEGAR DA BASE
                    var resultado = dbcontext.usuarios.ToList();
                    //var resultado = dbcontext.usuarios.Where(u => u.Nome.Equals("enzo")).ToList();

                    /////   ADICIONAR VARIOS
                    //dbcontext.usuarios.AddRange(users);
                    //dbcontext.SaveChanges();

                    /////   ADICIONAR UM
                    //dbcontext.usuarios.Add(usuario);
                    //dbcontext.SaveChanges();


                    foreach (Usuario user in resultado){
                        Console.WriteLine(user.Id.ToString()+ " "+ user.DataNascimento);
                    }
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
