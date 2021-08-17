using MegaLanches.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MegaLanches.Data
{
    public class MegaLanchesContext : IdentityDbContext<IdentityUser>
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