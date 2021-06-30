using MegaLanches.Models;

namespace MegaLanches.Repositories
{
    public interface IPedidoRepository
    {
        void CriarPedido(Pedido pedido);
    }
}