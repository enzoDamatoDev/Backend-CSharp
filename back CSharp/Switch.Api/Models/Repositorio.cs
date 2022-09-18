using System.Collections.Generic;
using System.Linq;

namespace Switch.Api.Models
{
    public static class Repositorio
    {
        private static List<CadastroViewModel> respostas = new List<CadastroViewModel>();
        public static IEnumerable<CadastroViewModel> Respostas { get { return respostas; } }
        public static int tam = 1;
        public static IQueryable<CadastroViewModel> listagem {get{return respostas.AsQueryable();}}
        public static void AdicionarResposta(CadastroViewModel rep)
        {
            CadastroViewModel user = respostas.Find(u => u.id == rep.id);
            if (user != null)
            {
                user.Carro = rep.Carro;
                user.Nome = rep.Nome;
                user.Email = rep.Email;
                user.Acompanhado = rep.Acompanhado;
            }
            else
            {
                rep.id = tam++;
                respostas.Add(rep);
            }
        }

        static Repositorio()
        {
            Repositorio.respostas.Add(new CadastroViewModel {id= tam++,Nome="enzo", Email="enzo@damato",Carro=false,Acompanhado=false });
            Repositorio.respostas.Add(new CadastroViewModel { id = tam++, Nome ="godoy", Email="godoy@gui",Carro=true,Acompanhado=true });
            Repositorio.respostas.Add(new CadastroViewModel { id = tam++, Nome ="thaty", Email="thaty@godoy",Carro=false,Acompanhado=true });
            Repositorio.respostas.Add(new CadastroViewModel { id = tam++, Nome ="kinha", Email="kinha@godoy",Carro=true,Acompanhado=false });
        }

        public static bool remover(int item)
        {
            var user = respostas.Find(u => u.id == item);
            if(user != null)
            {
                return respostas.Remove(user);
            }
            return false;
        }
    }
}
