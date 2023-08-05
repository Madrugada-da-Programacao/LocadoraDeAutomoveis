namespace LocadoraDeAutomoveis.WinApp.ModuloFuncionario
{
    partial class DialogFuncionario
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
            dtpAdmissao = new Label();
            txtAdmissao = new DateTimePicker();
            label2 = new Label();
            txtSalario = new NumericUpDown();
            btnGravar = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)txtSalario).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(60, 55);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 0;
            label1.Text = "Nome:";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(109, 52);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(200, 23);
            txtNome.TabIndex = 1;
            // 
            // dtpAdmissao
            // 
            dtpAdmissao.Location = new Point(33, 80);
            dtpAdmissao.Name = "dtpAdmissao";
            dtpAdmissao.RightToLeft = RightToLeft.No;
            dtpAdmissao.Size = new Size(70, 36);
            dtpAdmissao.TabIndex = 2;
            dtpAdmissao.Text = "Data de Admissão:";
            dtpAdmissao.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtAdmissao
            // 
            txtAdmissao.Format = DateTimePickerFormat.Short;
            txtAdmissao.Location = new Point(109, 88);
            txtAdmissao.Name = "txtAdmissao";
            txtAdmissao.Size = new Size(107, 23);
            txtAdmissao.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(58, 123);
            label2.Name = "label2";
            label2.Size = new Size(45, 15);
            label2.TabIndex = 4;
            label2.Text = "Salário:";
            // 
            // txtSalario
            // 
            txtSalario.Location = new Point(109, 121);
            txtSalario.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            txtSalario.Name = "txtSalario";
            txtSalario.Size = new Size(107, 23);
            txtSalario.TabIndex = 5;
            txtSalario.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(234, 181);
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
            btnCancelar.Location = new Point(315, 181);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 45);
            btnCancelar.TabIndex = 101;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // DialogFuncionario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(401, 237);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(txtSalario);
            Controls.Add(label2);
            Controls.Add(txtAdmissao);
            Controls.Add(dtpAdmissao);
            Controls.Add(txtNome);
            Controls.Add(label1);
            Name = "DialogFuncionario";
            Text = "Cadastro de Funcionario";
            ((System.ComponentModel.ISupportInitialize)txtSalario).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNome;
        private Label dtpAdmissao;
        private DateTimePicker txtAdmissao;
        private Label label2;
        private NumericUpDown txtSalario;
        private Button btnGravar;
        private Button btnCancelar;
    }
}