namespace LocadoraDeAutomoveis.WinApp.ModuloPlanoDeCobranca
{
	partial class DialogPlanoDeCobranca
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
			cmbGrupoAutomoveis = new ComboBox();
			label1 = new Label();
			groupBox1 = new GroupBox();
			tabControl1 = new TabControl();
			tabPage1 = new TabPage();
			txtPrecoDiariaPlanoDiaria = new NumericUpDown();
			txtPrecoKmPlanoDiaria = new NumericUpDown();
			label3 = new Label();
			label4 = new Label();
			tabPage2 = new TabPage();
			txtKmDisponiveisKmControlado = new NumericUpDown();
			txtPrecoDiariaKmControlado = new NumericUpDown();
			txtPrecoKmKmControlado = new NumericUpDown();
			label2 = new Label();
			label6 = new Label();
			label7 = new Label();
			tabPage3 = new TabPage();
			txtPrecoDiariaKmLivre = new NumericUpDown();
			label8 = new Label();
			btnGravar = new Button();
			btnCancelar = new Button();
			groupBox1.SuspendLayout();
			tabControl1.SuspendLayout();
			tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)txtPrecoDiariaPlanoDiaria).BeginInit();
			((System.ComponentModel.ISupportInitialize)txtPrecoKmPlanoDiaria).BeginInit();
			tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)txtKmDisponiveisKmControlado).BeginInit();
			((System.ComponentModel.ISupportInitialize)txtPrecoDiariaKmControlado).BeginInit();
			((System.ComponentModel.ISupportInitialize)txtPrecoKmKmControlado).BeginInit();
			tabPage3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)txtPrecoDiariaKmLivre).BeginInit();
			SuspendLayout();
			// 
			// cmbGrupoAutomoveis
			// 
			cmbGrupoAutomoveis.DropDownStyle = ComboBoxStyle.DropDownList;
			cmbGrupoAutomoveis.FormattingEnabled = true;
			cmbGrupoAutomoveis.Location = new Point(146, 37);
			cmbGrupoAutomoveis.Name = "cmbGrupoAutomoveis";
			cmbGrupoAutomoveis.Size = new Size(284, 23);
			cmbGrupoAutomoveis.TabIndex = 0;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(14, 40);
			label1.Name = "label1";
			label1.Size = new Size(126, 15);
			label1.TabIndex = 1;
			label1.Text = "Grupo de Automóveis:";
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(tabControl1);
			groupBox1.Location = new Point(68, 99);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(345, 209);
			groupBox1.TabIndex = 2;
			groupBox1.TabStop = false;
			groupBox1.Text = "Configuração de Planos de Cobrança";
			// 
			// tabControl1
			// 
			tabControl1.Controls.Add(tabPage1);
			tabControl1.Controls.Add(tabPage2);
			tabControl1.Controls.Add(tabPage3);
			tabControl1.Location = new Point(20, 31);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new Size(319, 162);
			tabControl1.TabIndex = 103;
			// 
			// tabPage1
			// 
			tabPage1.Controls.Add(txtPrecoDiariaPlanoDiaria);
			tabPage1.Controls.Add(txtPrecoKmPlanoDiaria);
			tabPage1.Controls.Add(label3);
			tabPage1.Controls.Add(label4);
			tabPage1.Location = new Point(4, 24);
			tabPage1.Name = "tabPage1";
			tabPage1.Padding = new Padding(3);
			tabPage1.Size = new Size(311, 134);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "Diário";
			tabPage1.UseVisualStyleBackColor = true;
			// 
			// txtPrecoDiariaPlanoDiaria
			// 
			txtPrecoDiariaPlanoDiaria.DecimalPlaces = 2;
			txtPrecoDiariaPlanoDiaria.Location = new Point(110, 21);
			txtPrecoDiariaPlanoDiaria.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
			txtPrecoDiariaPlanoDiaria.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			txtPrecoDiariaPlanoDiaria.Name = "txtPrecoDiariaPlanoDiaria";
			txtPrecoDiariaPlanoDiaria.Size = new Size(188, 23);
			txtPrecoDiariaPlanoDiaria.TabIndex = 14;
			txtPrecoDiariaPlanoDiaria.Value = new decimal(new int[] { 1, 0, 0, 0 });
			// 
			// txtPrecoKmPlanoDiaria
			// 
			txtPrecoKmPlanoDiaria.DecimalPlaces = 2;
			txtPrecoKmPlanoDiaria.Location = new Point(110, 56);
			txtPrecoKmPlanoDiaria.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
			txtPrecoKmPlanoDiaria.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			txtPrecoKmPlanoDiaria.Name = "txtPrecoKmPlanoDiaria";
			txtPrecoKmPlanoDiaria.Size = new Size(188, 23);
			txtPrecoKmPlanoDiaria.TabIndex = 15;
			txtPrecoKmPlanoDiaria.Value = new decimal(new int[] { 1, 0, 0, 0 });
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(31, 24);
			label3.Name = "label3";
			label3.Size = new Size(73, 15);
			label3.TabIndex = 11;
			label3.Text = "Preço Diária:";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(22, 59);
			label4.Name = "label4";
			label4.Size = new Size(82, 15);
			label4.TabIndex = 12;
			label4.Text = "Preço por Km:";
			// 
			// tabPage2
			// 
			tabPage2.Controls.Add(txtKmDisponiveisKmControlado);
			tabPage2.Controls.Add(txtPrecoDiariaKmControlado);
			tabPage2.Controls.Add(txtPrecoKmKmControlado);
			tabPage2.Controls.Add(label2);
			tabPage2.Controls.Add(label6);
			tabPage2.Controls.Add(label7);
			tabPage2.Location = new Point(4, 24);
			tabPage2.Name = "tabPage2";
			tabPage2.Padding = new Padding(3);
			tabPage2.Size = new Size(311, 134);
			tabPage2.TabIndex = 1;
			tabPage2.Text = "Km Controlado";
			tabPage2.UseVisualStyleBackColor = true;
			// 
			// txtKmDisponiveisKmControlado
			// 
			txtKmDisponiveisKmControlado.Location = new Point(110, 90);
			txtKmDisponiveisKmControlado.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
			txtKmDisponiveisKmControlado.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			txtKmDisponiveisKmControlado.Name = "txtKmDisponiveisKmControlado";
			txtKmDisponiveisKmControlado.Size = new Size(188, 23);
			txtKmDisponiveisKmControlado.TabIndex = 16;
			txtKmDisponiveisKmControlado.Value = new decimal(new int[] { 1, 0, 0, 0 });
			// 
			// txtPrecoDiariaKmControlado
			// 
			txtPrecoDiariaKmControlado.DecimalPlaces = 2;
			txtPrecoDiariaKmControlado.Location = new Point(110, 21);
			txtPrecoDiariaKmControlado.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
			txtPrecoDiariaKmControlado.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			txtPrecoDiariaKmControlado.Name = "txtPrecoDiariaKmControlado";
			txtPrecoDiariaKmControlado.Size = new Size(188, 23);
			txtPrecoDiariaKmControlado.TabIndex = 14;
			txtPrecoDiariaKmControlado.Value = new decimal(new int[] { 1, 0, 0, 0 });
			// 
			// txtPrecoKmKmControlado
			// 
			txtPrecoKmKmControlado.DecimalPlaces = 2;
			txtPrecoKmKmControlado.Location = new Point(110, 56);
			txtPrecoKmKmControlado.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
			txtPrecoKmKmControlado.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			txtPrecoKmKmControlado.Name = "txtPrecoKmKmControlado";
			txtPrecoKmKmControlado.Size = new Size(188, 23);
			txtPrecoKmKmControlado.TabIndex = 15;
			txtPrecoKmKmControlado.Value = new decimal(new int[] { 1, 0, 0, 0 });
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(31, 24);
			label2.Name = "label2";
			label2.Size = new Size(73, 15);
			label2.TabIndex = 11;
			label2.Text = "Preço Diária:";
			// 
			// label6
			// 
			label6.Location = new Point(21, 50);
			label6.Name = "label6";
			label6.Size = new Size(82, 33);
			label6.TabIndex = 12;
			label6.Text = "Preço por Km (Extrapolado):";
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new Point(13, 92);
			label7.Name = "label7";
			label7.Size = new Size(91, 15);
			label7.TabIndex = 13;
			label7.Text = "Km Disponíveis:";
			// 
			// tabPage3
			// 
			tabPage3.Controls.Add(txtPrecoDiariaKmLivre);
			tabPage3.Controls.Add(label8);
			tabPage3.Location = new Point(4, 24);
			tabPage3.Name = "tabPage3";
			tabPage3.Size = new Size(311, 134);
			tabPage3.TabIndex = 2;
			tabPage3.Text = "Km Livre";
			tabPage3.UseVisualStyleBackColor = true;
			// 
			// txtPrecoDiariaKmLivre
			// 
			txtPrecoDiariaKmLivre.DecimalPlaces = 2;
			txtPrecoDiariaKmLivre.Location = new Point(110, 21);
			txtPrecoDiariaKmLivre.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
			txtPrecoDiariaKmLivre.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			txtPrecoDiariaKmLivre.Name = "txtPrecoDiariaKmLivre";
			txtPrecoDiariaKmLivre.Size = new Size(188, 23);
			txtPrecoDiariaKmLivre.TabIndex = 14;
			txtPrecoDiariaKmLivre.Value = new decimal(new int[] { 1, 0, 0, 0 });
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Location = new Point(31, 24);
			label8.Name = "label8";
			label8.Size = new Size(73, 15);
			label8.TabIndex = 11;
			label8.Text = "Preço Diária:";
			// 
			// btnGravar
			// 
			btnGravar.DialogResult = DialogResult.OK;
			btnGravar.Location = new Point(298, 338);
			btnGravar.Name = "btnGravar";
			btnGravar.Size = new Size(75, 45);
			btnGravar.TabIndex = 101;
			btnGravar.Text = "Gravar";
			btnGravar.UseVisualStyleBackColor = true;
			btnGravar.Click += btnGravar_Click;
			// 
			// btnCancelar
			// 
			btnCancelar.DialogResult = DialogResult.Cancel;
			btnCancelar.Location = new Point(394, 338);
			btnCancelar.Name = "btnCancelar";
			btnCancelar.Size = new Size(75, 45);
			btnCancelar.TabIndex = 102;
			btnCancelar.Text = "Cancelar";
			btnCancelar.UseVisualStyleBackColor = true;
			// 
			// DialogPlanoDeCobranca
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(481, 395);
			Controls.Add(btnCancelar);
			Controls.Add(btnGravar);
			Controls.Add(groupBox1);
			Controls.Add(label1);
			Controls.Add(cmbGrupoAutomoveis);
			Name = "DialogPlanoDeCobranca";
			ShowIcon = false;
			Text = "Cadastro Plano de Cobrança";
			groupBox1.ResumeLayout(false);
			tabControl1.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			tabPage1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)txtPrecoDiariaPlanoDiaria).EndInit();
			((System.ComponentModel.ISupportInitialize)txtPrecoKmPlanoDiaria).EndInit();
			tabPage2.ResumeLayout(false);
			tabPage2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)txtKmDisponiveisKmControlado).EndInit();
			((System.ComponentModel.ISupportInitialize)txtPrecoDiariaKmControlado).EndInit();
			((System.ComponentModel.ISupportInitialize)txtPrecoKmKmControlado).EndInit();
			tabPage3.ResumeLayout(false);
			tabPage3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)txtPrecoDiariaKmLivre).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private ComboBox cmbGrupoAutomoveis;
		private Label label1;
		private GroupBox groupBox1;
		private Button btnGravar;
		private Button btnCancelar;
		private TabControl tabControl1;
		private TabPage tabPage1;
		private NumericUpDown txtPrecoDiariaPlanoDiaria;
		private NumericUpDown txtPrecoKmPlanoDiaria;
		private Label label3;
		private Label label4;
		private TabPage tabPage2;
		private NumericUpDown txtKmDisponiveisKmControlado;
		private NumericUpDown txtPrecoDiariaKmControlado;
		private NumericUpDown txtPrecoKmKmControlado;
		private Label label2;
		private Label label6;
		private Label label7;
		private TabPage tabPage3;
		private NumericUpDown txtPrecoDiariaKmLivre;
		private Label label8;
	}
}