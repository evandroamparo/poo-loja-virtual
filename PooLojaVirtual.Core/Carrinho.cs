using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PooLojaVirtual.Models
{
    public class Carrinho : Entidade
    {
        public List<ItemCarrinho> Itens { get; set; } = new List<ItemCarrinho>();

        public double Total { get; private set; }

        public void Adicionar(Produto produto, int quantidade)
        {
            var itemNoCarrinho = Itens.FirstOrDefault(item => item.Produto.Id == produto.Id);

            if (itemNoCarrinho == null)
            {
                Itens.Add(new ItemCarrinho(produto, quantidade));
                Total += produto.Preco * quantidade;
            }
            else
            {
                Total = Total - itemNoCarrinho.Quantidade + quantidade;
                itemNoCarrinho.Quantidade += quantidade;
            }
        }
    }
}