using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PooLojaVirtual.Core;
using PooLojaVirtual.Infraestructure;
using PooLojaVirtual.Models;
using PooLojaVirtual.Web.ViewModels;

namespace PooLojaVirtual.Web.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly IGerenciadorCarrinho _gerenciagorCarrinho;
        private readonly IRepositorio<FormaPagamento> _repositorioFormasPagamento;
        private readonly IRepositorio<Pedido> _repositorioPedidos;
        private readonly IServicoEmail _servicoEmail;

        public CheckoutController(
            IRepositorio<FormaPagamento> repositorioFormasPagamento,
            IRepositorio<Pedido> repositorioPedidos,
            IGerenciadorCarrinho gerenciagorCarrinho,
            IServicoEmail servicoEmail)
        {
            _gerenciagorCarrinho = gerenciagorCarrinho;
            _repositorioFormasPagamento = repositorioFormasPagamento;
            _repositorioPedidos = repositorioPedidos;
            _servicoEmail = servicoEmail;
        }

        public IActionResult Index()
        {
            var carrinho = _gerenciagorCarrinho.RecuperarCarrinho();
            var checkoutVM = new CheckoutViewModel
            {
                NumItens = carrinho.Itens.Count(),
                Total = carrinho.Total,
                FormasPagamento = new SelectList(
                        _repositorioFormasPagamento.GetAll(),
                        "Id",
                        "Nome")
            };
            return View(checkoutVM);
        }

        public IActionResult Confirmar(int idFormaPagamento)
        {
            var carrinho = _gerenciagorCarrinho.RecuperarCarrinho();
            var pedido = new Pedido
            {
                FormaPagamento = _repositorioFormasPagamento.RecuperarPorId(idFormaPagamento),
                Itens = carrinho.Itens,
                Valor = carrinho.Total
            };
            _repositorioPedidos.Inserir(pedido);
            _servicoEmail.EnviarConfirmacao("cliente@gmail.com", pedido);
            _gerenciagorCarrinho.LimparCarrinho();
            return RedirectToAction("Index", "Pedidos");
        }
    }
}