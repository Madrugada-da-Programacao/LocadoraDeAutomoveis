using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using LocadoraDeAutomoveis.Dominio.ModuloTaxaOuServico;

namespace LocadoraDeAutomoveis.TestesIntegracao.ModuloTaxaOuServico
{
	[TestClass]
	public class RepositorioTaxaOuServicoEmORmTest : TestesIntegracaoBase
	{
		[TestMethod]
		public void Deve_inserir_taxa_ou_servico()
		{
			//arrange
			var taxaOuServico = Builder<TaxaOuServico>.CreateNew().Build();

			//action
			RepositorioTaxaOuServico.Inserir(taxaOuServico);

			//assert
			RepositorioTaxaOuServico.SelecionarPorId(taxaOuServico.Id).Should().Be(taxaOuServico);
		}

		[TestMethod]
		public void Deve_editar_taxa_ou_servico()
		{
			//arrange
			var taxaOuServicoId = Builder<TaxaOuServico>.CreateNew().Persist().Id;

			var taxaOuServico = RepositorioTaxaOuServico.SelecionarPorId(taxaOuServicoId);
			taxaOuServico!.Nome = "Limpar o carro";

			//action
			RepositorioTaxaOuServico.Editar(taxaOuServico);

			//assert
			RepositorioTaxaOuServico.SelecionarPorId(taxaOuServico.Id)
				.Should().Be(taxaOuServico);
		}

		[TestMethod]
		public void Deve_excluir_taxa_ou_servico()
		{
			//arrange
			var taxaOuServico = Builder<TaxaOuServico>.CreateNew().Persist();

			//action
			RepositorioTaxaOuServico.Excluir(taxaOuServico);

			//assert
			RepositorioTaxaOuServico.SelecionarPorId(taxaOuServico.Id).Should().BeNull();
		}

		[TestMethod]
		public void Deve_selecionar_todas_taxa_ou_servico()
		{
			//arrange
			var limpezaDoCarro = Builder<TaxaOuServico>.CreateNew().Persist();
			var translado = Builder<TaxaOuServico>.CreateNew().Persist();

			//action
			var taxasOuServicos = RepositorioTaxaOuServico.SelecionarTodos();

			//assert
			taxasOuServicos.Should().ContainInOrder(limpezaDoCarro, translado);
			taxasOuServicos.Should().HaveCount(2);
		}

		[TestMethod]
		public void Deve_selecionar_taxa_ou_servico_por_nome()
		{
			//arrange
			var limpezaDoCarro = Builder<TaxaOuServico>.CreateNew().Persist();

			//action
			var taxaOuServicoEncontrado = RepositorioTaxaOuServico.SelecionarPorNome(limpezaDoCarro.Nome);

			//assert
			taxaOuServicoEncontrado.Should().Be(limpezaDoCarro);
		}

		[TestMethod]
		public void Deve_selecionar_taxa_ou_servico_por_id()
		{
			//arrange
			var limpezaDoCarro = Builder<TaxaOuServico>.CreateNew().Persist();

			//action
			var taxaOuServicoEncontrado = RepositorioTaxaOuServico.SelecionarPorId(limpezaDoCarro.Id);

			//assert            
			taxaOuServicoEncontrado.Should().Be(limpezaDoCarro);
		}
	}
}
