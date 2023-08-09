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
            ((System.ComponentModel.ISupportInitialize)pbImagem).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudLitros).BeginInit();
            SuspendLayout();
            // 
            // txtModelo
            // 
            txtModelo.Location = new Point(136, 244);
            txtModelo.Margin = new Padding(3, 4, 3, 4);
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(375, 27);
            txtModelo.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(66, 244);
            label2.Name = "label2";
            label2.Size = new Size(64, 20);
            label2.TabIndex = 2;
            label2.Text = "Modelo:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(66, 286);
            label3.Name = "label3";
            label3.Size = new Size(53, 20);
            label3.TabIndex = 3;
            label3.Text = "Marca:";
            // 
            // txtMarca
            // 
            txtMarca.Location = new Point(136, 280);
            txtMarca.Margin = new Padding(3, 4, 3, 4);
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(373, 27);
            txtMarca.TabIndex = 2;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(66, 357);
            label8.Name = "label8";
            label8.Size = new Size(35, 20);
            label8.TabIndex = 15;
            label8.Text = "Cor:";
            // 
            // txtCor
            // 
            txtCor.Location = new Point(136, 350);
            txtCor.Margin = new Padding(3, 4, 3, 4);
            txtCor.Name = "txtCor";
            txtCor.Size = new Size(114, 27);
            txtCor.TabIndex = 6;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(44, 451);
            label9.Name = "label9";
            label9.Size = new Size(156, 20);
            label9.TabIndex = 17;
            label9.Text = "Capacidade em Litros:";
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(299, 505);
            btnGravar.Margin = new Padding(3, 4, 3, 4);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(86, 60);
            btnGravar.TabIndex = 99;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(403, 505);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(86, 60);
            btnCancelar.TabIndex = 100;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // txtPlaca
            // 
            txtPlaca.Location = new Point(136, 315);
            txtPlaca.Margin = new Padding(3, 4, 3, 4);
            txtPlaca.Name = "txtPlaca";
            txtPlaca.Size = new Size(114, 27);
            txtPlaca.TabIndex = 101;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(66, 318);
            label1.Name = "label1";
            label1.Size = new Size(47, 20);
            label1.TabIndex = 102;
            label1.Text = "Placa:";
            // 
            // pbImagem
            // 
            pbImagem.Location = new Point(196, 27);
            pbImagem.Name = "pbImagem";
            pbImagem.Size = new Size(189, 138);
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
            btnImagem.Location = new Point(401, 76);
            btnImagem.Name = "btnImagem";
            btnImagem.Size = new Size(94, 29);
            btnImagem.TabIndex = 104;
            btnImagem.Text = "Buscar";
            btnImagem.UseVisualStyleBackColor = true;
            btnImagem.Click += btnImagem_Click;
            // 
            // nudLitros
            // 
            nudLitros.Location = new Point(206, 444);
            nudLitros.Maximum = new decimal(new int[] { 1600, 0, 0, 0 });
            nudLitros.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            nudLitros.Name = "nudLitros";
            nudLitros.Size = new Size(150, 27);
            nudLitros.TabIndex = 105;
            nudLitros.Value = new decimal(new int[] { 5, 0, 0, 0 });
            nudLitros.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // cbGrupo
            // 
            cbGrupo.FormattingEnabled = true;
            cbGrupo.Location = new Point(223, 209);
            cbGrupo.Name = "cbGrupo";
            cbGrupo.Size = new Size(151, 28);
            cbGrupo.TabIndex = 106;
            // 
            // cbTipoCombustivel
            // 
            cbTipoCombustivel.FormattingEnabled = true;
            cbTipoCombustivel.Items.AddRange(new object[] { "Gasolina ", "Etanol", "Diesel", "Etanol & GNV", "Gasolina & GNV", "Total Flex" });
            cbTipoCombustivel.Location = new Point(206, 398);
            cbTipoCombustivel.Name = "cbTipoCombustivel";
            cbTipoCombustivel.Size = new Size(151, 28);
            cbTipoCombustivel.TabIndex = 107;
            cbTipoCombustivel.SelectedIndexChanged += cbTipoCombustivel_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(44, 401);
            label4.Name = "label4";
            label4.Size = new Size(146, 20);
            label4.TabIndex = 108;
            label4.Text = "Tipo de Combustivel";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(63, 212);
            label5.Name = "label5";
            label5.Size = new Size(154, 20);
            label5.TabIndex = 109;
            label5.Text = "Grupo de Automoveis";
            // 
            // DialogAutomovel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(517, 578);
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
            Margin = new Padding(3, 4, 3, 4);
            Name = "DialogAutomovel";
            Text = "DialogAutomovel";
            ((System.ComponentModel.ISupportInitialize)pbImagem).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudLitros).EndInit();
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
    }
}