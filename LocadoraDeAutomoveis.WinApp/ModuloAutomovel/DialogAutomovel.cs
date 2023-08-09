using LocadoraDeAutomoveis.Dominio.ModuloAutomovel;
using LocadoraDeAutomoveis.Dominio.ModuloGrupoDeAutomoveis;
using LocadoraDeAutomoveis.WinApp.Compartilhado;
using System.Windows.Forms;

namespace LocadoraDeAutomoveis.WinApp.ModuloAutomovel
{
    public partial class DialogAutomovel : Form
    {
        private Automovel? automovel;

        public event GravarRegistroDelegate<Automovel>? onGravarRegistro;
        public DialogAutomovel()
        {
            InitializeComponent();
            this.ConfigurarDialog();
            //TODO adicionar Lista de grupos
            //foreach(GrupoDeAutomoveis grupo in TelaPrincipalForm.Repositorio)
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
                //cbGrupo.SelectedItem = automovel.GrupoDeAutomovel.Nome;
                cbTipoCombustivel.SelectedIndex = (int)automovel.TipoCombustivel;
                nudLitros.Value = (int) automovel.CapacidadeCombustivel;
            }
            get
            {
                automovel.Cor = txtCor.Text;
                automovel.Marca = txtMarca.Text;
                automovel.Modelo = txtModelo.Text;
                automovel.Placa = txtPlaca.Text;
                automovel.TipoCombustivel = (Automovel.TiposDeCombustivel) cbTipoCombustivel.SelectedIndex;
                automovel.CapacidadeCombustivel = (float) nudLitros.Value;
                //automovel.GrupoDeAutomovel = cbGrupo
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

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbTipoCombustivel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
