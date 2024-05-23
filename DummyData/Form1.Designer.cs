namespace DummyData
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.numRegistros = new System.Windows.Forms.NumericUpDown();
            this.cbFormato = new System.Windows.Forms.ComboBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numRegistros)).BeginInit();
            this.SuspendLayout();
            // 
            // numRegistros
            // 
            this.numRegistros.Location = new System.Drawing.Point(12, 12);
            this.numRegistros.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.numRegistros.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRegistros.Name = "numRegistros";
            this.numRegistros.Size = new System.Drawing.Size(120, 20);
            this.numRegistros.TabIndex = 0;
            this.numRegistros.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbFormato
            // 
            this.cbFormato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFormato.FormattingEnabled = true;
            this.cbFormato.Items.AddRange(new object[] {
            "SQL",
            "CSV",
            "XML",
            "JSON"});
            this.cbFormato.Location = new System.Drawing.Point(12, 38);
            this.cbFormato.Name = "cbFormato";
            this.cbFormato.Size = new System.Drawing.Size(120, 21);
            this.cbFormato.TabIndex = 1;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(12, 65);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(120, 23);
            this.btnGenerar.TabIndex = 2;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(284, 101);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.cbFormato);
            this.Controls.Add(this.numRegistros);
            this.Name = "Form1";
            this.Text = "Generador de Datos Ficticios";
            ((System.ComponentModel.ISupportInitialize)(this.numRegistros)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.NumericUpDown numRegistros;
        private System.Windows.Forms.ComboBox cbFormato;
        private System.Windows.Forms.Button btnGenerar;
    }
}

