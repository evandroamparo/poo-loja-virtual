using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PooLojaVirtual.Models
{
    public class Carrinho
    {
        private List<ItemCarrinho> _itens = new List<ItemCarrinho>();
        public ReadOnlyCollection<ItemCarrinho> Itens 
        {
            get {
                return _itens.AsReadOnly();
            }
        }

        public void Adicionar(ItemCarrinho item)
        {
            _itens.Add(item);
        }
    }
}