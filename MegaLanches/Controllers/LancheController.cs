using System;
using System.Collections.Generic;
using System.Linq;
using MegaLanches.Models;
using MegaLanches.Repositories;
using MegaLanches.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MegaLanches.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILancheRepository _lancheRepository;
        private ICategoriaRepository _categoriaRepository;

        public LancheController(ILancheRepository lancheRepository, ICategoriaRepository categoriaRepository)
        {
            _lancheRepository = lancheRepository;
            _categoriaRepository = categoriaRepository;
        }

        public IActionResult List(string categoria)
        {
            string _categoria = categoria;
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _lancheRepository.Lanches.OrderBy(l => l.LancheId);
                categoria = "Todos os lanches";
            }
            else
            {
                if (string.Equals("Normal", _categoria, StringComparison.OrdinalIgnoreCase))
                {
                    lanches = _lancheRepository.Lanches
                    .Where(l => l.Categoria.CategoriaNome.Equals("Normal"))
                    .OrderBy(l => l.Nome);
                }
                else
                {
                    lanches = _lancheRepository.Lanches
                    .Where(l => l.Categoria.CategoriaNome.Equals("Natural"))
                    .OrderBy(l => l.Nome);
                }

                categoriaAtual = _categoria;
            }

            var lanchesListViewModel = new LancheListViewModel 
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            };

            return View(lanchesListViewModel);
        }

        public IActionResult Details(int lancheId)
        {
            var lanche = _lancheRepository.Lanches.FirstOrDefault(l => l.LancheId == lancheId);
            if (lanche == null)
            {
                return View("~/Views/Error/Error.cshtml");
            }

            return View(lanche);
        }
    }
}