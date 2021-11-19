using System;
using System.Collections.Generic;
using System.Text;

namespace Switch.Domain.Entities
{
    public class InstituicaoEnsino
    {
        public int Id { get; set; }
        public int UsuarioId { get; set;}
        public virtual Usuario Usuario { get; set; }
        public string nome { get; set; }
        public DateTime? DataFormacao { get; set; }
    }
}
