using System;
using System.Collections.Generic;
using System.Linq;
using MegaLanches.Models;
using MegaLanches.Repositories;
using MegaLanches.ViewModels;
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

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Pedido pedido)
        {
            var items = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItens = items;

            if (_carrinhoCompra.CarrinhoCompraItens.Count == 0)
            {
                ModelState.AddModelError("", "Seu carrinho está vazio, inclua um lanche");
            }

            if (ModelState.IsValid)
            {
                _pedidoRepository.CriarPedido(pedido);
                _carrinhoCompra.LimparCarrinho(); // limpa o carrinho após o pedido ser realizado
                return RedirectToAction("CheckoutCompleto");
            }

            return View(pedido);
        }

        public IActionResult CheckoutCompleto()
        {
            ViewBag.CheckoutCompletoMensagem = "Obrigado pelo seu pedido!";
            return View();
        }
    }
}