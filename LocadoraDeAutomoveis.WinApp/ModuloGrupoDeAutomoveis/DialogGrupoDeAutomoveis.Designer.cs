namespace LocadoraDeAutomoveis.WinApp.ModuloGrupoDeAutomoveis
{
	partial class DialogGrupoDeAutomoveis
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
			txtNome = new TextBox();
			label2 = new Label();
			btnGravar = new Button();
			btnCancelar = new Button();
			SuspendLayout();
			// 
			// txtNome
			// 
			txtNome.Location = new Point(88, 61);
			txtNome.Name = "txtNome";
			txtNome.Size = new Size(329, 23);
			txtNome.TabIndex = 1;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(36, 63);
			label2.Name = "label2";
			label2.Size = new Size(43, 15);
			label2.TabIndex = 2;
			label2.Text = "Nome:";
			// 
			// btnGravar
			// 
			btnGravar.DialogResult = DialogResult.OK;
			btnGravar.Location = new Point(262, 146);
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
			btnCancelar.Location = new Point(360, 146);
			btnCancelar.Name = "btnCancelar";
			btnCancelar.Size = new Size(75, 45);
			btnCancelar.TabIndex = 100;
			btnCancelar.Text = "Cancelar";
			btnCancelar.UseVisualStyleBackColor = true;
			// 
			// DialogGrupoDeAutomoveis
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(452, 200);
			Controls.Add(btnCancelar);
			Controls.Add(btnGravar);
			Controls.Add(label2);
			Controls.Add(txtNome);
			Name = "DialogGrupoDeAutomoveis";
			Text = "DialogGrupoDeAutomoveis";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private TextBox txtNome;
		private Label label2;
		private Button btnGravar;
		private Button btnCancelar;
	}
}