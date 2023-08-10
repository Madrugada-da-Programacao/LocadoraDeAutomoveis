namespace LocadoraDeAutomoveis.WinApp
{
	partial class TelaPrincipalForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			menu = new MenuStrip();
			cadastrosToolStripMenuItem = new ToolStripMenuItem();
			aluguelMenuItem = new ToolStripMenuItem();
			automovelMenuItem = new ToolStripMenuItem();
			clienteMenuItem = new ToolStripMenuItem();
			condutorMenuItem = new ToolStripMenuItem();
			funcionarioMenuItem = new ToolStripMenuItem();
			grupoDeAutomoveisMenuItem = new ToolStripMenuItem();
			planoDeCobrancaMenuItem = new ToolStripMenuItem();
			taxasEServicosMenuItem = new ToolStripMenuItem();
			parceiroToolStripMenuItem = new ToolStripMenuItem();
			cupomToolStripMenuItem = new ToolStripMenuItem();
			configurarPrecosToolStripMenuItem = new ToolStripMenuItem();
			toolbox = new ToolStrip();
			btnInserir = new ToolStripButton();
			btnEditar = new ToolStripButton();
			btnExcluir = new ToolStripButton();
			toolStripSeparator2 = new ToolStripSeparator();
			labelTipoCadastro = new ToolStripLabel();
			statusStrip1 = new StatusStrip();
			labelRodape = new ToolStripStatusLabel();
			panelRegistros = new Panel();
			menu.SuspendLayout();
			toolbox.SuspendLayout();
			statusStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// menu
			// 
			menu.ImageScalingSize = new Size(20, 20);
			menu.Items.AddRange(new ToolStripItem[] { cadastrosToolStripMenuItem, configurarPrecosToolStripMenuItem });
			menu.Location = new Point(0, 0);
			menu.Name = "menu";
			menu.Size = new Size(686, 24);
			menu.TabIndex = 0;
			menu.Text = "menuStrip1";
			// 
			// cadastrosToolStripMenuItem
			// 
			cadastrosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aluguelMenuItem, automovelMenuItem, clienteMenuItem, condutorMenuItem, cupomToolStripMenuItem, funcionarioMenuItem, grupoDeAutomoveisMenuItem, parceiroToolStripMenuItem, planoDeCobrancaMenuItem, taxasEServicosMenuItem });
			cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
			cadastrosToolStripMenuItem.Size = new Size(71, 20);
			cadastrosToolStripMenuItem.Text = "Cadastros";
			// 
			// aluguelMenuItem
			// 
			aluguelMenuItem.Name = "aluguelMenuItem";
			aluguelMenuItem.ShortcutKeys = Keys.F1;
			aluguelMenuItem.Size = new Size(209, 22);
			aluguelMenuItem.Text = "Aluguel";
			aluguelMenuItem.Click += aluguelMenuItem_Click;
			// 
			// automovelMenuItem
			// 
			automovelMenuItem.Name = "automovelMenuItem";
			automovelMenuItem.ShortcutKeys = Keys.F2;
			automovelMenuItem.Size = new Size(209, 22);
			automovelMenuItem.Text = "Automovel";
			automovelMenuItem.Click += automovelMenuItem_Click;
			// 
			// clienteMenuItem
			// 
			clienteMenuItem.Name = "clienteMenuItem";
			clienteMenuItem.ShortcutKeys = Keys.F3;
			clienteMenuItem.Size = new Size(209, 22);
			clienteMenuItem.Text = "Cliente";
			clienteMenuItem.Click += clienteMenuItem_Click;
			// 
			// condutorMenuItem
			// 
			condutorMenuItem.Name = "condutorMenuItem";
			condutorMenuItem.ShortcutKeys = Keys.F4;
			condutorMenuItem.Size = new Size(209, 22);
			condutorMenuItem.Text = "Condutor";
			condutorMenuItem.Click += condutorMenuItem_Click;
			// 
			// funcionarioMenuItem
			// 
			funcionarioMenuItem.Name = "funcionarioMenuItem";
			funcionarioMenuItem.ShortcutKeys = Keys.F6;
			funcionarioMenuItem.Size = new Size(209, 22);
			funcionarioMenuItem.Text = "Funcionario";
			funcionarioMenuItem.Click += funcionarioMenuItem_Click;
			// 
			// grupoDeAutomoveisMenuItem
			// 
			grupoDeAutomoveisMenuItem.Name = "grupoDeAutomoveisMenuItem";
			grupoDeAutomoveisMenuItem.ShortcutKeys = Keys.F7;
			grupoDeAutomoveisMenuItem.Size = new Size(209, 22);
			grupoDeAutomoveisMenuItem.Text = "Grupo de Automoveis";
			grupoDeAutomoveisMenuItem.Click += grupoDeAutomoveisMenuItem_Click;
			// 
			// planoDeCobrancaMenuItem
			// 
			planoDeCobrancaMenuItem.Name = "planoDeCobrancaMenuItem";
			planoDeCobrancaMenuItem.ShortcutKeys = Keys.F9;
			planoDeCobrancaMenuItem.Size = new Size(209, 22);
			planoDeCobrancaMenuItem.Text = "Plano de Cobranca";
			planoDeCobrancaMenuItem.Click += planoDeCobrancaMenuItem_Click;
			// 
			// taxasEServicosMenuItem
			// 
			taxasEServicosMenuItem.Name = "taxasEServicosMenuItem";
			taxasEServicosMenuItem.ShortcutKeys = Keys.F10;
			taxasEServicosMenuItem.Size = new Size(209, 22);
			taxasEServicosMenuItem.Text = "Taxas ou Servicos";
			taxasEServicosMenuItem.Click += taxasOuServicosMenuItem_Click;
			// 
			// parceiroToolStripMenuItem
			// 
			parceiroToolStripMenuItem.Name = "parceiroToolStripMenuItem";
			parceiroToolStripMenuItem.ShortcutKeys = Keys.F8;
			parceiroToolStripMenuItem.Size = new Size(209, 22);
			parceiroToolStripMenuItem.Text = "Parceiro";
			parceiroToolStripMenuItem.Click += parceiroToolStripMenuItem_Click;
			// 
			// cupomToolStripMenuItem
			// 
			cupomToolStripMenuItem.Name = "cupomToolStripMenuItem";
			cupomToolStripMenuItem.ShortcutKeys = Keys.F5;
			cupomToolStripMenuItem.Size = new Size(209, 22);
			cupomToolStripMenuItem.Text = "Cupom";
			cupomToolStripMenuItem.Click += cupomToolStripMenuItem_Click;
			// 
			// configurarPrecosToolStripMenuItem
			// 
			configurarPrecosToolStripMenuItem.Name = "configurarPrecosToolStripMenuItem";
			configurarPrecosToolStripMenuItem.Size = new Size(114, 20);
			configurarPrecosToolStripMenuItem.Text = "Configurar Preços";
			configurarPrecosToolStripMenuItem.Click += configurarPrecosToolStripMenuItem_Click;
			// 
			// toolbox
			// 
			toolbox.Enabled = false;
			toolbox.ImageScalingSize = new Size(20, 20);
			toolbox.Items.AddRange(new ToolStripItem[] { btnInserir, btnEditar, btnExcluir, toolStripSeparator2, labelTipoCadastro });
			toolbox.Location = new Point(0, 24);
			toolbox.Name = "toolbox";
			toolbox.Size = new Size(686, 32);
			toolbox.TabIndex = 1;
			toolbox.Text = "toolStrip1";
			// 
			// btnInserir
			// 
			btnInserir.DisplayStyle = ToolStripItemDisplayStyle.Text;
			btnInserir.ImageScaling = ToolStripItemImageScaling.None;
			btnInserir.ImageTransparentColor = Color.Magenta;
			btnInserir.Name = "btnInserir";
			btnInserir.Padding = new Padding(5);
			btnInserir.Size = new Size(72, 29);
			btnInserir.Text = "Adicionar";
			btnInserir.Click += btnInserir_Click;
			// 
			// btnEditar
			// 
			btnEditar.DisplayStyle = ToolStripItemDisplayStyle.Text;
			btnEditar.ImageScaling = ToolStripItemImageScaling.None;
			btnEditar.ImageTransparentColor = Color.Magenta;
			btnEditar.Name = "btnEditar";
			btnEditar.Padding = new Padding(5);
			btnEditar.Size = new Size(51, 29);
			btnEditar.Text = "Editar";
			btnEditar.Click += btnEditar_Click;
			// 
			// btnExcluir
			// 
			btnExcluir.DisplayStyle = ToolStripItemDisplayStyle.Text;
			btnExcluir.ImageScaling = ToolStripItemImageScaling.None;
			btnExcluir.ImageTransparentColor = Color.Magenta;
			btnExcluir.Name = "btnExcluir";
			btnExcluir.Padding = new Padding(5);
			btnExcluir.Size = new Size(56, 29);
			btnExcluir.Text = "Excluir";
			btnExcluir.Click += btnExcluir_Click;
			// 
			// toolStripSeparator2
			// 
			toolStripSeparator2.Name = "toolStripSeparator2";
			toolStripSeparator2.Size = new Size(6, 32);
			// 
			// labelTipoCadastro
			// 
			labelTipoCadastro.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
			labelTipoCadastro.Name = "labelTipoCadastro";
			labelTipoCadastro.Size = new Size(90, 29);
			labelTipoCadastro.Text = "[tipoCadastro]";
			// 
			// statusStrip1
			// 
			statusStrip1.ImageScalingSize = new Size(20, 20);
			statusStrip1.Items.AddRange(new ToolStripItem[] { labelRodape });
			statusStrip1.Location = new Point(0, 399);
			statusStrip1.Name = "statusStrip1";
			statusStrip1.Size = new Size(686, 22);
			statusStrip1.TabIndex = 2;
			statusStrip1.Text = "statusStrip1";
			// 
			// labelRodape
			// 
			labelRodape.Name = "labelRodape";
			labelRodape.Size = new Size(52, 17);
			labelRodape.Text = "[rodapé]";
			// 
			// panelRegistros
			// 
			panelRegistros.Dock = DockStyle.Fill;
			panelRegistros.Location = new Point(0, 56);
			panelRegistros.Name = "panelRegistros";
			panelRegistros.Size = new Size(686, 343);
			panelRegistros.TabIndex = 3;
			// 
			// TelaPrincipalForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(686, 421);
			Controls.Add(panelRegistros);
			Controls.Add(statusStrip1);
			Controls.Add(toolbox);
			Controls.Add(menu);
			MainMenuStrip = menu;
			MinimumSize = new Size(702, 458);
			Name = "TelaPrincipalForm";
			ShowIcon = false;
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Gerador de Testes 1.0";
			WindowState = FormWindowState.Maximized;
			menu.ResumeLayout(false);
			menu.PerformLayout();
			toolbox.ResumeLayout(false);
			toolbox.PerformLayout();
			statusStrip1.ResumeLayout(false);
			statusStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private MenuStrip menu;
		private ToolStripMenuItem cadastrosToolStripMenuItem;
		private ToolStripMenuItem aluguelMenuItem;
		private ToolStrip toolbox;
		private StatusStrip statusStrip1;
		private Panel panelRegistros;
		private ToolStripButton btnInserir;
		private ToolStripButton btnEditar;
		private ToolStripButton btnExcluir;
		private ToolStripStatusLabel labelRodape;
		private ToolStripSeparator toolStripSeparator2;
		private ToolStripLabel labelTipoCadastro;
		private ToolStripMenuItem automovelMenuItem;
		private ToolStripMenuItem clienteMenuItem;
		private ToolStripMenuItem condutorMenuItem;
		private ToolStripMenuItem funcionarioMenuItem;
		private ToolStripMenuItem grupoDeAutomoveisMenuItem;
		private ToolStripMenuItem planoDeCobrancaMenuItem;
		private ToolStripMenuItem taxasEServicosMenuItem;
		private ToolStripMenuItem configurarPrecosToolStripMenuItem;
		private ToolStripMenuItem parceiroToolStripMenuItem;
		private ToolStripMenuItem cupomToolStripMenuItem;
	}
}