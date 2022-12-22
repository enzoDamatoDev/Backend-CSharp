using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Categoria
    {
        [Key]
        public int idCategoria { get; set; }
        [Required, MaxLength(128)]
        public string nome { get; set; }

    }
}
