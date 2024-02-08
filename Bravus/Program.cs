using System;
using System.Globalization;
using Bravus.Entities.Enums;
using Bravus.Entities;

internal class Program
{
    CultureInfo CI = CultureInfo.InvariantCulture;
    static void EfeitoDigitando(string text)
    {
        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(25);
        }
    }

    private static void Main(string[] args)
    {
        void Cabecalho()
        {
            Console.WriteLine(@"
████████╗░█████╗░███╗░░░███╗░█████╗░  ██████╗░░█████╗░██████╗░██████╗░██╗░██████╗░░█████╗░  ░█████╗░░░███╗░░
╚══██╔══╝██╔══██╗████╗░████║██╔══██╗  ██╔══██╗██╔══██╗██╔══██╗██╔══██╗██║██╔════╝░██╔══██╗  ██╔══██╗░████║░░
░░░██║░░░██║░░██║██╔████╔██║███████║  ██████╔╝██║░░██║██║░░██║██████╔╝██║██║░░██╗░██║░░██║  ██║░░██║██╔██║░░
░░░██║░░░██║░░██║██║╚██╔╝██║██╔══██║  ██╔══██╗██║░░██║██║░░██║██╔══██╗██║██║░░╚██╗██║░░██║  ██║░░██║╚═╝██║░░
░░░██║░░░╚█████╔╝██║░╚═╝░██║██║░░██║  ██║░░██║╚█████╔╝██████╔╝██║░░██║██║╚██████╔╝╚█████╔╝  ╚█████╔╝███████╗
░░░╚═╝░░░░╚════╝░╚═╝░░░░░╚═╝╚═╝░░╚═╝  ╚═╝░░╚═╝░╚════╝░╚═════╝░╚═╝░░╚═╝╚═╝░╚═════╝░░╚════╝░  ░╚════╝░╚══════╝");

        }

        Cabecalho();
        EfeitoDigitando("Bem vindo a BRAVUS, vamos inicialmente realizar seu cadastro:\n");
        Console.WriteLine("Qual o seu nome?");
        string nome = Console.ReadLine()!;
        Console.WriteLine("Qual é seu e-mail?");
        string email = Console.ReadLine()!;
        Console.WriteLine("Qual sua data de Nascimento");
        DateTime Aniversario = DateTime.Parse(Console.ReadLine()!);
        Cliente Cliente = new Cliente(nome, email, Aniversario);
        EfeitoDigitando("Ótimo, Agora vamos criar sua carteira Digital.\n");
        Console.WriteLine("...............................................\n");
        Conta ContaBravus = new ContaPremium(1001, Cliente, 0.0, 25.0);
        Console.WriteLine("Quanto quer adicionar em sua carteira?");
        double dep = double.Parse(Console.ReadLine()!);


        ContaBravus.AdicionarSaldo(dep);
        Console.WriteLine($"Saldo adicionado: {ContaBravus.Saldo.ToString("F2")}");
        EfeitoDigitando("\nVou mostrar nossa lista de produtos:\n");
        Thread.Sleep(300);
        Console.WriteLine();
        Produto Catalogo = new();
        foreach (string var in Catalogo.Catalogo)
        {
            Console.WriteLine(var);
        }

        Console.WriteLine("\n Quantas medidas você pretende comprar?");
        int n = int.Parse(Console.ReadLine()!);
        Console.WriteLine("\nDigite conforme no exemplo: 205 70 R15 (com espaços)");
        Pedido pedido1 = new Pedido();
        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine($"Escolha a {i}º medida");
            string escolha1 = Console.ReadLine()!;
            Console.WriteLine("Quantos irá levar?");
            int qnt = int.Parse(Console.ReadLine()!);
            string medida = escolha1.Substring(0, 6);
            AroPneu aro = Enum.Parse<AroPneu>(escolha1.Substring(7, 5));
            Produto produto = new Produto(medida, aro, 169, qnt);

            pedido1.AdicionarItem(produto);

        }
        Console.WriteLine("Aguarde enquanto processamos seu pedido...");
        Console.WriteLine($"Data da compra: {pedido1.DataCompra}");
        double saldoanterior = ContaBravus.Saldo;
        if (ContaBravus.Saldo < pedido1.CalcularValorTotal())
        {
            Console.WriteLine("Seu saldo em carteira é insuficiente");
            Console.WriteLine("Até mais.");
        }
        else
        {
            ContaBravus.Saldo -= pedido1.CalcularValorTotal();
            Console.WriteLine($"Saldo anterior: {saldoanterior}");
            Console.WriteLine(ContaBravus.Saldo);
            Console.WriteLine("Vamos confirmar seus dados.");
            Console.WriteLine(ContaBravus.Cliente);
            Console.WriteLine("Está tudo certo?");
            char confirmacao = char.Parse(Console.ReadLine()!);
            if (confirmacao == 's')
            {
                Console.WriteLine("Seu pedido foi finalizado, logo poderá vir buscar conosco.");
            }
            else
            {
                Console.WriteLine("Que pena, não vou mudar não");
            }
            Console.WriteLine("Antes de ir embora, irei lhe dar um bônus para a proxima compra");
            ContaPremium contaPremium = (ContaPremium)ContaBravus;
            contaPremium.AdicionarSaldo(0.0);
            Console.WriteLine(contaPremium.Saldo);

        }


    }
}
