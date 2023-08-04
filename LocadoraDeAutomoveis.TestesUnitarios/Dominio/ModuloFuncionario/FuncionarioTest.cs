using LocadoraDeAutomoveis.Dominio.ModuloFuncionario;

namespace LocadoraDeAutomoveis.TestesUnitarios.Dominio.ModuloFuncionario
{
    [TestClass]
    internal class FuncionarioTest
    {
        private Funcionario Funcionario { get; set; }

        public FuncionarioTest()
        {
            Funcionario = new Funcionario();
        }
    }
}
