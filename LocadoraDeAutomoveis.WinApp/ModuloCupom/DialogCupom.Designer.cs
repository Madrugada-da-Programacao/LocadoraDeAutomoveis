namespace LocadoraDeAutomoveis.WinApp.ModuloCupom
{
	partial class DialogCupom
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
			label2 = new Label();
			txtNome = new TextBox();
			label1 = new Label();
			numericUpDownPreco = new NumericUpDown();
			dateTimePickerDataDeValidade = new DateTimePicker();
			label3 = new Label();
			label4 = new Label();
			comboBoxParceiro = new ComboBox();
			btnGravar = new Button();
			button1 = new Button();
			((System.ComponentModel.ISupportInitialize)numericUpDownPreco).BeginInit();
			SuspendLayout();
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(66, 34);
			label2.Name = "label2";
			label2.Size = new Size(43, 15);
			label2.TabIndex = 3;
			label2.Text = "Nome:";
			// 
			// txtNome
			// 
			txtNome.Location = new Point(115, 26);
			txtNome.Name = "txtNome";
			txtNome.Size = new Size(329, 23);
			txtNome.TabIndex = 0;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(69, 99);
			label1.Name = "label1";
			label1.Size = new Size(40, 15);
			label1.TabIndex = 5;
			label1.Text = "Preço:";
			// 
			// numericUpDownPreco
			// 
			numericUpDownPreco.DecimalPlaces = 2;
			numericUpDownPreco.Location = new Point(115, 97);
			numericUpDownPreco.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
			numericUpDownPreco.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
			numericUpDownPreco.Name = "numericUpDownPreco";
			numericUpDownPreco.Size = new Size(139, 23);
			numericUpDownPreco.TabIndex = 6;
			numericUpDownPreco.Value = new decimal(new int[] { 1, 0, 0, 131072 });
			// 
			// dateTimePickerDataDeValidade
			// 
			dateTimePickerDataDeValidade.Format = DateTimePickerFormat.Short;
			dateTimePickerDataDeValidade.Location = new Point(115, 152);
			dateTimePickerDataDeValidade.Name = "dateTimePickerDataDeValidade";
			dateTimePickerDataDeValidade.Size = new Size(107, 23);
			dateTimePickerDataDeValidade.TabIndex = 2;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(12, 158);
			label3.Name = "label3";
			label3.Size = new Size(97, 15);
			label3.TabIndex = 9;
			label3.Text = "Data de Validade:";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(56, 220);
			label4.Name = "label4";
			label4.Size = new Size(53, 15);
			label4.TabIndex = 10;
			label4.Text = "Parceiro:";
			// 
			// comboBoxParceiro
			// 
			comboBoxParceiro.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBoxParceiro.FormattingEnabled = true;
			comboBoxParceiro.Location = new Point(115, 217);
			comboBoxParceiro.Name = "comboBoxParceiro";
			comboBoxParceiro.Size = new Size(329, 23);
			comboBoxParceiro.TabIndex = 3;
			// 
			// btnGravar
			// 
			btnGravar.DialogResult = DialogResult.OK;
			btnGravar.Location = new Point(288, 286);
			btnGravar.Name = "btnGravar";
			btnGravar.Size = new Size(75, 45);
			btnGravar.TabIndex = 100;
			btnGravar.Text = "Gravar";
			btnGravar.UseVisualStyleBackColor = true;
			btnGravar.Click += btnGravar_Click;
			// 
			// button1
			// 
			button1.DialogResult = DialogResult.Cancel;
			button1.Location = new Point(369, 286);
			button1.Name = "button1";
			button1.Size = new Size(75, 45);
			button1.TabIndex = 101;
			button1.Text = "Cancelar";
			button1.UseVisualStyleBackColor = true;
			// 
			// DialogCupom
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(470, 348);
			Controls.Add(button1);
			Controls.Add(btnGravar);
			Controls.Add(comboBoxParceiro);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(dateTimePickerDataDeValidade);
			Controls.Add(numericUpDownPreco);
			Controls.Add(label1);
			Controls.Add(txtNome);
			Controls.Add(label2);
			Name = "DialogCupom";
			Text = "DialogCupom";
			((System.ComponentModel.ISupportInitialize)numericUpDownPreco).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label2;
		private TextBox txtNome;
		private Label label1;
		private NumericUpDown numericUpDownPreco;
		private DateTimePicker dateTimePickerDataDeValidade;
		private Label label3;
		private Label label4;
		private ComboBox comboBoxParceiro;
		private Button btnGravar;
		private Button button1;
	}
}