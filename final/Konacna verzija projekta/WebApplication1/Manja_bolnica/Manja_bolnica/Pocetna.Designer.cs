namespace Manja_bolnica
{
    partial class Pocetna
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtJMBG = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rbHigijenicar = new System.Windows.Forms.RadioButton();
            this.rbTehnicar = new System.Windows.Forms.RadioButton();
            this.rbStomatolog = new System.Windows.Forms.RadioButton();
            this.rbSpecijalista = new System.Windows.Forms.RadioButton();
            this.rbLekar = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Uneti validan JMBG iz baze";
            // 
            // txtJMBG
            // 
            this.txtJMBG.Location = new System.Drawing.Point(59, 193);
            this.txtJMBG.Name = "txtJMBG";
            this.txtJMBG.Size = new System.Drawing.Size(100, 20);
            this.txtJMBG.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Medicinsko osoblje";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.rbHigijenicar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.rbTehnicar);
            this.groupBox1.Controls.Add(this.rbStomatolog);
            this.groupBox1.Controls.Add(this.rbSpecijalista);
            this.groupBox1.Controls.Add(this.rbLekar);
            this.groupBox1.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(487, 161);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(315, 167);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selektovati odgovarajuci profil";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(140, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nemedicinsko osoblje";
            // 
            // rbHigijenicar
            // 
            this.rbHigijenicar.AutoSize = true;
            this.rbHigijenicar.Location = new System.Drawing.Point(165, 90);
            this.rbHigijenicar.Name = "rbHigijenicar";
            this.rbHigijenicar.Size = new System.Drawing.Size(96, 19);
            this.rbHigijenicar.TabIndex = 4;
            this.rbHigijenicar.TabStop = true;
            this.rbHigijenicar.Text = "Higijenicar";
            this.rbHigijenicar.UseVisualStyleBackColor = true;
            // 
            // rbTehnicar
            // 
            this.rbTehnicar.AutoSize = true;
            this.rbTehnicar.Location = new System.Drawing.Point(165, 65);
            this.rbTehnicar.Name = "rbTehnicar";
            this.rbTehnicar.Size = new System.Drawing.Size(82, 19);
            this.rbTehnicar.TabIndex = 3;
            this.rbTehnicar.TabStop = true;
            this.rbTehnicar.Text = "Tehnicar";
            this.rbTehnicar.UseVisualStyleBackColor = true;
            // 
            // rbStomatolog
            // 
            this.rbStomatolog.AutoSize = true;
            this.rbStomatolog.Location = new System.Drawing.Point(7, 113);
            this.rbStomatolog.Name = "rbStomatolog";
            this.rbStomatolog.Size = new System.Drawing.Size(100, 19);
            this.rbStomatolog.TabIndex = 2;
            this.rbStomatolog.TabStop = true;
            this.rbStomatolog.Text = "Stomatolog";
            this.rbStomatolog.UseVisualStyleBackColor = true;
            // 
            // rbSpecijalista
            // 
            this.rbSpecijalista.AutoSize = true;
            this.rbSpecijalista.Location = new System.Drawing.Point(7, 90);
            this.rbSpecijalista.Name = "rbSpecijalista";
            this.rbSpecijalista.Size = new System.Drawing.Size(102, 19);
            this.rbSpecijalista.TabIndex = 1;
            this.rbSpecijalista.TabStop = true;
            this.rbSpecijalista.Text = "Specijalista";
            this.rbSpecijalista.UseVisualStyleBackColor = true;
            // 
            // rbLekar
            // 
            this.rbLekar.AutoSize = true;
            this.rbLekar.Location = new System.Drawing.Point(6, 67);
            this.rbLekar.Name = "rbLekar";
            this.rbLekar.Size = new System.Drawing.Size(153, 19);
            this.rbLekar.TabIndex = 0;
            this.rbLekar.TabStop = true;
            this.rbLekar.Text = "Lekar opste prakse";
            this.rbLekar.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(59, 251);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 77);
            this.button1.TabIndex = 5;
            this.button1.Text = "Logovanje";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Pocetna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::Manja_bolnica.Properties.Resources.images_cms_image_000004660;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(814, 411);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtJMBG);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Pocetna";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pocetna";
            this.Load += new System.EventHandler(this.Pocetna_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtJMBG;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbHigijenicar;
        private System.Windows.Forms.RadioButton rbTehnicar;
        private System.Windows.Forms.RadioButton rbStomatolog;
        private System.Windows.Forms.RadioButton rbSpecijalista;
        private System.Windows.Forms.RadioButton rbLekar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}