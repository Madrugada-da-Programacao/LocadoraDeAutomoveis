using FluentValidation.TestHelper;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;

namespace LocadoraDeAutomoveis.TestesUnitarios.Dominio.ModuloCliente
{
    [TestClass]
    public class ValidadorClienteTest
    {
        private Cliente Cliente { get; set; }
        private ValidadorCliente Validador { get; set; }

		public ValidadorClienteTest()
        {
			Cliente = new Cliente();

			Validador = new ValidadorCliente();
        }

        [TestMethod]
        public void Nome_cliente_nao_deve_ser_nulo_erro()
        {
            //action
            var resultado = Validador.TestValidate(Cliente);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

		[TestMethod]
		public void Nome_cliente_nao_deve_ser_vazio_erro()
		{
			//arrange
			Cliente.Nome = "   ";

			//action
			var resultado = Validador.TestValidate(Cliente);

			//assert
			resultado.ShouldHaveValidationErrorFor(x => x.Nome);
		}

		[TestMethod]
        public void Nome_cliente_deve_ter_no_minimo_3_caracteres_erro()
        {
            //arrange
            Cliente.Nome = "ab";

            //action
            var resultado = Validador.TestValidate(Cliente);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

		[TestMethod]
		public void Nome_cliente_deve_ter_no_minimo_3_caracteres_ok()
		{
			//arrange
			Cliente.Nome = "abcd";

			//action
			var resultado = Validador.TestValidate(Cliente);

			//assert
			resultado.ShouldNotHaveValidationErrorFor(x => x.Nome);
		}

		[TestMethod]
		public void Tipo_do_cliente_deve_ser_tipo_valido()
		{
			//arrange
			Cliente.TipoCliente = Cliente.TipoDeCliente.PessoaFisica;

			//action
			var resultado = Validador.TestValidate(Cliente);

			//assert
			resultado.ShouldNotHaveValidationErrorFor(x => x.TipoCliente);
		}

		[TestMethod]
		public void Numero_do_documento_cliente_quando_for_pessoa_fisica_teve_seguir_formato_cpf_erro()
		{
			//arrange
			Cliente.TipoCliente = Cliente.TipoDeCliente.PessoaFisica;
			Cliente.NumeroDoDocumento = "000.000.000-0";

			//action
			var resultado = Validador.TestValidate(Cliente);

			//assert
			resultado.ShouldHaveValidationErrorFor(x => x.NumeroDoDocumento);
		}

		[TestMethod]
		public void Numero_do_documento_cliente_quando_for_pessoa_fisica_teve_seguir_formato_cpf_ok()
		{
			//arrange
			Cliente.TipoCliente = Cliente.TipoDeCliente.PessoaFisica;
			Cliente.NumeroDoDocumento = "000.000.000-00";

			//action
			var resultado = Validador.TestValidate(Cliente);

			//assert
			resultado.ShouldNotHaveValidationErrorFor(x => x.NumeroDoDocumento);
		}

		[TestMethod]
		public void Numero_do_documento_cliente_quando_for_pessoa_juridica_teve_seguir_formato_cnpj_erro()
		{
			//arrange
			Cliente.TipoCliente = Cliente.TipoDeCliente.PessoaJuridica;
			Cliente.NumeroDoDocumento = "00.000.000/0000-0";

			//action
			var resultado = Validador.TestValidate(Cliente);

			//assert
			resultado.ShouldHaveValidationErrorFor(x => x.NumeroDoDocumento);
		}

		[TestMethod]
		public void Numero_do_documento_cliente_quando_for_pessoa_juridica_teve_seguir_formato_cnpj_ok()
		{
			//arrange
			Cliente.TipoCliente = Cliente.TipoDeCliente.PessoaJuridica;
			Cliente.NumeroDoDocumento = "00.000.000/0000-00";

			//action
			var resultado = Validador.TestValidate(Cliente);

			//assert
			resultado.ShouldNotHaveValidationErrorFor(x => x.NumeroDoDocumento);
		}

		[TestMethod]
		public void Email_cliente_deve_valido_erro()
		{
			//arrange
			Cliente.Email = "a@a@.com";

			//action
			var resultado = Validador.TestValidate(Cliente);

			//assert
			resultado.ShouldHaveValidationErrorFor(x => x.Email);
		}

		[TestMethod]
		public void Email_cliente_deve_valido_ok()
		{
			//arrange
			Cliente.Email = "a@a.com";

			//action
			var resultado = Validador.TestValidate(Cliente);

			//assert
			resultado.ShouldNotHaveValidationErrorFor(x => x.Email);
		}

		[TestMethod]
		public void Telefone_cliente_deve_valido_erro()
		{
			//arrange
			Cliente.Telefone = "(00) 0 0000-000";

			//action
			var resultado = Validador.TestValidate(Cliente);

			//assert
			resultado.ShouldHaveValidationErrorFor(x => x.Telefone);
		}

		[TestMethod]
		public void Telefone_cliente_deve_valido_ok()
		{
			//arrange
			Cliente.Telefone = "(00) 0 0000-0000";

			//action
			var resultado = Validador.TestValidate(Cliente);

			//assert
			resultado.ShouldNotHaveValidationErrorFor(x => x.Telefone);
		}

		[TestMethod]
		public void Estado_cliente_nao_deve_ser_nulo_ou_vazio_erro()
		{
			//action
			var resultado = Validador.TestValidate(Cliente);

			//assert
			resultado.ShouldHaveValidationErrorFor(x => x.Estado);
		}

		[TestMethod]
		public void Estado_cliente_nao_deve_ser_nulo_ou_vazio_ok()
		{
			//arrange
			Cliente.Estado = "SC";

			//action
			var resultado = Validador.TestValidate(Cliente);

			//assert
			resultado.ShouldNotHaveValidationErrorFor(x => x.Estado);
		}

		[TestMethod]
		public void Estado_cliente_deve_ter_no_minimo_2_caracteres_erro()
		{
			//arrange
			Cliente.Estado = "S";

			//action
			var resultado = Validador.TestValidate(Cliente);

			//assert
			resultado.ShouldHaveValidationErrorFor(x => x.Estado);
		}

		[TestMethod]
		public void Estado_cliente_deve_ter_no_minimo_2_caracteres_ok()
		{
			//arrange
			Cliente.Estado = "SC";

			//action
			var resultado = Validador.TestValidate(Cliente);

			//assert
			resultado.ShouldNotHaveValidationErrorFor(x => x.Estado);
		}

		[TestMethod]
		public void Cidade_cliente_nao_deve_ser_nulo_ou_vazio_erro()
		{
			//action
			var resultado = Validador.TestValidate(Cliente);

			//assert
			resultado.ShouldHaveValidationErrorFor(x => x.Cidade);
		}

		[TestMethod]
		public void Cidade_cliente_nao_deve_ser_nulo_ou_vazio_ok()
		{
			//arrange
			Cliente.Cidade = "Lages";

			//action
			var resultado = Validador.TestValidate(Cliente);

			//assert
			resultado.ShouldNotHaveValidationErrorFor(x => x.Cidade);
		}

		[TestMethod]
		public void Cidade_cliente_deve_ter_no_minimo_2_caracteres_erro()
		{
			//arrange
			Cliente.Cidade = "L";

			//action
			var resultado = Validador.TestValidate(Cliente);

			//assert
			resultado.ShouldHaveValidationErrorFor(x => x.Cidade);
		}

		[TestMethod]
		public void Cidade_cliente_deve_ter_no_minimo_2_caracteres_ok()
		{
			//arrange
			Cliente.Cidade = "Lages";

			//action
			var resultado = Validador.TestValidate(Cliente);

			//assert
			resultado.ShouldNotHaveValidationErrorFor(x => x.Cidade);
		}

		[TestMethod]
		public void Bairro_cliente_nao_deve_ser_nulo_ou_vazio_erro()
		{
			//action
			var resultado = Validador.TestValidate(Cliente);

			//assert
			resultado.ShouldHaveValidationErrorFor(x => x.Bairro);
		}

		[TestMethod]
		public void Bairro_cliente_nao_deve_ser_nulo_ou_vazio_ok()
		{
			//arrange
			Cliente.Bairro = "Centro";

			//action
			var resultado = Validador.TestValidate(Cliente);

			//assert
			resultado.ShouldNotHaveValidationErrorFor(x => x.Bairro);
		}

		[TestMethod]
		public void Bairro_cliente_deve_ter_no_minimo_2_caracteres_erro()
		{
			//arrange
			Cliente.Bairro = "C";

			//action
			var resultado = Validador.TestValidate(Cliente);

			//assert
			resultado.ShouldHaveValidationErrorFor(x => x.Bairro);
		}

		[TestMethod]
		public void Bairro_cliente_deve_ter_no_minimo_2_caracteres_ok()
		{
			//arrange
			Cliente.Bairro = "Centro";

			//action
			var resultado = Validador.TestValidate(Cliente);

			//assert
			resultado.ShouldNotHaveValidationErrorFor(x => x.Bairro);
		}

		[TestMethod]
		public void Rua_cliente_nao_deve_ser_nulo_ou_vazio_erro()
		{
			//action
			var resultado = Validador.TestValidate(Cliente);

			//assert
			resultado.ShouldHaveValidationErrorFor(x => x.Rua);
		}

		[TestMethod]
		public void Rua_cliente_nao_deve_ser_nulo_ou_vazio_ok()
		{
			//arrange
			Cliente.Rua = "Frei Gabriel";

			//action
			var resultado = Validador.TestValidate(Cliente);

			//assert
			resultado.ShouldNotHaveValidationErrorFor(x => x.Rua);
		}

		[TestMethod]
		public void Rua_cliente_deve_ter_no_minimo_2_caracteres_erro()
		{
			//arrange
			Cliente.Rua = "F";

			//action
			var resultado = Validador.TestValidate(Cliente);

			//assert
			resultado.ShouldHaveValidationErrorFor(x => x.Rua);
		}

		[TestMethod]
		public void Rua_cliente_deve_ter_no_minimo_2_caracteres_ok()
		{
			//arrange
			Cliente.Rua = "Frei Gabriel";

			//action
			var resultado = Validador.TestValidate(Cliente);

			//assert
			resultado.ShouldNotHaveValidationErrorFor(x => x.Rua);
		}

		//TODO verificar com o rech se pode tirar este teste já que ele não é vazio por padrão agora
		//[TestMethod]
		//public void Numero_cliente_nao_deve_ser_nulo_ou_vazio_erro()
		//{
		//	//action
		//	var resultado = Validador.TestValidate(Cliente);

		//	//assert
		//	resultado.ShouldHaveValidationErrorFor(x => x.Numero);
		//}

		[TestMethod]
		public void Numero_cliente_nao_deve_ser_nulo_ou_vazio_ok()
		{
			//arrange
			Cliente.Numero = 1;

			//action
			var resultado = Validador.TestValidate(Cliente);

			//assert
			resultado.ShouldNotHaveValidationErrorFor(x => x.Numero);
		}
	}
}
