using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeAutomoveis.Dominio.ModuloCondutor
{
    public class Condutor : EntidadeBase<Condutor>
    {

        public Cliente Cliente { get; set; }
        public bool ClienteEhCondutor { get; set; }
        public string Nome { get; set; } = "";
        public string Email { get; set; } = "";
        public string Telefone { get; set; } = "";
        public string Cpf { get; set; } = "";
        public string Cnh { get; set; } = "";
        public DateTime Validade { get; set; }

        public Condutor()
        {
        }
        public Condutor(Cliente cliente, bool clienteEhCondutor, string nome, string email, string telefone, string cpf, string cnh, DateTime validade)
        {
            Cliente = cliente;
            ClienteEhCondutor = clienteEhCondutor;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Cpf = cpf;
            Cnh = cnh;
            Validade = validade;
        }
        public Condutor(Guid id, Cliente cliente, bool clienteEhCondutor, string nome, string email, string telefone, string cpf, string cnh, DateTime validade) : this(
            cliente, clienteEhCondutor, nome, email, telefone, cpf, cnh, validade)
        {
            Id = id;
        }


    }
}
