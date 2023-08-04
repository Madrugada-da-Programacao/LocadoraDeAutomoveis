namespace LocadoraDeAutomoveis.Dominio.ModuloFuncionario
{
    public class Funcionario : EntidadeBase<Funcionario>
    {

        public string Nome { get; set; }
        public DateTime DataAdmissao { get; set; }
        public int Salario { get; set; }

        public Funcionario(string nome, DateTime dataAdmissao, int salario)
        {
            Nome = nome;
            DataAdmissao = dataAdmissao;
            Salario = salario;
        }

        public Funcionario(Guid id, string nome, DateTime dataAdmissao, int salario)
        {
            Id = id;
            Nome = nome;
            DataAdmissao = dataAdmissao;
            Salario = salario;
        }

        public override void Atualizar(Funcionario registro)
        {
            throw new NotImplementedException();
        }
    }
}
