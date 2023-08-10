namespace LocadoraDeAutomoveis.WinApp.ModuloAluguel
{
    partial class DialogAluguel
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
            btnCancelar = new Button();
            btnGravar = new Button();
            label1 = new Label();
            label2 = new Label();
            cmbFuncionario = new ComboBox();
            cmbCliente = new ComboBox();
            cmbGrupoAutomoveis = new ComboBox();
            label3 = new Label();
            cmbPlanoCobranca = new ComboBox();
            label4 = new Label();
            cmbCondutor = new ComboBox();
            label5 = new Label();
            cmbAutomovel = new ComboBox();
            label6 = new Label();
            label7 = new Label();
            txtDataLocacao = new DateTimePicker();
            cmbCupom = new ComboBox();
            label8 = new Label();
            txtDataDevolucaoPrevista = new DateTimePicker();
            label9 = new Label();
            label10 = new Label();
            txtKmAutomovel = new NumericUpDown();
            btnCupom = new Button();
            label11 = new Label();
            lblValorTotal = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            listTaxas = new CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)txtKmAutomovel).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(597, 449);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 45);
            btnCancelar.TabIndex = 102;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(498, 449);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 45);
            btnGravar.TabIndex = 101;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(81, 26);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 103;
            label1.Text = "Funcionario:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(107, 55);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 104;
            label2.Text = "Cliente:";
            // 
            // cmbFuncionario
            // 
            cmbFuncionario.FormattingEnabled = true;
            cmbFuncionario.Location = new Point(160, 23);
            cmbFuncionario.Name = "cmbFuncionario";
            cmbFuncionario.Size = new Size(193, 23);
            cmbFuncionario.TabIndex = 105;
            // 
            // cmbCliente
            // 
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(160, 52);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(193, 23);
            cmbCliente.TabIndex = 106;
            // 
            // cmbGrupoAutomoveis
            // 
            cmbGrupoAutomoveis.FormattingEnabled = true;
            cmbGrupoAutomoveis.Location = new Point(160, 81);
            cmbGrupoAutomoveis.Name = "cmbGrupoAutomoveis";
            cmbGrupoAutomoveis.Size = new Size(193, 23);
            cmbGrupoAutomoveis.TabIndex = 108;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 84);
            label3.Name = "label3";
            label3.Size = new Size(126, 15);
            label3.TabIndex = 107;
            label3.Text = "Grupo de Automóveis:";
            // 
            // cmbPlanoCobranca
            // 
            cmbPlanoCobranca.FormattingEnabled = true;
            cmbPlanoCobranca.Location = new Point(160, 110);
            cmbPlanoCobranca.Name = "cmbPlanoCobranca";
            cmbPlanoCobranca.Size = new Size(193, 23);
            cmbPlanoCobranca.TabIndex = 110;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(44, 113);
            label4.Name = "label4";
            label4.Size = new Size(110, 15);
            label4.TabIndex = 109;
            label4.Text = "Plano de Cobrança:";
            // 
            // cmbCondutor
            // 
            cmbCondutor.FormattingEnabled = true;
            cmbCondutor.Location = new Point(477, 52);
            cmbCondutor.Name = "cmbCondutor";
            cmbCondutor.Size = new Size(193, 23);
            cmbCondutor.TabIndex = 112;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(410, 55);
            label5.Name = "label5";
            label5.Size = new Size(61, 15);
            label5.TabIndex = 111;
            label5.Text = "Condutor:";
            // 
            // cmbAutomovel
            // 
            cmbAutomovel.FormattingEnabled = true;
            cmbAutomovel.Location = new Point(477, 81);
            cmbAutomovel.Name = "cmbAutomovel";
            cmbAutomovel.Size = new Size(193, 23);
            cmbAutomovel.TabIndex = 114;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(402, 84);
            label6.Name = "label6";
            label6.Size = new Size(69, 15);
            label6.TabIndex = 113;
            label6.Text = "Automóvel:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(73, 142);
            label7.Name = "label7";
            label7.Size = new Size(81, 15);
            label7.TabIndex = 115;
            label7.Text = "Data Locação:";
            // 
            // txtDataLocacao
            // 
            txtDataLocacao.Format = DateTimePickerFormat.Short;
            txtDataLocacao.Location = new Point(160, 139);
            txtDataLocacao.Name = "txtDataLocacao";
            txtDataLocacao.Size = new Size(193, 23);
            txtDataLocacao.TabIndex = 116;
            // 
            // cmbCupom
            // 
            cmbCupom.FormattingEnabled = true;
            cmbCupom.Location = new Point(161, 185);
            cmbCupom.Name = "cmbCupom";
            cmbCupom.Size = new Size(135, 23);
            cmbCupom.TabIndex = 118;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(108, 188);
            label8.Name = "label8";
            label8.Size = new Size(50, 15);
            label8.TabIndex = 117;
            label8.Text = "Cupom:";
            // 
            // txtDataDevolucaoPrevista
            // 
            txtDataDevolucaoPrevista.Format = DateTimePickerFormat.Short;
            txtDataDevolucaoPrevista.Location = new Point(477, 139);
            txtDataDevolucaoPrevista.Name = "txtDataDevolucaoPrevista";
            txtDataDevolucaoPrevista.Size = new Size(193, 23);
            txtDataDevolucaoPrevista.TabIndex = 120;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(361, 142);
            label9.Name = "label9";
            label9.Size = new Size(110, 15);
            label9.TabIndex = 119;
            label9.Text = "Devolução Prevista:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(364, 113);
            label10.Name = "label10";
            label10.Size = new Size(107, 15);
            label10.TabIndex = 121;
            label10.Text = "Km do Automóvel:";
            // 
            // txtKmAutomovel
            // 
            txtKmAutomovel.Location = new Point(477, 110);
            txtKmAutomovel.Name = "txtKmAutomovel";
            txtKmAutomovel.ReadOnly = true;
            txtKmAutomovel.Size = new Size(193, 23);
            txtKmAutomovel.TabIndex = 122;
            // 
            // btnCupom
            // 
            btnCupom.Location = new Point(302, 177);
            btnCupom.Name = "btnCupom";
            btnCupom.Size = new Size(100, 37);
            btnCupom.TabIndex = 125;
            btnCupom.Text = "Aplicar Cupom";
            btnCupom.UseVisualStyleBackColor = true;
            btnCupom.Click += btnCupom_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(28, 453);
            label11.Name = "label11";
            label11.Size = new Size(183, 28);
            label11.TabIndex = 126;
            label11.Text = "Valor Total Previsto:";
            // 
            // lblValorTotal
            // 
            lblValorTotal.AutoSize = true;
            lblValorTotal.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            lblValorTotal.Location = new Point(217, 453);
            lblValorTotal.Name = "lblValorTotal";
            lblValorTotal.Size = new Size(23, 28);
            lblValorTotal.TabIndex = 127;
            lblValorTotal.Text = "0";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Location = new Point(17, 214);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(656, 226);
            tabControl1.TabIndex = 128;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(listTaxas);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(648, 198);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Taxas Selecionadas";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // listTaxas
            // 
            listTaxas.FormattingEnabled = true;
            listTaxas.Location = new Point(6, 6);
            listTaxas.Name = "listTaxas";
            listTaxas.Size = new Size(630, 184);
            listTaxas.TabIndex = 123;
            // 
            // DialogAluguel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 506);
            Controls.Add(tabControl1);
            Controls.Add(lblValorTotal);
            Controls.Add(label11);
            Controls.Add(btnCupom);
            Controls.Add(txtKmAutomovel);
            Controls.Add(label10);
            Controls.Add(txtDataDevolucaoPrevista);
            Controls.Add(label9);
            Controls.Add(cmbCupom);
            Controls.Add(label8);
            Controls.Add(txtDataLocacao);
            Controls.Add(label7);
            Controls.Add(cmbAutomovel);
            Controls.Add(label6);
            Controls.Add(cmbCondutor);
            Controls.Add(label5);
            Controls.Add(cmbPlanoCobranca);
            Controls.Add(label4);
            Controls.Add(cmbGrupoAutomoveis);
            Controls.Add(label3);
            Controls.Add(cmbCliente);
            Controls.Add(cmbFuncionario);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Name = "DialogAluguel";
            ShowIcon = false;
            Text = "Cadastro de Aluguel";
            ((System.ComponentModel.ISupportInitialize)txtKmAutomovel).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Button btnGravar;
        private Label label1;
        private Label label2;
        private ComboBox cmbFuncionario;
        private ComboBox cmbCliente;
        private ComboBox cmbGrupoAutomoveis;
        private Label label3;
        private ComboBox cmbPlanoCobranca;
        private Label label4;
        private ComboBox cmbCondutor;
        private Label label5;
        private ComboBox cmbAutomovel;
        private Label label6;
        private Label label7;
        private DateTimePicker txtDataLocacao;
        private ComboBox cmbCupom;
        private Label label8;
        private DateTimePicker txtDataDevolucaoPrevista;
        private Label label9;
        private Label label10;
        private NumericUpDown txtKmAutomovel;
        private Button btnCupom;
        private Label label11;
        private Label lblValorTotal;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private CheckedListBox listTaxas;
    }
}