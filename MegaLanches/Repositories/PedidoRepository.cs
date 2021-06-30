using System;
using MegaLanches.Data;
using MegaLanches.Models;

namespace MegaLanches.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly MegaLanchesContext _context;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoRepository(MegaLanchesContext context, CarrinhoCompra carrinhoCompra)
        {
            // injeção do contexto
            _context = context;
            _carrinhoCompra = carrinhoCompra;
        }

        public void CriarPedido(Pedido pedido)
        {
            // definindo a persistencia dos itens do carrinho nos itens de pedido

            pedido.PedidoEnviado = DateTime.Now; // define o horário que o pedido foi criado
            
            _context.Pedidos.Add(pedido); // adiciona o pedido no context
            _context.SaveChanges(); // salva o banco para nao ter problemas de chave depois

            var carrinhoCompraItens = _context.CarrinhoCompraItens; // obtém os itens do carrinho

            foreach (var carrinhoItem in carrinhoCompraItens) // loop nos itens do carrinho
            {
                var pedidoDetalhe = new PedidoDetalhe() { 
                    Quantidade = carrinhoItem.Quantidade,
                    LancheId = carrinhoItem.Lanche.LancheId,
                    PedidoId = pedido.PedidoId,
                    Preco = carrinhoItem.Lanche.Preco
                };

                _context.PedidoDetalhes.Add(pedidoDetalhe);
            }

            _context.SaveChanges();
        }
    }
}