namespace LocadoraDeAutomoveis.WinApp.ModuloCondutor
{
    partial class DialogCondutor
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
            cmbCliente = new ComboBox();
            cbClienteEhCondutor = new CheckBox();
            label2 = new Label();
            txtNome = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtCpf = new MaskedTextBox();
            label6 = new Label();
            label7 = new Label();
            txtValidade = new DateTimePicker();
            btnGravar = new Button();
            btnCancelar = new Button();
            txtTelefone = new MaskedTextBox();
            txtEmail = new TextBox();
            txtCnh = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)txtCnh).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 44);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 0;
            label1.Text = "Cliente:";
            // 
            // cmbCliente
            // 
            cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(79, 41);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(299, 23);
            cmbCliente.TabIndex = 1;
            cmbCliente.SelectedIndexChanged += cmbCliente_SelectedIndexChanged;
            // 
            // cbClienteEhCondutor
            // 
            cbClienteEhCondutor.AutoSize = true;
            cbClienteEhCondutor.Location = new Point(79, 70);
            cbClienteEhCondutor.Name = "cbClienteEhCondutor";
            cbClienteEhCondutor.Size = new Size(144, 19);
            cbClienteEhCondutor.TabIndex = 2;
            cbClienteEhCondutor.Text = "O cliente é o condutor";
            cbClienteEhCondutor.UseVisualStyleBackColor = true;
            cbClienteEhCondutor.CheckedChanged += cbClienteEhCondutor_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 105);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 3;
            label2.Text = "Nome:";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(75, 102);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(303, 23);
            txtNome.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 134);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 5;
            label3.Text = "Email:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 163);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 7;
            label4.Text = "Telefone:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(32, 192);
            label5.Name = "label5";
            label5.Size = new Size(36, 15);
            label5.TabIndex = 12;
            label5.Text = "CNH:";
            // 
            // txtCpf
            // 
            txtCpf.Location = new Point(264, 160);
            txtCpf.Mask = "000\\.000\\.000-00";
            txtCpf.Name = "txtCpf";
            txtCpf.Size = new Size(114, 23);
            txtCpf.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(225, 163);
            label6.Name = "label6";
            label6.Size = new Size(31, 15);
            label6.TabIndex = 14;
            label6.Text = "CPF:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(15, 224);
            label7.Name = "label7";
            label7.Size = new Size(54, 15);
            label7.TabIndex = 16;
            label7.Text = "Validade:";
            // 
            // txtValidade
            // 
            txtValidade.Format = DateTimePickerFormat.Short;
            txtValidade.Location = new Point(75, 218);
            txtValidade.Name = "txtValidade";
            txtValidade.Size = new Size(114, 23);
            txtValidade.TabIndex = 17;
            // 
            // btnGravar
            // 
            btnGravar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(239, 268);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 45);
            btnGravar.TabIndex = 100;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(320, 268);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 45);
            btnCancelar.TabIndex = 101;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // txtTelefone
            // 
            txtTelefone.Location = new Point(75, 160);
            txtTelefone.Mask = "(00) 0 0000-0000";
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(114, 23);
            txtTelefone.TabIndex = 102;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(74, 131);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(304, 23);
            txtEmail.TabIndex = 103;
            // 
            // txtCnh
            // 
            txtCnh.Location = new Point(74, 189);
            txtCnh.Maximum = new decimal(new int[] { -727379969, 232, 0, 0 });
            txtCnh.Name = "txtCnh";
            txtCnh.Size = new Size(115, 23);
            txtCnh.TabIndex = 104;
            // 
            // DialogCondutor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(407, 325);
            Controls.Add(txtCnh);
            Controls.Add(txtEmail);
            Controls.Add(txtTelefone);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(txtValidade);
            Controls.Add(label7);
            Controls.Add(txtCpf);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtNome);
            Controls.Add(label2);
            Controls.Add(cbClienteEhCondutor);
            Controls.Add(cmbCliente);
            Controls.Add(label1);
            Name = "DialogCondutor";
            ShowIcon = false;
            Text = "Cadastro de Condutor";
            ((System.ComponentModel.ISupportInitialize)txtCnh).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbCliente;
        private CheckBox cbClienteEhCondutor;
        private Label label2;
        private TextBox txtNome;
        private Label label3;
        private Label label4;
        private Label label5;
        private MaskedTextBox txtCpf;
        private Label label6;
        private Label label7;
        private DateTimePicker txtValidade;
        private Button btnGravar;
        private Button btnCancelar;
        private MaskedTextBox txtTelefone;
        private TextBox txtEmail;
        private NumericUpDown txtCnh;
    }
}