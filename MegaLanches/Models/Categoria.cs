using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MegaLanches.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        
        [StringLength(100)]
        public string CategoriaNome { get; set; }
        
        [StringLength(100)]
        public string Descricao { get; set; }
        
        public List<Lanche> Lanches { get; set; }
    }
}