using LocadoraDeAutomoveis.Dominio.ModuloFuncionario;
using LocadoraDeAutomoveis.Dominio;
using FluentValidation.TestHelper;

namespace LocadoraDeAutomoveis.TestesUnitarios.Dominio.ModuloFuncionario
{
    [TestClass]
    public class ValidadorFuncionarioTest
    {
        private Funcionario Funcionario { get; set; }
        private ValidadorFuncionario Validador { get; set; }

        public ValidadorFuncionarioTest()
        {
            Funcionario = new Funcionario();

            Validador = new ValidadorFuncionario();
        }

        [TestMethod]
        public void Nome_funcionario_nao_deve_ser_nulo_ou_vazio_erro()
        {
            //action
            var resultado = Validador.TestValidate(Funcionario);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nome_funcionario_nao_deve_ser_nulo_ou_vazio_ok()
        {
            //arrange
            Funcionario.Nome = "abc";

            //action
            var resultado = Validador.TestValidate(Funcionario);

            //assert
            resultado.ShouldNotHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nome_funcionario_deve_ter_no_minimo_3_caracteres_erro()
        {
            //arrange
            Funcionario.Nome = "ab";

            //action
            var resultado = Validador.TestValidate(Funcionario);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nome_funcionario_deve_ter_no_minimo_3_caracteres_ok()
        {
            //arrange
            Funcionario.Nome = "abcd";

            //action
            var resultado = Validador.TestValidate(Funcionario);

            //assert
            resultado.ShouldNotHaveValidationErrorFor(x => x.Nome);
        }
        [TestMethod]
        public void DataAdmissao_funcionario_nao_deve_ser_nulo_ou_vazio_erro()
        {
            //action
            var resultado = Validador.TestValidate(Funcionario);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.DataAdmissao);
        }

        [TestMethod]
        public void DataAdmissao_funcionario_nao_deve_ser_nulo_ou_vazio_ok()
        {
            //arrange
            Funcionario.DataAdmissao = Convert.ToDateTime("10/02/2022");

            //action
            var resultado = Validador.TestValidate(Funcionario);

            //assert
            resultado.ShouldNotHaveValidationErrorFor(x => x.DataAdmissao);
        }

        [TestMethod]
        public void Salario_funcionario_nao_deve_ser_nulo_ou_vazio_erro()
        {
            //action
            var resultado = Validador.TestValidate(Funcionario);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Salario);
        }

        [TestMethod]
        public void Salario_funcionario_nao_deve_ser_nulo_ou_vazio_ok()
        {
            //arrange
            Funcionario.Salario = 1;

            //action
            var resultado = Validador.TestValidate(Funcionario);

            //assert
            resultado.ShouldNotHaveValidationErrorFor(x => x.Salario);
        }
    }
}
