using System;
using System.Text;
namespace Bravus.Entities
{
    internal class Cliente
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime Aniversario { get; set; }

        public Cliente(string nome, string email, DateTime aniversario )
        {
            Nome = nome;
            Email = email;
            Aniversario = aniversario;
        }
        public override string ToString()
        {
            StringBuilder c1 = new StringBuilder();
            c1.AppendLine($"Cliente: {Nome}");
            c1.AppendLine($"E-mail: {Email}");
            c1.AppendLine($"Data do Aniversário: {Aniversario}");
            return c1.ToString();
        }
        
    }

}
