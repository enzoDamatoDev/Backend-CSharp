using System.Collections.Generic;

namespace Switch.Api.Models
{
    public static class Repositorio
    {
        private static List<CadastroViewModel> respostas = new List<CadastroViewModel>();
        public static IEnumerable<CadastroViewModel> Respostas { get { return respostas; } }
        public static void AdicionarResposta(CadastroViewModel rep)
        {
            respostas.Add(rep);
        }

    }
}
