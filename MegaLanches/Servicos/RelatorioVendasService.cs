using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaLanches.Data;
using MegaLanches.Models;
using Microsoft.EntityFrameworkCore;

namespace MegaLanches.Servicos
{
    public class RelatorioVendasService
    {
        private readonly MegaLanchesContext _context;

        public RelatorioVendasService(MegaLanchesContext context)
        {
            _context = context;
        }

        public async Task<List<Pedido>> FindDateByAsync(DateTime? minDate, DateTime? maxDate)
        {
            var resultado = from obj in _context.Pedidos select obj;

            if (minDate.HasValue)
            {
                resultado = resultado.Where(x => x.PedidoEnviado >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                resultado = resultado.Where(x => x.PedidoEnviado <= maxDate);
            }

            return await resultado
                        .Include(l => l.PedidoItens) // inclui a lista com outras entidades
                        .ThenInclude(l => l.Lanche)  // inclui o lanche na lista anterior
                        .OrderByDescending(x => x.PedidoEnviado) // ordena por data de envio
                        .ToListAsync();
        }
    }
}