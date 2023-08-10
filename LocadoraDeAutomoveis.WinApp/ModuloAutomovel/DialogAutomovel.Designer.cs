namespace LocadoraDeAutomoveis.WinApp.ModuloAutomovel
{
	partial class DialogAutomovel
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
			txtModelo = new TextBox();
			label2 = new Label();
			label3 = new Label();
			txtMarca = new TextBox();
			label8 = new Label();
			txtCor = new TextBox();
			label9 = new Label();
			btnGravar = new Button();
			btnCancelar = new Button();
			txtPlaca = new TextBox();
			label1 = new Label();
			pbImagem = new PictureBox();
			BuscaArquivo = new OpenFileDialog();
			btnImagem = new Button();
			nudLitros = new NumericUpDown();
			cbGrupo = new ComboBox();
			cbTipoCombustivel = new ComboBox();
			label4 = new Label();
			label5 = new Label();
			label6 = new Label();
			label10 = new Label();
			nudKM = new NumericUpDown();
			dateTimePickerAno = new DateTimePicker();
			((System.ComponentModel.ISupportInitialize)pbImagem).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudLitros).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudKM).BeginInit();
			SuspendLayout();
			// 
			// txtModelo
			// 
			txtModelo.Location = new Point(119, 183);
			txtModelo.Name = "txtModelo";
			txtModelo.Size = new Size(329, 23);
			txtModelo.TabIndex = 1;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(58, 183);
			label2.Name = "label2";
			label2.Size = new Size(51, 15);
			label2.TabIndex = 2;
			label2.Text = "Modelo:";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(58, 214);
			label3.Name = "label3";
			label3.Size = new Size(43, 15);
			label3.TabIndex = 3;
			label3.Text = "Marca:";
			// 
			// txtMarca
			// 
			txtMarca.Location = new Point(119, 210);
			txtMarca.Name = "txtMarca";
			txtMarca.Size = new Size(327, 23);
			txtMarca.TabIndex = 2;
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Location = new Point(58, 268);
			label8.Name = "label8";
			label8.Size = new Size(29, 15);
			label8.TabIndex = 15;
			label8.Text = "Cor:";
			// 
			// txtCor
			// 
			txtCor.Location = new Point(119, 262);
			txtCor.Name = "txtCor";
			txtCor.Size = new Size(100, 23);
			txtCor.TabIndex = 6;
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Location = new Point(38, 424);
			label9.Name = "label9";
			label9.Size = new Size(124, 15);
			label9.TabIndex = 17;
			label9.Text = "Capacidade em Litros:";
			// 
			// btnGravar
			// 
			btnGravar.DialogResult = DialogResult.OK;
			btnGravar.Location = new Point(252, 467);
			btnGravar.Name = "btnGravar";
			btnGravar.Size = new Size(75, 45);
			btnGravar.TabIndex = 99;
			btnGravar.Text = "Gravar";
			btnGravar.UseVisualStyleBackColor = true;
			btnGravar.Click += btnGravar_Click;
			// 
			// btnCancelar
			// 
			btnCancelar.DialogResult = DialogResult.Cancel;
			btnCancelar.Location = new Point(351, 467);
			btnCancelar.Name = "btnCancelar";
			btnCancelar.Size = new Size(75, 45);
			btnCancelar.TabIndex = 100;
			btnCancelar.Text = "Cancelar";
			btnCancelar.UseVisualStyleBackColor = true;
			// 
			// txtPlaca
			// 
			txtPlaca.Location = new Point(119, 236);
			txtPlaca.Name = "txtPlaca";
			txtPlaca.Size = new Size(100, 23);
			txtPlaca.TabIndex = 101;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(58, 238);
			label1.Name = "label1";
			label1.Size = new Size(38, 15);
			label1.TabIndex = 102;
			label1.Text = "Placa:";
			// 
			// pbImagem
			// 
			pbImagem.Location = new Point(172, 20);
			pbImagem.Margin = new Padding(3, 2, 3, 2);
			pbImagem.Name = "pbImagem";
			pbImagem.Size = new Size(165, 104);
			pbImagem.TabIndex = 103;
			pbImagem.TabStop = false;
			// 
			// BuscaArquivo
			// 
			BuscaArquivo.FileName = "BuscaArquivo";
			BuscaArquivo.Filter = "Imagens|*.jpg;*.jpeg;*.png;*.webp";
			// 
			// btnImagem
			// 
			btnImagem.Location = new Point(351, 57);
			btnImagem.Margin = new Padding(3, 2, 3, 2);
			btnImagem.Name = "btnImagem";
			btnImagem.Size = new Size(82, 22);
			btnImagem.TabIndex = 104;
			btnImagem.Text = "Buscar";
			btnImagem.UseVisualStyleBackColor = true;
			btnImagem.Click += btnImagem_Click;
			// 
			// nudLitros
			// 
			nudLitros.Location = new Point(180, 424);
			nudLitros.Margin = new Padding(3, 2, 3, 2);
			nudLitros.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
			nudLitros.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			nudLitros.Name = "nudLitros";
			nudLitros.Size = new Size(131, 23);
			nudLitros.TabIndex = 105;
			nudLitros.Value = new decimal(new int[] { 1, 0, 0, 0 });
			// 
			// cbGrupo
			// 
			cbGrupo.FormattingEnabled = true;
			cbGrupo.Location = new Point(195, 157);
			cbGrupo.Margin = new Padding(3, 2, 3, 2);
			cbGrupo.Name = "cbGrupo";
			cbGrupo.Size = new Size(133, 23);
			cbGrupo.TabIndex = 106;
			// 
			// cbTipoCombustivel
			// 
			cbTipoCombustivel.FormattingEnabled = true;
			cbTipoCombustivel.Location = new Point(172, 393);
			cbTipoCombustivel.Margin = new Padding(3, 2, 3, 2);
			cbTipoCombustivel.Name = "cbTipoCombustivel";
			cbTipoCombustivel.Size = new Size(133, 23);
			cbTipoCombustivel.TabIndex = 107;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(38, 399);
			label4.Name = "label4";
			label4.Size = new Size(119, 15);
			label4.TabIndex = 108;
			label4.Text = "Tipo de Combustivel:";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(55, 159);
			label5.Name = "label5";
			label5.Size = new Size(123, 15);
			label5.TabIndex = 109;
			label5.Text = "Grupo de Automoveis";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(55, 302);
			label6.Name = "label6";
			label6.Size = new Size(32, 15);
			label6.TabIndex = 110;
			label6.Text = "Ano:";
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.Location = new Point(55, 356);
			label10.Name = "label10";
			label10.Size = new Size(94, 15);
			label10.TabIndex = 113;
			label10.Text = "Quilometragem:";
			// 
			// nudKM
			// 
			nudKM.DecimalPlaces = 1;
			nudKM.Location = new Point(163, 355);
			nudKM.Margin = new Padding(3, 2, 3, 2);
			nudKM.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
			nudKM.Name = "nudKM";
			nudKM.Size = new Size(131, 23);
			nudKM.TabIndex = 114;
			// 
			// dateTimePickerAno
			// 
			dateTimePickerAno.CustomFormat = "yyyy";
			dateTimePickerAno.Format = DateTimePickerFormat.Custom;
			dateTimePickerAno.Location = new Point(119, 296);
			dateTimePickerAno.Name = "dateTimePickerAno";
			dateTimePickerAno.Size = new Size(200, 23);
			dateTimePickerAno.TabIndex = 115;
			// 
			// DialogAutomovel
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(452, 522);
			Controls.Add(dateTimePickerAno);
			Controls.Add(nudKM);
			Controls.Add(label10);
			Controls.Add(label6);
			Controls.Add(label5);
			Controls.Add(label4);
			Controls.Add(cbTipoCombustivel);
			Controls.Add(cbGrupo);
			Controls.Add(nudLitros);
			Controls.Add(btnImagem);
			Controls.Add(pbImagem);
			Controls.Add(label1);
			Controls.Add(txtPlaca);
			Controls.Add(btnCancelar);
			Controls.Add(btnGravar);
			Controls.Add(label9);
			Controls.Add(txtCor);
			Controls.Add(label8);
			Controls.Add(txtMarca);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(txtModelo);
			Name = "DialogAutomovel";
			Text = "DialogAutomovel";
			((System.ComponentModel.ISupportInitialize)pbImagem).EndInit();
			((System.ComponentModel.ISupportInitialize)nudLitros).EndInit();
			((System.ComponentModel.ISupportInitialize)nudKM).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private TextBox txtModelo;
		private Label label2;
		private Label label3;
		private TextBox txtMarca;
		private Label label8;
		private TextBox txtCor;
		private Label label9;
		private Button btnGravar;
		private Button btnCancelar;
		private TextBox txtPlaca;
		private Label label1;
		private PictureBox pbImagem;
		private OpenFileDialog BuscaArquivo;
		private Button btnImagem;
		private NumericUpDown nudLitros;
		private ComboBox cbGrupo;
		private ComboBox cbTipoCombustivel;
		private Label label4;
		private Label label5;
		private Label label6;
		private Label label10;
		private NumericUpDown nudKM;
		private DateTimePicker dateTimePickerAno;
	}
}