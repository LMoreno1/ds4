namespace Parcial2
{
    partial class Form1
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
            this.lblLibras = new System.Windows.Forms.Label();
            this.lblKilogramos = new System.Windows.Forms.Label();
            this.txtLibras = new System.Windows.Forms.TextBox();
            this.txtKilogramos = new System.Windows.Forms.TextBox();
            this.btnLibras = new System.Windows.Forms.Button();
            this.btnKilogramos = new System.Windows.Forms.Button();
            this.txtLb = new System.Windows.Forms.TextBox();
            this.txtKg = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblLibras
            // 
            this.lblLibras.AutoSize = true;
            this.lblLibras.Location = new System.Drawing.Point(75, 81);
            this.lblLibras.Name = "lblLibras";
            this.lblLibras.Size = new System.Drawing.Size(147, 20);
            this.lblLibras.TabIndex = 0;
            this.lblLibras.Text = "Libras a Kilogramos";
            // 
            // lblKilogramos
            // 
            this.lblKilogramos.AutoSize = true;
            this.lblKilogramos.Location = new System.Drawing.Point(75, 134);
            this.lblKilogramos.Name = "lblKilogramos";
            this.lblKilogramos.Size = new System.Drawing.Size(147, 20);
            this.lblKilogramos.TabIndex = 1;
            this.lblKilogramos.Text = "Kilogramos a Libras";
            // 
            // txtLibras
            // 
            this.txtLibras.Location = new System.Drawing.Point(283, 81);
            this.txtLibras.Name = "txtLibras";
            this.txtLibras.Size = new System.Drawing.Size(100, 26);
            this.txtLibras.TabIndex = 2;
            this.txtLibras.TextChanged += new System.EventHandler(this.txtLibras_TextChanged);
            // 
            // txtKilogramos
            // 
            this.txtKilogramos.Location = new System.Drawing.Point(283, 128);
            this.txtKilogramos.Name = "txtKilogramos";
            this.txtKilogramos.Size = new System.Drawing.Size(100, 26);
            this.txtKilogramos.TabIndex = 3;
            this.txtKilogramos.TextChanged += new System.EventHandler(this.txtKilogramos_TextChanged);
            // 
            // btnLibras
            // 
            this.btnLibras.Location = new System.Drawing.Point(441, 69);
            this.btnLibras.Name = "btnLibras";
            this.btnLibras.Size = new System.Drawing.Size(75, 38);
            this.btnLibras.TabIndex = 4;
            this.btnLibras.Text = "->";
            this.btnLibras.UseVisualStyleBackColor = true;
            this.btnLibras.Click += new System.EventHandler(this.btnLibras_Click);
            // 
            // btnKilogramos
            // 
            this.btnKilogramos.Location = new System.Drawing.Point(441, 116);
            this.btnKilogramos.Name = "btnKilogramos";
            this.btnKilogramos.Size = new System.Drawing.Size(75, 38);
            this.btnKilogramos.TabIndex = 5;
            this.btnKilogramos.Text = "->";
            this.btnKilogramos.UseVisualStyleBackColor = true;
            this.btnKilogramos.Click += new System.EventHandler(this.btnKilogramos_Click);
            // 
            // txtLb
            // 
            this.txtLb.Location = new System.Drawing.Point(588, 81);
            this.txtLb.Name = "txtLb";
            this.txtLb.Size = new System.Drawing.Size(100, 26);
            this.txtLb.TabIndex = 6;
            this.txtLb.TextChanged += new System.EventHandler(this.txtLb_TextChanged);
            // 
            // txtKg
            // 
            this.txtKg.Location = new System.Drawing.Point(588, 128);
            this.txtKg.Name = "txtKg";
            this.txtKg.Size = new System.Drawing.Size(100, 26);
            this.txtKg.TabIndex = 7;
            this.txtKg.TextChanged += new System.EventHandler(this.txtKg_TextChanged);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(79, 205);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(617, 84);
            this.listBox1.TabIndex = 8;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 348);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.txtKg);
            this.Controls.Add(this.txtLb);
            this.Controls.Add(this.btnKilogramos);
            this.Controls.Add(this.btnLibras);
            this.Controls.Add(this.txtKilogramos);
            this.Controls.Add(this.txtLibras);
            this.Controls.Add(this.lblKilogramos);
            this.Controls.Add(this.lblLibras);
            this.Name = "Form1";
            this.Text = "Conversor Numérico";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLibras;
        private System.Windows.Forms.Label lblKilogramos;
        private System.Windows.Forms.TextBox txtLibras;
        private System.Windows.Forms.TextBox txtKilogramos;
        private System.Windows.Forms.Button btnLibras;
        private System.Windows.Forms.Button btnKilogramos;
        private System.Windows.Forms.TextBox txtLb;
        private System.Windows.Forms.TextBox txtKg;
        private System.Windows.Forms.ListBox listBox1;
    }
}

