namespace Manja_bolnica
{
    partial class OdeljenjeEditBasic
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
            this.label2 = new System.Windows.Forms.Label();
            this.textTip = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dtpDatumIzgradnje = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPacijent = new System.Windows.Forms.TextBox();
            this.dtpPrijem = new System.Windows.Forms.DateTimePicker();
            this.dtpOtpust = new System.Windows.Forms.DateTimePicker();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tip odeljenja";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(176, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Datum izgradnje odeljenja";
            // 
            // textTip
            // 
            this.textTip.Location = new System.Drawing.Point(26, 78);
            this.textTip.Name = "textTip";
            this.textTip.Size = new System.Drawing.Size(100, 20);
            this.textTip.TabIndex = 2;
            this.textTip.TextChanged += new System.EventHandler(this.textTip_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(42, 133);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Snimi";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dtpDatumIzgradnje
            // 
            this.dtpDatumIzgradnje.Location = new System.Drawing.Point(179, 75);
            this.dtpDatumIzgradnje.Name = "dtpDatumIzgradnje";
            this.dtpDatumIzgradnje.Size = new System.Drawing.Size(116, 20);
            this.dtpDatumIzgradnje.TabIndex = 5;
            this.dtpDatumIzgradnje.ValueChanged += new System.EventHandler(this.dtpDatumIzgradnje_ValueChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(179, 133);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Dodaj novo odeljenje";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(436, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Dodavanje pacijenta na odeljenju";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(396, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "JMBG pacijenta: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(407, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Datum prijema:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(407, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Datum otpusta:";
            // 
            // txtPacijent
            // 
            this.txtPacijent.Location = new System.Drawing.Point(515, 67);
            this.txtPacijent.Name = "txtPacijent";
            this.txtPacijent.Size = new System.Drawing.Size(123, 20);
            this.txtPacijent.TabIndex = 11;
            // 
            // dtpPrijem
            // 
            this.dtpPrijem.Location = new System.Drawing.Point(515, 100);
            this.dtpPrijem.Name = "dtpPrijem";
            this.dtpPrijem.Size = new System.Drawing.Size(123, 20);
            this.dtpPrijem.TabIndex = 12;
            // 
            // dtpOtpust
            // 
            this.dtpOtpust.Location = new System.Drawing.Point(515, 135);
            this.dtpOtpust.Name = "dtpOtpust";
            this.dtpOtpust.Size = new System.Drawing.Size(123, 20);
            this.dtpOtpust.TabIndex = 13;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(474, 181);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(141, 40);
            this.button3.TabIndex = 14;
            this.button3.Text = "Dodaj novog pacijenta na odeljenju";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // OdeljenjeEditBasic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(731, 262);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dtpOtpust);
            this.Controls.Add(this.dtpPrijem);
            this.Controls.Add(this.txtPacijent);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dtpDatumIzgradnje);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textTip);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "OdeljenjeEditBasic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Izmena osnovnih informacija o odeljenju";
            this.Load += new System.EventHandler(this.OdeljenjeEditBasic_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textTip;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dtpDatumIzgradnje;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPacijent;
        private System.Windows.Forms.DateTimePicker dtpPrijem;
        private System.Windows.Forms.DateTimePicker dtpOtpust;
        private System.Windows.Forms.Button button3;
    }
}