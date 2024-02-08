namespace Bravus.Entities
{
    internal class Conta
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public double Saldo { get; set; }

        public Conta() { }

        public Conta(int id, Cliente cliente, double saldo)
        {
            Id = id;
            Cliente = cliente;
            Saldo = saldo;
        }
        public virtual void AdicionarSaldo(double deposito)
        {
            Saldo += deposito;
        }
        public void RemoverSaldo(double deposito)
        {
                Saldo -= deposito;
        }
    }
}
