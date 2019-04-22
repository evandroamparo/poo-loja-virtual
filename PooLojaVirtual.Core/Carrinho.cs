using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PooLojaVirtual.Models
{
    public class Carrinho : Entidade
    {
        public List<ItemCarrinho> Itens { get; set; } = new List<ItemCarrinho>();
        // {
        //     get {
        //         return _itens.AsReadOnly();
        //     }
        // }

        public double Total { get; private set; }

        public void Adicionar(Produto produto, int quantidade)
        {
            Itens.Add(new ItemCarrinho(produto, quantidade));
            Total += produto.Preco * quantidade;
        }
    }
}