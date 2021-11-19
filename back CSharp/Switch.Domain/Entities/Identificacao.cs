using Switch.Domain.Enum;

namespace Switch.Domain.Entities
{
    public class Identificacao
    {
        public int id { get; set; }
        public TipoDocumentoEnum TipoDocumento { get; set; }
        public string Numero { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
