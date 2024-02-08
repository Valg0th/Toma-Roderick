using System;

namespace Bravus.Entities
{
    internal class ContaPremium : Conta
    {
        public double Brinde { get; set; }
        public ContaPremium() { }
        public ContaPremium(int id, Cliente cliente, double saldo, double brinde) : base(id, cliente, saldo)
        {
         Brinde = brinde;
        }
        public override void AdicionarSaldo(double deposito)
        {
            base.AdicionarSaldo(deposito);
            Saldo += Brinde;
        }
    }
}
