using bravus.Entities;
using Bravus.Entities.Enums;
using System.Collections.Generic;

namespace Bravus.Entities
{
    class Pedido
    {
        public List<Produto> Carrinho { get; set; } = new List<Produto>();
        public DateTime DataCompra { get; set; } = DateTime.Now;

        public Pedido()
        {
            DataCompra = DateTime.Now;
        }
        public Pedido(List<Produto> carrinho)
        {
            Carrinho = carrinho;
            DataCompra = DateTime.Now;
        }
        public void AdicionarItem(Produto produto)
        {
            Carrinho.Add(produto);
        }
        public bool DescontoMix()
        {
            HashSet<AroPneu> arosNoCarrinho = new HashSet<AroPneu>();

            for (int i = 0; i < Carrinho.Count; i++)
            {
                Produto produto = Carrinho[i];

                if (!arosNoCarrinho.Contains(produto.Aro))
                {
                    arosNoCarrinho.Add(produto.Aro);
                }

                if (arosNoCarrinho.Count == 2)
                {
                    return true;
                }
            }
               

            return false;
        }

        public double CalcularValorTotal()
        {
            double valorTotal = 0;
            foreach (Produto produto in Carrinho)
            {
                valorTotal += produto.ValorTotal();
            }

            if (DescontoMix())
            {
                double desconto = valorTotal * 0.05;
                valorTotal -= desconto;
            }
            return valorTotal;
        }

    }

}