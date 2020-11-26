namespace Izgled
{
    partial class FormBirajBoju
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
            this.btnKaro = new System.Windows.Forms.Button();
            this.btnTref = new System.Windows.Forms.Button();
            this.btnHerc = new System.Windows.Forms.Button();
            this.btnPik = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Image = global::Izgled.Properties.Resources.crvena3;
            this.label1.Location = new System.Drawing.Point(51, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Izaberite boju ";
            // 
            // btnKaro
            // 
            this.btnKaro.BackgroundImage = global::Izgled.Properties.Resources.karo;
            this.btnKaro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnKaro.Location = new System.Drawing.Point(140, 176);
            this.btnKaro.Name = "btnKaro";
            this.btnKaro.Size = new System.Drawing.Size(75, 72);
            this.btnKaro.TabIndex = 3;
            this.btnKaro.UseVisualStyleBackColor = true;
            this.btnKaro.Click += new System.EventHandler(this.btnKaro_Click);
            // 
            // btnTref
            // 
            this.btnTref.BackgroundImage = global::Izgled.Properties.Resources.tref;
            this.btnTref.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTref.Location = new System.Drawing.Point(39, 176);
            this.btnTref.Name = "btnTref";
            this.btnTref.Size = new System.Drawing.Size(75, 72);
            this.btnTref.TabIndex = 2;
            this.btnTref.UseVisualStyleBackColor = true;
            this.btnTref.Click += new System.EventHandler(this.btnTref_Click);
            // 
            // btnHerc
            // 
            this.btnHerc.BackgroundImage = global::Izgled.Properties.Resources.herc;
            this.btnHerc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHerc.Location = new System.Drawing.Point(140, 85);
            this.btnHerc.Name = "btnHerc";
            this.btnHerc.Size = new System.Drawing.Size(75, 72);
            this.btnHerc.TabIndex = 1;
            this.btnHerc.UseVisualStyleBackColor = true;
            this.btnHerc.Click += new System.EventHandler(this.btnHerc_Click);
            // 
            // btnPik
            // 
            this.btnPik.BackgroundImage = global::Izgled.Properties.Resources.pik;
            this.btnPik.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPik.Location = new System.Drawing.Point(39, 85);
            this.btnPik.Name = "btnPik";
            this.btnPik.Size = new System.Drawing.Size(75, 72);
            this.btnPik.TabIndex = 0;
            this.btnPik.UseVisualStyleBackColor = true;
            this.btnPik.Click += new System.EventHandler(this.btnPik_Click);
            // 
            // btnOk
            // 
            this.btnOk.BackgroundImage = global::Izgled.Properties.Resources.white_wall;
            this.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOk.Location = new System.Drawing.Point(243, 150);
            this.btnOk.Margin = new System.Windows.Forms.Padding(0);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(77, 30);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // FormBirajBoju
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Izgled.Properties.Resources.crvena2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(352, 291);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnKaro);
            this.Controls.Add(this.btnTref);
            this.Controls.Add(this.btnHerc);
            this.Controls.Add(this.btnPik);
            this.DoubleBuffered = true;
            this.Name = "FormBirajBoju";
            this.Opacity = 0.98D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Boja";
            this.Load += new System.EventHandler(this.FormBirajBoju_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPik;
        private System.Windows.Forms.Button btnHerc;
        private System.Windows.Forms.Button btnTref;
        private System.Windows.Forms.Button btnKaro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOk;
    }
}