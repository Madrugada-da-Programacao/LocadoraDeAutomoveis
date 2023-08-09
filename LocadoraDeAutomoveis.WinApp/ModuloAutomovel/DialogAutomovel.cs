using LocadoraDeAutomoveis.Dominio.ModuloAutomovel;
using LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis;
using LocadoraDeAutomoveis.WinApp.Compartilhado;
using Microsoft.IdentityModel.Tokens;
using System.Windows.Forms;

namespace LocadoraDeAutomoveis.WinApp.ModuloAutomovel
{
    public partial class DialogAutomovel : Form
    {
        private Automovel? automovel;

        public event GravarRegistroDelegate<Automovel>? onGravarRegistro;
        private byte[] Imagem { get; set; }
        public DialogAutomovel(List<GrupoDeAutomoveis> gruposDeAutomoveis)
        {
            InitializeComponent();
            this.ConfigurarDialog();
            CarregaGrupoDeAutomoveis(gruposDeAutomoveis);

            cbGrupo.DisplayMember = "Nome";
            cbGrupo.SelectedIndex = 0;
            cbTipoCombustivel.SelectedIndex = 0;
            pbImagem.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public Automovel Automovel
        {
            set
            {
                automovel = value;
                txtCor.Text = automovel.Cor;
                txtMarca.Text = automovel.Marca;
                txtModelo.Text = automovel.Modelo;
                txtPlaca.Text = automovel.Placa;
                txtAno.Text = automovel.Ano;
                cbGrupo.SelectedItem = automovel.GrupoDeAutomovel;
                cbTipoCombustivel.SelectedIndex = (int)automovel.TipoCombustivel;
                if (automovel.CapacidadeCombustivel < 5) automovel.CapacidadeCombustivel = 5;
                nudLitros.Value = (int)automovel.CapacidadeCombustivel;
                nudKM.Value = (decimal) automovel.KM;
                Imagem = automovel.Imagem;
                if (!Imagem.IsNullOrEmpty())
                {
                    using (MemoryStream ms = new MemoryStream(Imagem))
                    {
                        pbImagem.Image = Image.FromStream(ms);
                    }
                }
            }
            get
            {
                automovel.Cor = txtCor.Text;
                automovel.Marca = txtMarca.Text;
                automovel.Modelo = txtModelo.Text;
                automovel.Placa = txtPlaca.Text;
                automovel.TipoCombustivel = (Automovel.TiposDeCombustivel)cbTipoCombustivel.SelectedIndex;
                automovel.CapacidadeCombustivel = (float)nudLitros.Value;
                automovel.GrupoDeAutomovel = (GrupoDeAutomoveis)cbGrupo.SelectedItem;
                automovel.Imagem = Imagem;
                automovel.Ano = txtAno.Text;
                automovel.KM = (float) nudKM.Value;
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

        private void CarregaGrupoDeAutomoveis(List<GrupoDeAutomoveis> gruposDeAutomoveis)
        {
            foreach (GrupoDeAutomoveis g in gruposDeAutomoveis)
            {
                cbGrupo.Items.Add(g);
            }
        }
    }
}
