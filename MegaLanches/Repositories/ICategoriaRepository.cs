using System.Collections.Generic;
using MegaLanches.Models;

namespace MegaLanches.Repositories
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> Categorias { get; }
    }
}