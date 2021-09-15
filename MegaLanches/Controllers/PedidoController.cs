using System;
using System.Collections.Generic;
using System.Linq;
using MegaLanches.Models;
using MegaLanches.Repositories;
using MegaLanches.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MegaLanches.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoController(IPedidoRepository pedidoRepository, CarrinhoCompra carrinhoCompra)
        {
            _pedidoRepository = pedidoRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        [Authorize]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Checkout(Pedido pedido)
        {
            decimal precoTotalPedido = 0.0m;
            int totalItensPedido = 0;

            var items = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItens = items;


            // verifica se existem itens de pedido
            if (_carrinhoCompra.CarrinhoCompraItens.Count == 0)
            {
                ModelState.AddModelError("", "Seu carrinho está vazio, inclua um lanche");
            }

            // calcula o total do pedido
            foreach (var item in items)
            {
                totalItensPedido += item.Quantidade;
                precoTotalPedido += (item.Lanche.Preco * item.Quantidade);
            }

            // atribui o total de itens ao pedido
            pedido.TotalItensPedido = totalItensPedido;
            
            // atribui o valor total do pedido
            pedido.PedidoTotal = precoTotalPedido;

            if (ModelState.IsValid)
            {
                _pedidoRepository.CriarPedido(pedido);

                // persiste as informações do pedido pra utilizar na action CheckoutCompleto
                ViewBag.CheckoutCompletoMensagem = "Obrigado pelo seu pedido!";
                ViewBag.TotalPedido = _carrinhoCompra.GetCarrinhoCompraTotal();
                
                _carrinhoCompra.LimparCarrinho(); // limpa o carrinho após o pedido ser realizado
                return View("~/Views/Pedido/CheckoutCompleto.cshtml", pedido);
            }

            return View(pedido);
        }

        public IActionResult CheckoutCompleto()
        {
            ViewBag.Cliente = TempData["Cliente"];
            ViewBag.DataPedido = TempData["DataPedido"];
            ViewBag.NumeroPedido = TempData["NumeroPedido"];
            ViewBag.TotalPedido = TempData["TotalPedido"];
            ViewBag.CheckoutCompletoMensagem = "Obrigado pelo seu pedido!";
            return View();
        }
    }
}