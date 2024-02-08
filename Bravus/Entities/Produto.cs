using System;
using System.Collections.Generic;
using Bravus.Entities.Enums;

namespace Bravus.Entities
{
    internal class Produto
    {
        public List<string> Catalogo { get; } = new List<string> {
        "Pneu Remolde - 165 70 R13",
        "Pneu Remolde - 175 70 R13",
        "Pneu Remolde - 175 65 R13",
        "Pneu Remolde - 175 70 R14",
        "Pneu Remolde - 185 60 R14",
        "Pneu Remolde - 185 65 R14",
        "Pneu Remolde - 185 70 R14",
        "Pneu Remolde - 195 55 R15",
        "Pneu Remolde - 195 60 R15",
        "Pneu Remolde - 195 65 R15",
        "Pneu Remolde - 205 60 R15",
        "Pneu Remolde - 205 65 R15",
        "Pneu Remolde - 205 70 R15",
        "Pneu Remolde - 205 55 R16",
        "Pneu Remolde - 205 60 R16",
        "Pneu Remolde - 215 65 R16",
        };
        public string Medida { get; set; }
        public AroPneu Aro { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }

        public Produto() { }
        public Produto(string medida, AroPneu aro, double preco, int quantidade)
        {
            Medida = medida;
            Aro = aro;
            Preco = preco;
            Quantidade = quantidade;
        }

        public double ValorTotal()
        {
            return Quantidade * Preco;
        }

        public override string ToString()
        {
          StringBuilder sb = new StringBuilder();
            sb.Append($"Medida: {Medida} ");
            sb.Append(Aro);
            sb.Append($" Preço: {Preco},");
            sb.Append($" {Quantidade} unidades.");
            return sb.ToString();
        }
    }
}

