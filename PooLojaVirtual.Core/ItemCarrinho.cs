namespace PooLojaVirtual.Models
{
    public class ItemCarrinho
    {
        public ItemCarrinho(Produto produto, int quantidade)
        {
            this.Produto = produto;
            this.Quantidade = quantidade;
        }

        public ItemCarrinho()
        {
            
        }
        public Produto Produto { get; private set; }
        public int Quantidade { get; private set; }

        public double Subtotal
        {
            get
            {
                return Produto.Preco * Quantidade;
            }
        }
    }
}