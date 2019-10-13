namespace RentACar.UI
{
    partial class Anasayfa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Anasayfa));
            this.pnlAnasayfa = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvArabaListesi = new System.Windows.Forms.DataGridView();
            this.pnlAnasayfa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArabaListesi)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlAnasayfa
            // 
            this.pnlAnasayfa.Controls.Add(this.label1);
            this.pnlAnasayfa.Controls.Add(this.dgvArabaListesi);
            this.pnlAnasayfa.Location = new System.Drawing.Point(17, 40);
            this.pnlAnasayfa.Name = "pnlAnasayfa";
            this.pnlAnasayfa.Size = new System.Drawing.Size(1008, 475);
            this.pnlAnasayfa.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.OrangeRed;
            this.label1.Location = new System.Drawing.Point(28, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Rent a Car Oto Kiralama";
            // 
            // dgvArabaListesi
            // 
            this.dgvArabaListesi.AllowUserToAddRows = false;
            this.dgvArabaListesi.AllowUserToDeleteRows = false;
            this.dgvArabaListesi.AllowUserToOrderColumns = true;
            this.dgvArabaListesi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvArabaListesi.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvArabaListesi.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvArabaListesi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArabaListesi.GridColor = System.Drawing.SystemColors.Control;
            this.dgvArabaListesi.Location = new System.Drawing.Point(0, 76);
            this.dgvArabaListesi.Name = "dgvArabaListesi";
            this.dgvArabaListesi.ReadOnly = true;
            this.dgvArabaListesi.Size = new System.Drawing.Size(1008, 399);
            this.dgvArabaListesi.TabIndex = 1;
            // 
            // Anasayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1048, 554);
            this.Controls.Add(this.pnlAnasayfa);
            this.DoubleBuffered = true;
            this.Name = "Anasayfa";
            this.Text = "Anasayfa";
            this.pnlAnasayfa.ResumeLayout(false);
            this.pnlAnasayfa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArabaListesi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlAnasayfa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvArabaListesi;
    }
}