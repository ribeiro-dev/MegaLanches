using System.Collections.Generic;
using MegaLanches.Data;
using MegaLanches.Models;

namespace MegaLanches.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly MegaLanchesContext _context;

        public CategoriaRepository(MegaLanchesContext context)
        {
            _context = context;
        }
        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}