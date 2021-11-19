using System;
using System.Collections.Generic;
using System.Text;

namespace Switch.Domain.Entities
{
    public class Grupo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string descricao { get; set; }
        public string UrlFoto { get; set; }
        public virtual ICollection<Postagem> postagens {get; set;}
        public virtual ICollection<UsuarioGrupo> UsuarioGrupos { get; set; }

    }
}
