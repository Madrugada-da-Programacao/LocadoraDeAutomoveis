﻿using LocadoraDeAutomoveis.Dominio.Compartilhado;
using LocadoraDeAutomoveis.Dominio.ModuloAutomovel;
using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using LocadoraDeAutomoveis.Dominio.ModuloCondutor;
using LocadoraDeAutomoveis.Dominio.ModuloCupom;
using LocadoraDeAutomoveis.Dominio.ModuloFuncionario;
using LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis;
using LocadoraDeAutomoveis.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeAutomoveis.Dominio.ModuloTaxaOuServico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeAutomoveis.Dominio.ModuloAluguel
{
    public class Aluguel : EntidadeBase<Aluguel>
    {
        //funcionario cliente grupoauto planocobr condutor automovel
        // data locação devolucaoprevista kmdoautomovel cupomlist taxas taxasAdicionais valortotalTODO
        public Funcionario Funcionario { get; set; }
        public Cliente Cliente { get; set; }
        public GrupoDeAutomoveis GrupoDeAutomoveis { get; set; }
        public PlanoDeCobranca PlanoDeCobranca { get; set; }
        public Condutor Condutor { get; set; }
        public Automovel Automovel { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucaoPrevista { get; set; }
        public DateTime DataDevolucao { get; set; }
        public int KmAutomovel { get; set; }
        public List<Cupom> Cupoms { get; set; }
        public List<TaxaOuServico> Taxas { get; set; }
        public List<TaxaOuServico> TaxasAdicionais { get; set; }
        public decimal ValorTotal { get; set; }

        public Aluguel(Funcionario funcionario, Cliente cliente, GrupoDeAutomoveis grupoDeAutomoveis, PlanoDeCobranca planoDeCobranca, Condutor condutor, Automovel automovel, DateTime dataLocacao, DateTime dataDevolucaoPrevista, int kmAutomovel, List<Cupom> cupoms, List<TaxaOuServico> taxas, List<TaxaOuServico> taxasAdicionais, decimal valorTotal)
        {
            Funcionario = funcionario;
            Cliente = cliente;
            GrupoDeAutomoveis = grupoDeAutomoveis;
            PlanoDeCobranca = planoDeCobranca;
            Condutor = condutor;
            Automovel = automovel;
            DataLocacao = dataLocacao;
            DataDevolucaoPrevista = dataDevolucaoPrevista;
            KmAutomovel = kmAutomovel;
            Cupoms = cupoms;
            Taxas = taxas;
            TaxasAdicionais = taxasAdicionais;
            ValorTotal = valorTotal;
        }

        public Aluguel()
        {
        }
    }
}
