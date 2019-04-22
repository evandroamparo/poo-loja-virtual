using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PooLojaVirtual.Infraestructure;
using PooLojaVirtual.Models;
using PooLojaVirtual.Core;

namespace PooLojaVirtual.Web.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly IRepositorio<Produto> _repositorio;
        private readonly IGerenciadorCarrinho _gerenciagorCarrinho;

        public CarrinhoController(IRepositorio<Produto> repositorio, IGerenciadorCarrinho gerenciagorCarrinho)
        {
            _repositorio = repositorio;
            _gerenciagorCarrinho = gerenciagorCarrinho;
        }

        public IActionResult Index()
        {
            return View(_gerenciagorCarrinho.RecuperarCarrinho());
        }

        public IActionResult Adicionar(int id)
        {
            var produto = _repositorio.RecuperarPorId(id);
            var carrinho = _gerenciagorCarrinho.RecuperarCarrinho();
            carrinho.Adicionar(produto, 1);
            _gerenciagorCarrinho.Salvar(carrinho);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remover(int id)
        {
            var carrinho = _gerenciagorCarrinho.RecuperarCarrinho();
            carrinho.Remover(id);
            _gerenciagorCarrinho.Salvar(carrinho);
            return RedirectToAction(nameof(Index));
        }
    }
}