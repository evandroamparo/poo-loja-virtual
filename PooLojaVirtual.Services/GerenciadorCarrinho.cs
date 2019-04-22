using System.Linq;
using PooLojaVirtual.Core;
using PooLojaVirtual.Data;
using PooLojaVirtual.Models;

namespace PooLojaVirtual.Services
{
    public class GerenciadorCarrinho : IGerenciadorCarrinho
    {
        private readonly IRepositorio<Carrinho> _repositorio;

        public GerenciadorCarrinho(IRepositorio<Carrinho> repositorio)
        {
            _repositorio = repositorio;
        }

        public void ApagarCarrinho()
        {
            _repositorio.Excluir(RecuperarCarrinho());
        }

        public Carrinho RecuperarCarrinho()
        {
            var carrinho = _repositorio.GetAll().FirstOrDefault();
            if (carrinho == null)
            {
                carrinho = new Carrinho();
            }
            return carrinho;
        }

        public void Salvar(Carrinho carrinho)
        {
            if (carrinho.Id == 0)
            {
                _repositorio.Inserir(carrinho);
            }
            else
            {
                _repositorio.Salvar(carrinho);
            }
        }
    }
}