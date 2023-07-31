using System.Windows.Forms;

namespace LocadoraDeAutomoveis.WinApp
{
    public static class FormExtensions
    {
        public static void ConfigurarDialog(this Form form)
        {
            form.ShowIcon = false;
            form.ShowInTaskbar = false;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.FormClosing += Form_FormClosing;
        }

        private static void Form_FormClosing(object? sender, FormClosingEventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape();
        }
    }
}
