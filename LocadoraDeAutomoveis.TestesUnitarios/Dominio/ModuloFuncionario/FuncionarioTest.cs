using LocadoraDeAutomoveis.Dominio.ModuloFuncionario;

namespace LocadoraDeAutomoveis.TestesUnitarios.Dominio.ModuloFuncionario
{
    [TestClass]
    public class FuncionarioTest
    {
        private Funcionario Funcionario { get; set; }

        public FuncionarioTest()
        {
            Funcionario = new Funcionario();
        }
    }
}
