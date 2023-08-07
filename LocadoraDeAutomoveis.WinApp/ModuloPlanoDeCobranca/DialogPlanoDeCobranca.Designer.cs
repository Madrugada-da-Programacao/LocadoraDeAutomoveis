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
            txtKmDisponiveis = new NumericUpDown();
            txtPrecoKm = new NumericUpDown();
            txtPrecoDiaria = new NumericUpDown();
            label5 = new Label();
            cmbTipoDoPlano = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            btnGravar = new Button();
            btnCancelar = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtKmDisponiveis).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPrecoKm).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPrecoDiaria).BeginInit();
            SuspendLayout();
            // 
            // cmbGrupoAutomoveis
            // 
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
            groupBox1.Controls.Add(txtKmDisponiveis);
            groupBox1.Controls.Add(txtPrecoKm);
            groupBox1.Controls.Add(txtPrecoDiaria);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(cmbTipoDoPlano);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(68, 99);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(345, 209);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Configuração de Planos";
            // 
            // txtKmDisponiveis
            // 
            txtKmDisponiveis.Location = new Point(130, 145);
            txtKmDisponiveis.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            txtKmDisponiveis.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            txtKmDisponiveis.Name = "txtKmDisponiveis";
            txtKmDisponiveis.Size = new Size(188, 23);
            txtKmDisponiveis.TabIndex = 10;
            txtKmDisponiveis.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // txtPrecoKm
            // 
            txtPrecoKm.DecimalPlaces = 2;
            txtPrecoKm.Location = new Point(130, 111);
            txtPrecoKm.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            txtPrecoKm.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            txtPrecoKm.Name = "txtPrecoKm";
            txtPrecoKm.Size = new Size(188, 23);
            txtPrecoKm.TabIndex = 9;
            txtPrecoKm.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // txtPrecoDiaria
            // 
            txtPrecoDiaria.DecimalPlaces = 2;
            txtPrecoDiaria.Location = new Point(130, 76);
            txtPrecoDiaria.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            txtPrecoDiaria.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            txtPrecoDiaria.Name = "txtPrecoDiaria";
            txtPrecoDiaria.Size = new Size(188, 23);
            txtPrecoDiaria.TabIndex = 8;
            txtPrecoDiaria.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(33, 147);
            label5.Name = "label5";
            label5.Size = new Size(91, 15);
            label5.TabIndex = 6;
            label5.Text = "Km Disponíveis:";
            // 
            // cmbTipoDoPlano
            // 
            cmbTipoDoPlano.FormattingEnabled = true;
            cmbTipoDoPlano.Location = new Point(130, 42);
            cmbTipoDoPlano.Name = "cmbTipoDoPlano";
            cmbTipoDoPlano.Size = new Size(188, 23);
            cmbTipoDoPlano.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(42, 114);
            label4.Name = "label4";
            label4.Size = new Size(82, 15);
            label4.TabIndex = 2;
            label4.Text = "Preço por Km:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(51, 79);
            label3.Name = "label3";
            label3.Size = new Size(73, 15);
            label3.TabIndex = 1;
            label3.Text = "Preço Diária:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(41, 45);
            label2.Name = "label2";
            label2.Size = new Size(83, 15);
            label2.TabIndex = 0;
            label2.Text = "Tipo do Plano:";
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
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtKmDisponiveis).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPrecoKm).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPrecoDiaria).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbGrupoAutomoveis;
        private Label label1;
        private GroupBox groupBox1;
        private Label label5;
        private ComboBox cmbTipoDoPlano;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button btnGravar;
        private Button btnCancelar;
        private NumericUpDown txtPrecoDiaria;
        private NumericUpDown txtKmDisponiveis;
        private NumericUpDown txtPrecoKm;
    }
}