using MegaLanches.Models;
using System.Collections.Generic;

namespace MegaLanches.ViewModels
{
    public class LancheListViewModel
    {
        public IEnumerable<Lanche> Lanches { get; set; }
        public string CategoriaAtual { get; set; }
    }
}