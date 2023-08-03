namespace LocadoraDeAutomoveis.WinApp
{
    public abstract class ConfiguracaoToolboxBase
    {
		public abstract string TipoEntidade { get; }

		#region tooltips dos botões
		public string TipoCadastro => $"Cadastro de {TipoEntidade}";

		public string TooltipInserir => $"Inserir novo {TipoEntidade}";
		public string TooltipEditar => $"Editar {TipoEntidade} existente";
		public string TooltipExcluir => $"Excluir {TipoEntidade} existente";

		#endregion

		#region estados dos botões
		public virtual bool InserirHabilitado => true;
		public virtual bool EditarHabilitado => true;
		public virtual bool ExcluirHabilitado => true;

        #endregion

    }
}