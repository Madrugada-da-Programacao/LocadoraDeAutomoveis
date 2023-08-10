namespace LocadoraDeAutomoveis.Dominio.ModuloFuncionario
{
    public class Funcionario : EntidadeBase<Funcionario>
    {

        public string Nome { get; set; }
        public DateTime DataAdmissao { get; set; } = DateTime.Now;
        public decimal Salario { get; set; } = 0.01m;

		public Funcionario(string nome, DateTime dataAdmissao, decimal salario)
        {
            Nome = nome;
            DataAdmissao = dataAdmissao;
            Salario = salario;
        }

        public Funcionario(Guid id, string nome, DateTime dataAdmissao, decimal salario) : this(nome, dataAdmissao, salario)
        {
            Id = id;
        }

        public Funcionario()
        {
        }

        public override void Atualizar(Funcionario registro)
        {
            throw new NotImplementedException();
        }
    }
}
