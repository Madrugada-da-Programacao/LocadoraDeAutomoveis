namespace LocadoraDeAutomoveis.WinApp.ModuloCliente
{
	partial class DialogCliente
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
			label1 = new Label();
			txtNome = new TextBox();
			label2 = new Label();
			label3 = new Label();
			txtEmail = new TextBox();
			label4 = new Label();
			label5 = new Label();
			radioButtonPessoaFisica = new RadioButton();
			radioButtonPessoaJuridica = new RadioButton();
			label6 = new Label();
			maskedtxtTelefone = new MaskedTextBox();
			label7 = new Label();
			label8 = new Label();
			txtEstado = new TextBox();
			label9 = new Label();
			txtCidade = new TextBox();
			label10 = new Label();
			txtBairro = new TextBox();
			label11 = new Label();
			txtRua = new TextBox();
			label12 = new Label();
			labelId = new Label();
			numericUpDownNumero = new NumericUpDown();
			maskedtxtCPF = new MaskedTextBox();
			maskedtxtCNPJ = new MaskedTextBox();
			btnGravar = new Button();
			btnCancelar = new Button();
			((System.ComponentModel.ISupportInitialize)numericUpDownNumero).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(81, 18);
			label1.Name = "label1";
			label1.Size = new Size(20, 15);
			label1.TabIndex = 0;
			label1.Text = "Id:";
			// 
			// txtNome
			// 
			txtNome.Location = new Point(107, 40);
			txtNome.Name = "txtNome";
			txtNome.Size = new Size(329, 23);
			txtNome.TabIndex = 1;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(58, 43);
			label2.Name = "label2";
			label2.Size = new Size(43, 15);
			label2.TabIndex = 2;
			label2.Text = "Nome:";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(62, 94);
			label3.Name = "label3";
			label3.Size = new Size(39, 15);
			label3.TabIndex = 3;
			label3.Text = "Email:";
			// 
			// txtEmail
			// 
			txtEmail.Location = new Point(109, 91);
			txtEmail.Name = "txtEmail";
			txtEmail.Size = new Size(327, 23);
			txtEmail.TabIndex = 2;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(47, 145);
			label4.Name = "label4";
			label4.Size = new Size(54, 15);
			label4.TabIndex = 5;
			label4.Text = "Telefone:";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(12, 196);
			label5.Name = "label5";
			label5.Size = new Size(89, 15);
			label5.TabIndex = 7;
			label5.Text = "Tipo de Cliente:";
			// 
			// radioButtonPessoaFisica
			// 
			radioButtonPessoaFisica.AutoSize = true;
			radioButtonPessoaFisica.Location = new Point(107, 192);
			radioButtonPessoaFisica.Name = "radioButtonPessoaFisica";
			radioButtonPessoaFisica.Size = new Size(93, 19);
			radioButtonPessoaFisica.TabIndex = 0;
			radioButtonPessoaFisica.TabStop = true;
			radioButtonPessoaFisica.Text = "Pessoa Física";
			radioButtonPessoaFisica.UseVisualStyleBackColor = true;
			radioButtonPessoaFisica.CheckedChanged += radioButtonTipoDePessoa_CheckedChanged;
			// 
			// radioButtonPessoaJuridica
			// 
			radioButtonPessoaJuridica.AutoSize = true;
			radioButtonPessoaJuridica.Location = new Point(268, 192);
			radioButtonPessoaJuridica.Name = "radioButtonPessoaJuridica";
			radioButtonPessoaJuridica.Size = new Size(104, 19);
			radioButtonPessoaJuridica.TabIndex = 98;
			radioButtonPessoaJuridica.TabStop = true;
			radioButtonPessoaJuridica.Text = "Pessoa Jurídica";
			radioButtonPessoaJuridica.UseVisualStyleBackColor = true;
			radioButtonPessoaJuridica.CheckedChanged += radioButtonTipoDePessoa_CheckedChanged;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(70, 246);
			label6.Name = "label6";
			label6.Size = new Size(31, 15);
			label6.TabIndex = 10;
			label6.Text = "CPF:";
			// 
			// maskedtxtTelefone
			// 
			maskedtxtTelefone.Location = new Point(107, 142);
			maskedtxtTelefone.Mask = "(00) 0 0000-0000";
			maskedtxtTelefone.Name = "maskedtxtTelefone";
			maskedtxtTelefone.Size = new Size(188, 23);
			maskedtxtTelefone.TabIndex = 3;
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new Point(225, 246);
			label7.Name = "label7";
			label7.Size = new Size(37, 15);
			label7.TabIndex = 13;
			label7.Text = "CNPJ:";
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Location = new Point(56, 306);
			label8.Name = "label8";
			label8.Size = new Size(45, 15);
			label8.TabIndex = 15;
			label8.Text = "Estado:";
			// 
			// txtEstado
			// 
			txtEstado.Location = new Point(107, 303);
			txtEstado.Name = "txtEstado";
			txtEstado.Size = new Size(100, 23);
			txtEstado.TabIndex = 6;
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Location = new Point(215, 306);
			label9.Name = "label9";
			label9.Size = new Size(47, 15);
			label9.TabIndex = 17;
			label9.Text = "Cidade:";
			// 
			// txtCidade
			// 
			txtCidade.Location = new Point(268, 303);
			txtCidade.Name = "txtCidade";
			txtCidade.Size = new Size(168, 23);
			txtCidade.TabIndex = 7;
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.Location = new Point(60, 367);
			label10.Name = "label10";
			label10.Size = new Size(41, 15);
			label10.TabIndex = 19;
			label10.Text = "Bairro:";
			// 
			// txtBairro
			// 
			txtBairro.Location = new Point(107, 364);
			txtBairro.Name = "txtBairro";
			txtBairro.Size = new Size(329, 23);
			txtBairro.TabIndex = 8;
			// 
			// label11
			// 
			label11.AutoSize = true;
			label11.Location = new Point(71, 434);
			label11.Name = "label11";
			label11.Size = new Size(30, 15);
			label11.TabIndex = 21;
			label11.Text = "Rua:";
			// 
			// txtRua
			// 
			txtRua.Location = new Point(107, 431);
			txtRua.Name = "txtRua";
			txtRua.Size = new Size(329, 23);
			txtRua.TabIndex = 9;
			// 
			// label12
			// 
			label12.AutoSize = true;
			label12.Location = new Point(47, 512);
			label12.Name = "label12";
			label12.Size = new Size(54, 15);
			label12.TabIndex = 23;
			label12.Text = "Número:";
			// 
			// labelId
			// 
			labelId.AutoSize = true;
			labelId.Location = new Point(109, 18);
			labelId.Name = "labelId";
			labelId.Size = new Size(13, 15);
			labelId.TabIndex = 25;
			labelId.Text = "0";
			// 
			// numericUpDownNumero
			// 
			numericUpDownNumero.Location = new Point(109, 504);
			numericUpDownNumero.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
			numericUpDownNumero.Name = "numericUpDownNumero";
			numericUpDownNumero.Size = new Size(120, 23);
			numericUpDownNumero.TabIndex = 10;
			// 
			// maskedtxtCPF
			// 
			maskedtxtCPF.Location = new Point(107, 243);
			maskedtxtCPF.Mask = "000\\.000\\.000-00";
			maskedtxtCPF.Name = "maskedtxtCPF";
			maskedtxtCPF.Size = new Size(93, 23);
			maskedtxtCPF.TabIndex = 4;
			// 
			// maskedtxtCNPJ
			// 
			maskedtxtCNPJ.Location = new Point(268, 243);
			maskedtxtCNPJ.Mask = "00\\.000\\.000/0000-00";
			maskedtxtCNPJ.Name = "maskedtxtCNPJ";
			maskedtxtCNPJ.Size = new Size(104, 23);
			maskedtxtCNPJ.TabIndex = 5;
			// 
			// btnGravar
			// 
			btnGravar.DialogResult = DialogResult.OK;
			btnGravar.Location = new Point(268, 552);
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
			btnCancelar.Location = new Point(361, 552);
			btnCancelar.Name = "btnCancelar";
			btnCancelar.Size = new Size(75, 45);
			btnCancelar.TabIndex = 100;
			btnCancelar.Text = "Cancelar";
			btnCancelar.UseVisualStyleBackColor = true;
			// 
			// DialogCliente
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(452, 610);
			Controls.Add(btnCancelar);
			Controls.Add(btnGravar);
			Controls.Add(maskedtxtCNPJ);
			Controls.Add(maskedtxtCPF);
			Controls.Add(numericUpDownNumero);
			Controls.Add(labelId);
			Controls.Add(label12);
			Controls.Add(txtRua);
			Controls.Add(label11);
			Controls.Add(txtBairro);
			Controls.Add(label10);
			Controls.Add(txtCidade);
			Controls.Add(label9);
			Controls.Add(txtEstado);
			Controls.Add(label8);
			Controls.Add(label7);
			Controls.Add(maskedtxtTelefone);
			Controls.Add(label6);
			Controls.Add(radioButtonPessoaJuridica);
			Controls.Add(radioButtonPessoaFisica);
			Controls.Add(label5);
			Controls.Add(label4);
			Controls.Add(txtEmail);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(txtNome);
			Controls.Add(label1);
			Name = "DialogCliente";
			Text = "DialogCliente";
			((System.ComponentModel.ISupportInitialize)numericUpDownNumero).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private TextBox txtNome;
		private Label label2;
		private Label label3;
		private TextBox txtEmail;
		private Label label4;
		private Label label5;
		private RadioButton radioButtonPessoaFisica;
		private RadioButton radioButtonPessoaJuridica;
		private Label label6;
		private MaskedTextBox maskedtxtTelefone;
		private Label label7;
		private Label label8;
		private TextBox txtEstado;
		private Label label9;
		private TextBox txtCidade;
		private Label label10;
		private TextBox txtBairro;
		private Label label11;
		private TextBox txtRua;
		private Label label12;
		private Label labelId;
		private NumericUpDown numericUpDownNumero;
		private MaskedTextBox maskedtxtCPF;
		private MaskedTextBox maskedtxtCNPJ;
		private Button btnGravar;
		private Button btnCancelar;
	}
}