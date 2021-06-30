using MegaLanches.Models;
using Microsoft.EntityFrameworkCore;

namespace MegaLanches.Data
{
    public class MegaLanchesContext : DbContext
    {
        public MegaLanchesContext(DbContextOptions<MegaLanchesContext> options) : base(options)
        {
        }

        // Tabelas
        public DbSet<Lanche> Lanches { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoDetalhe> PedidoDetalhes { get; set; }
        
    }
}