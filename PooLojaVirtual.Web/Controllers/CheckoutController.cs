using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PooLojaVirtual.Data;
using PooLojaVirtual.Models;

namespace PooLojaVirtual.Web.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly IRepositorio<Carrinho> _repositorio;

        public CheckoutController(IRepositorio<Carrinho> repositorio)
        {
            _repositorio = repositorio;
        }

        public IActionResult Index()
        {
            var carrinho = _repositorio.GetAll().FirstOrDefault();
            if (carrinho == null)
            {
                carrinho = new Carrinho();
            }
            return View(carrinho);
        }
    }
}