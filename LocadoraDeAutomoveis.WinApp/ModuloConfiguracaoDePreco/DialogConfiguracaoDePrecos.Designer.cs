namespace LocadoraDeAutomoveis.WinApp.ModuloConfiguracaoDePreco
{
    partial class DialogConfiguracaoDePrecos
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
            txtGasolina = new TextBox();
            label2 = new Label();
            txtGas = new TextBox();
            label3 = new Label();
            txtDiesel = new TextBox();
            txtAlcool = new TextBox();
            label4 = new Label();
            btnGravar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 49);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 0;
            label1.Text = "Gasolina:";
            // 
            // txtGasolina
            // 
            txtGasolina.Location = new Point(84, 46);
            txtGasolina.Name = "txtGasolina";
            txtGasolina.Size = new Size(267, 23);
            txtGasolina.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(49, 84);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 2;
            label2.Text = "Gás:";
            // 
            // txtGas
            // 
            txtGas.Location = new Point(84, 81);
            txtGas.Name = "txtGas";
            txtGas.Size = new Size(267, 23);
            txtGas.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(37, 121);
            label3.Name = "label3";
            label3.Size = new Size(41, 15);
            label3.TabIndex = 4;
            label3.Text = "Diesel:";
            // 
            // txtDiesel
            // 
            txtDiesel.Location = new Point(84, 118);
            txtDiesel.Name = "txtDiesel";
            txtDiesel.Size = new Size(267, 23);
            txtDiesel.TabIndex = 5;
            // 
            // txtAlcool
            // 
            txtAlcool.Location = new Point(84, 156);
            txtAlcool.Name = "txtAlcool";
            txtAlcool.Size = new Size(267, 23);
            txtAlcool.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(34, 159);
            label4.Name = "label4";
            label4.Size = new Size(44, 15);
            label4.TabIndex = 7;
            label4.Text = "Álcool:";
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(211, 199);
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
            btnCancelar.Location = new Point(292, 199);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 45);
            btnCancelar.TabIndex = 102;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // DialogConfiguracaoDePrecos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(398, 256);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(label4);
            Controls.Add(txtAlcool);
            Controls.Add(txtDiesel);
            Controls.Add(label3);
            Controls.Add(txtGas);
            Controls.Add(label2);
            Controls.Add(txtGasolina);
            Controls.Add(label1);
            Name = "DialogConfiguracaoDePrecos";
            Text = "Configuração de Preços";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtGasolina;
        private Label label2;
        private TextBox txtGas;
        private Label label3;
        private TextBox txtDiesel;
        private TextBox txtAlcool;
        private Label label4;
        private Button btnGravar;
        private Button btnCancelar;
    }
}