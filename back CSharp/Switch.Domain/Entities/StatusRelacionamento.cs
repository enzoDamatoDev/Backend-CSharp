using Switch.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Switch.Domain.Entities
{
    public class StatusRelacionamento
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool NaoEspecificado { get { return Id == (int)StatusRelacionametnoEnum.NaoEspecificado; } }
        public bool Solteiro { get { return Id == (int)StatusRelacionametnoEnum.Solteiro; } }
        public bool Casado { get { return Id == (int)StatusRelacionametnoEnum.Casado; } }
        public bool EmRelacionamentoSerio { get { return Id == (int)StatusRelacionametnoEnum.EmRelacionamentoSerio; } }

    }
}
