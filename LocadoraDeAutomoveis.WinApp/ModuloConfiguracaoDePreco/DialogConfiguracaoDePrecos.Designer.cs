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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnGravar = new Button();
            btnCancelar = new Button();
            txtGasolina = new NumericUpDown();
            txtGas = new NumericUpDown();
            txtDiesel = new NumericUpDown();
            txtAlcool = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)txtGasolina).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtGas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtDiesel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtAlcool).BeginInit();
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(49, 84);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 2;
            label2.Text = "Gás:";
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
            // txtGasolina
            // 
            txtGasolina.DecimalPlaces = 2;
            txtGasolina.Location = new Point(87, 47);
            txtGasolina.Maximum = new decimal(new int[] { 1316134911, 2328, 0, 0 });
            txtGasolina.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            txtGasolina.Name = "txtGasolina";
            txtGasolina.Size = new Size(264, 23);
            txtGasolina.TabIndex = 103;
            txtGasolina.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // txtGas
            // 
            txtGas.DecimalPlaces = 2;
            txtGas.Location = new Point(87, 82);
            txtGas.Maximum = new decimal(new int[] { 1316134911, 2328, 0, 0 });
            txtGas.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            txtGas.Name = "txtGas";
            txtGas.Size = new Size(264, 23);
            txtGas.TabIndex = 104;
            txtGas.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // txtDiesel
            // 
            txtDiesel.DecimalPlaces = 2;
            txtDiesel.Location = new Point(87, 119);
            txtDiesel.Maximum = new decimal(new int[] { 1316134911, 2328, 0, 0 });
            txtDiesel.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            txtDiesel.Name = "txtDiesel";
            txtDiesel.Size = new Size(264, 23);
            txtDiesel.TabIndex = 105;
            txtDiesel.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // txtAlcool
            // 
            txtAlcool.DecimalPlaces = 2;
            txtAlcool.Location = new Point(87, 157);
            txtAlcool.Maximum = new decimal(new int[] { 1316134911, 2328, 0, 0 });
            txtAlcool.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            txtAlcool.Name = "txtAlcool";
            txtAlcool.Size = new Size(264, 23);
            txtAlcool.TabIndex = 106;
            txtAlcool.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // DialogConfiguracaoDePrecos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(398, 256);
            Controls.Add(txtAlcool);
            Controls.Add(txtDiesel);
            Controls.Add(txtGas);
            Controls.Add(txtGasolina);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "DialogConfiguracaoDePrecos";
            Text = "Configuração de Preços";
            ((System.ComponentModel.ISupportInitialize)txtGasolina).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtGas).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtDiesel).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtAlcool).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnGravar;
        private Button btnCancelar;
        private NumericUpDown txtGasolina;
        private NumericUpDown txtGas;
        private NumericUpDown txtDiesel;
        private NumericUpDown txtAlcool;
    }
}