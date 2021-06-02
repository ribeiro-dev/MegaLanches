using System.Collections.Generic;
using MegaLanches.Models;
using MegaLanches.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MegaLanches.Repositories
{
    public class LancheRepository : ILancheRepository
    {
        private readonly MegaLanchesContext _context;

        public LancheRepository(MegaLanchesContext context)
        {
            _context = context;
        }
        public IEnumerable<Lanche> Lanches => _context.Lanches.Include(c => c.Categoria);

        public IEnumerable<Lanche> LanchesPreferidos => _context.Lanches
            .Where(p => p.IsPreferido == true)
            .Include(c => c.Categoria);

        public Lanche GetLancheById(int lancheId)
        {
            return _context.Lanches.FirstOrDefault(l => l.LancheId == lancheId);
            // nao pode usar .Where, porque o retorno nao é um objeto
        }
    }
}