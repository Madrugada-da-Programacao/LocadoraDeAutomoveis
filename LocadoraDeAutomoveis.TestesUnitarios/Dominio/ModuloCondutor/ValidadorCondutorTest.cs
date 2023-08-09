using FluentValidation.TestHelper;
using LocadoraDeAutomoveis.Dominio.ModuloCondutor;
using LocadoraDeAutomoveis.Dominio.ModuloCondutor;

namespace LocadoraDeAutomoveis.TestesUnitarios.Dominio.ModuloCondutor
{
    [TestClass]
    public class ValidadorCondutorTest
    {
        private Condutor Condutor { get; set; }
        private ValidadorCondutor Validador { get; set; }

        public ValidadorCondutorTest()
        {
            Condutor = new Condutor();

            Validador = new ValidadorCondutor();
        }

        [TestMethod]
        public void Nome_condutor_nao_deve_ser_vazio_erro()
        {
            //arrange
            Condutor.Nome = "   ";

            //action
            var resultado = Validador.TestValidate(Condutor);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nome_condutor_deve_ter_no_minimo_3_caracteres_erro()
        {
            //arrange
            Condutor.Nome = "ab";

            //action
            var resultado = Validador.TestValidate(Condutor);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nome_condutor_deve_ter_no_minimo_3_caracteres_ok()
        {
            //arrange
            Condutor.Nome = "abc";

            //action
            var resultado = Validador.TestValidate(Condutor);

            //assert
            resultado.ShouldNotHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Cpf_deve_ser_valido_erro()
        {
            //arrange
            Condutor.Cpf = "000.000.000-0";

            //action
            var resultado = Validador.TestValidate(Condutor);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Cpf);
        }

        [TestMethod]
        public void Cpf_deve_ser_valido_ok()
        {
            //arrange
            Condutor.Cpf = "000.000.000-00";

            //action
            var resultado = Validador.TestValidate(Condutor);

            //assert
            resultado.ShouldNotHaveValidationErrorFor(x => x.Cpf);
        }

        [TestMethod]
        public void Email_condutor_deve_valido_erro()
        {
            //arrange
            Condutor.Email = "a@a@.com";

            //action
            var resultado = Validador.TestValidate(Condutor);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Email);
        }

        [TestMethod]
        public void Email_condutor_deve_valido_ok()
        {
            //arrange
            Condutor.Email = "a@a.com";

            //action
            var resultado = Validador.TestValidate(Condutor);

            //assert
            resultado.ShouldNotHaveValidationErrorFor(x => x.Email);
        }

        [TestMethod]
        public void Telefone_condutor_deve_valido_erro()
        {
            //arrange
            Condutor.Telefone = "(00) 0 0000-000";

            //action
            var resultado = Validador.TestValidate(Condutor);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Telefone);
        }

        [TestMethod]
        public void Telefone_condutor_deve_valido_ok()
        {
            //arrange
            Condutor.Telefone = "(00) 0 0000-0000";

            //action
            var resultado = Validador.TestValidate(Condutor);

            //assert
            resultado.ShouldNotHaveValidationErrorFor(x => x.Telefone);
        }

        [TestMethod]
        public void Cnh_condutor_nao_deve_ser_nulo_ou_vazio_erro()
        {
            //action
            var resultado = Validador.TestValidate(Condutor);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Cnh);
        }

        [TestMethod]
        public void Cnh_condutor_nao_deve_ser_nulo_ou_vazio_ok()
        {
            //arrange
            Condutor.Cnh = "000000000000";

            //action
            var resultado = Validador.TestValidate(Condutor);

            //assert
            resultado.ShouldNotHaveValidationErrorFor(x => x.Cnh);
        }

        [TestMethod]
        public void Cnh_condutor_deve_ter_no_minimo_12_caracteres_erro()
        {
            //arrange
            Condutor.Cnh = "0";

            //action
            var resultado = Validador.TestValidate(Condutor);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Cnh);
        }

        [TestMethod]
        public void Cnh_condutor_deve_ter_no_minimo_12_caracteres_ok()
        {
            //arrange
            Condutor.Cnh = "000000000000";

            //action
            var resultado = Validador.TestValidate(Condutor);

            //assert
            resultado.ShouldNotHaveValidationErrorFor(x => x.Cnh);
        }

        [TestMethod]
        public void Validade_condutor_nao_deve_ser_nulo_ou_vazio_erro()
        {
            //action
            var resultado = Validador.TestValidate(Condutor);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Validade);
        }

        [TestMethod]
        public void Validade_condutor_nao_deve_ser_nulo_ou_vazio_ok()
        {
            //arrange
            DateTime dataAtual = DateTime.Now;
            DateTime dataNoFuturo = dataAtual.AddDays(1);

            Condutor.Validade = dataNoFuturo;

            //action
            var resultado = Validador.TestValidate(Condutor);

            //assert
            resultado.ShouldNotHaveValidationErrorFor(x => x.Validade);
        }

        [TestMethod]
        public void Validade_condutor_nao_deve_ser_no_passado_erro()
        {
            //arrange
            DateTime dataAtual = DateTime.Now;
            DateTime dataNoPassado = dataAtual.AddDays(-1);

            Condutor.Validade = dataNoPassado;

            //action
            var resultado = Validador.TestValidate(Condutor);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Validade);
        }

        [TestMethod]
        public void Validade_condutor_nao_deve_ser_no_passado_ok()
        {
            //arrange
            DateTime dataAtual = DateTime.Now;
            DateTime dataNoFuturo = dataAtual.AddDays(1);

            Condutor.Validade = dataNoFuturo;

            //action
            var resultado = Validador.TestValidate(Condutor);

            //assert
            resultado.ShouldNotHaveValidationErrorFor(x => x.Validade);
        }
    }
}
