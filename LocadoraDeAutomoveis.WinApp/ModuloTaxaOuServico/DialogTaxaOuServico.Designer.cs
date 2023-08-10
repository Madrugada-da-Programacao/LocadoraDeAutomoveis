namespace LocadoraDeAutomoveis.WinApp.ModuloTaxaOuServico
{
	partial class DialogTaxaOuServico
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
			groupBox1 = new GroupBox();
			radioButtonCobrancaDiaria = new RadioButton();
			radioButtonPrecoFixo = new RadioButton();
			label1 = new Label();
			txtNome = new TextBox();
			label2 = new Label();
			numericUpDownPreco = new NumericUpDown();
			btnGravar = new Button();
			btnCancelar = new Button();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDownPreco).BeginInit();
			SuspendLayout();
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(radioButtonCobrancaDiaria);
			groupBox1.Controls.Add(radioButtonPrecoFixo);
			groupBox1.Location = new Point(15, 120);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(327, 81);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			groupBox1.Text = "Plano de Calculo";
			// 
			// radioButtonCobrancaDiaria
			// 
			radioButtonCobrancaDiaria.AutoSize = true;
			radioButtonCobrancaDiaria.Location = new Point(180, 41);
			radioButtonCobrancaDiaria.Name = "radioButtonCobrancaDiaria";
			radioButtonCobrancaDiaria.Size = new Size(109, 19);
			radioButtonCobrancaDiaria.TabIndex = 1;
			radioButtonCobrancaDiaria.TabStop = true;
			radioButtonCobrancaDiaria.Text = "Cobrança Diária";
			radioButtonCobrancaDiaria.UseVisualStyleBackColor = true;
			// 
			// radioButtonPrecoFixo
			// 
			radioButtonPrecoFixo.AutoSize = true;
			radioButtonPrecoFixo.Location = new Point(46, 41);
			radioButtonPrecoFixo.Name = "radioButtonPrecoFixo";
			radioButtonPrecoFixo.Size = new Size(80, 19);
			radioButtonPrecoFixo.TabIndex = 0;
			radioButtonPrecoFixo.TabStop = true;
			radioButtonPrecoFixo.Text = "Preço Fixo";
			radioButtonPrecoFixo.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(12, 24);
			label1.Name = "label1";
			label1.Size = new Size(43, 15);
			label1.TabIndex = 1;
			label1.Text = "Nome:";
			// 
			// txtNome
			// 
			txtNome.Location = new Point(61, 21);
			txtNome.Name = "txtNome";
			txtNome.Size = new Size(281, 23);
			txtNome.TabIndex = 2;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(15, 79);
			label2.Name = "label2";
			label2.Size = new Size(40, 15);
			label2.TabIndex = 3;
			label2.Text = "Preço:";
			// 
			// numericUpDownPreco
			// 
			numericUpDownPreco.DecimalPlaces = 2;
			numericUpDownPreco.Location = new Point(61, 77);
			numericUpDownPreco.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
			numericUpDownPreco.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
			numericUpDownPreco.Name = "numericUpDownPreco";
			numericUpDownPreco.Size = new Size(90, 23);
			numericUpDownPreco.TabIndex = 4;
			numericUpDownPreco.Value = new decimal(new int[] { 1, 0, 0, 131072 });
			// 
			// btnGravar
			// 
			btnGravar.DialogResult = DialogResult.OK;
			btnGravar.Location = new Point(176, 239);
			btnGravar.Name = "btnGravar";
			btnGravar.Size = new Size(75, 45);
			btnGravar.TabIndex = 100;
			btnGravar.Text = "Gravar";
			btnGravar.UseVisualStyleBackColor = true;
			btnGravar.Click += btnGravar_Click;
			// 
			// btnCancelar
			// 
			btnCancelar.DialogResult = DialogResult.Cancel;
			btnCancelar.Location = new Point(267, 239);
			btnCancelar.Name = "btnCancelar";
			btnCancelar.Size = new Size(75, 45);
			btnCancelar.TabIndex = 101;
			btnCancelar.Text = "Cancelar";
			btnCancelar.UseVisualStyleBackColor = true;
			// 
			// DialogTaxaOuServico
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(363, 308);
			Controls.Add(btnCancelar);
			Controls.Add(btnGravar);
			Controls.Add(numericUpDownPreco);
			Controls.Add(label2);
			Controls.Add(txtNome);
			Controls.Add(label1);
			Controls.Add(groupBox1);
			Name = "DialogTaxaOuServico";
			Text = "DialogTaxaOuServico";
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDownPreco).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private GroupBox groupBox1;
		private RadioButton radioButtonCobrancaDiaria;
		private RadioButton radioButtonPrecoFixo;
		private Label label1;
		private TextBox txtNome;
		private Label label2;
		private NumericUpDown numericUpDownPreco;
		private Button btnGravar;
		private Button btnCancelar;
	}
}