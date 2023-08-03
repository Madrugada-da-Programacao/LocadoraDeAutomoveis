namespace LocadoraDeAutomoveis.Dominio.ModuloFuncionario
{
    public class Funcionario : EntidadeBase<Funcionario>
    {
        public string Nome { get; set; }
        public DateTime DataAdmissao { get; set; }
        public int Salario { get; set; }
        public override void Atualizar(Funcionario registro)
        {
            throw new NotImplementedException();
        }
    }
}
