namespace LocadoraDeAutomoveis.WinApp.ModuloParceiro
{
	partial class DialogParceiro
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
			btnGravar = new Button();
			btnCancelar = new Button();
			SuspendLayout();
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(12, 32);
			label2.Name = "label2";
			label2.Size = new Size(43, 15);
			label2.TabIndex = 3;
			label2.Text = "Nome:";
			// 
			// txtNome
			// 
			txtNome.Location = new Point(61, 29);
			txtNome.Name = "txtNome";
			txtNome.Size = new Size(311, 23);
			txtNome.TabIndex = 4;
			// 
			// btnGravar
			// 
			btnGravar.DialogResult = DialogResult.OK;
			btnGravar.Location = new Point(216, 84);
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
			btnCancelar.Location = new Point(297, 84);
			btnCancelar.Name = "btnCancelar";
			btnCancelar.Size = new Size(75, 45);
			btnCancelar.TabIndex = 101;
			btnCancelar.Text = "Cancelar";
			btnCancelar.UseVisualStyleBackColor = true;
			// 
			// DialogParceiro
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(391, 144);
			Controls.Add(btnCancelar);
			Controls.Add(btnGravar);
			Controls.Add(txtNome);
			Controls.Add(label2);
			Name = "DialogParceiro";
			Text = "DialogParceiro";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label2;
		private TextBox txtNome;
		private Button btnGravar;
		private Button btnCancelar;
	}
}