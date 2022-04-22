using System.ComponentModel.DataAnnotations;

namespace Switch.Api.Models
{
    public class CadastroViewModel
    {
        public int id { get; set; }
        [Required(ErrorMessage ="voce n tem nome?")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "voce n tem email?")]
        [EmailAddress(ErrorMessage ="email estranho hein")]
        public string Email { get; set; }
        [Required]
        public bool Carro { get; set; }
        [Required]
        public bool Acompanhado { get; set; }

    }
   
}
