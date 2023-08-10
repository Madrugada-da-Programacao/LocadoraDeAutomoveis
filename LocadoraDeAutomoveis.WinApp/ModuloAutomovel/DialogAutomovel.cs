using LocadoraDeAutomoveis.Dominio.ModuloAutomovel;
using LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis;
using Microsoft.IdentityModel.Tokens;
using static LocadoraDeAutomoveis.Dominio.ModuloAutomovel.Automovel;

namespace LocadoraDeAutomoveis.WinApp.ModuloAutomovel
{
	public partial class DialogAutomovel : Form
	{
		private Automovel? automovel;

		public event GravarRegistroDelegate<Automovel>? onGravarRegistro;
		private byte[]? Imagem { get; set; }
		public DialogAutomovel(List<GrupoDeAutomoveis> registros)
		{
			InitializeComponent();
			this.ConfigurarDialog();

			cbGrupo.DisplayMember = "Nome";
			cbGrupo.DataSource = registros;

			foreach (TiposDeCombustivel value in Enum.GetValues(typeof(TiposDeCombustivel)))
			{
				string description = value.GetDescription();
				cbTipoCombustivel.Items.Add(description);
			}

			pbImagem.SizeMode = PictureBoxSizeMode.StretchImage;
		}

		private TiposDeCombustivel GetEnumValueFromDescription(string description)
		{
			foreach (TiposDeCombustivel value in Enum.GetValues(typeof(TiposDeCombustivel)))
			{
				if (value.GetDescription() == description)
				{
					return value;
				}
			}
			throw new ArgumentException("Invalid description");
		}

		public Automovel Automovel
		{
			set
			{
				automovel = value;
				Imagem = automovel.Imagem;
				if (!Imagem.IsNullOrEmpty())
				{
					using (MemoryStream ms = new MemoryStream(Imagem))
					{
						pbImagem.Image = Image.FromStream(ms);
					}
				}

				if (automovel.GrupoDeAutomovel != null)
					cbGrupo.SelectedItem = automovel.GrupoDeAutomovel;

				txtModelo.Text = automovel.Modelo;
				txtMarca.Text = automovel.Marca;
				txtPlaca.Text = automovel.Placa;
				txtCor.Text = automovel.Cor;
				dateTimePickerAno.Value = automovel.Ano;
				nudKM.Value = (decimal)automovel.KM;


				cbTipoCombustivel.Text = automovel.TipoCombustivel.GetDescription();

				nudLitros.Value = (int)automovel.CapacidadeCombustivel;
			}
			get
			{
				//TODO verificar se precisa desta verificação
				if (Imagem != null)
					automovel!.Imagem = Imagem;
				automovel!.GrupoDeAutomovel = (GrupoDeAutomoveis)cbGrupo.SelectedItem;
				automovel.Modelo = txtModelo.Text;
				automovel.Marca = txtMarca.Text;
				automovel.Placa = txtPlaca.Text;
				automovel!.Cor = txtCor.Text;
				automovel.Ano = dateTimePickerAno.Value;
				automovel.KM = (float)nudKM.Value;

				string? selectedDescription = cbTipoCombustivel.SelectedItem.ToString();
				automovel.TipoCombustivel = GetEnumValueFromDescription(selectedDescription!);

				automovel.CapacidadeCombustivel = (float)nudLitros.Value;

				return automovel;
			}
		}

		private void btnGravar_Click(object sender, EventArgs e)
		{
			Result resultado = onGravarRegistro!(Automovel);

			if (resultado.IsFailed)
			{
				string erro = resultado.Errors[0].Message;

				TelaPrincipalForm.Instancia!.AtualizarRodape(erro);

				DialogResult = DialogResult.None;
			}
		}
		private void btnImagem_Click(object sender, EventArgs e)
		{
			BuscaArquivo.Filter = "Imagens|*.jpg;*.jpeg;*.png;*.webp";

			if (BuscaArquivo.ShowDialog() == DialogResult.OK)
			{
				string LocalDaImagem = BuscaArquivo.FileName;
				byte[] ImagemArray = File.ReadAllBytes(LocalDaImagem);
				if (ImagemArray.Length <= 2 * 1024 * 1024)
				{
					Imagem = ImagemArray;
					using (MemoryStream ms = new MemoryStream(ImagemArray))
					{
						pbImagem.Image = Image.FromStream(ms);
					}

				}
				else
				{
					MessageBox.Show("O Tamanho da Imagem Excede o Limite de 2mb.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
	}
}
