namespace Izgled
{
    partial class FormOpen
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
            this.btnStart = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnKomp = new System.Windows.Forms.RadioButton();
            this.rbtnCovek = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.Maroon;
            this.btnStart.Image = global::Izgled.Properties.Resources.white_wall;
            this.btnStart.Location = new System.Drawing.Point(152, 67);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(186, 75);
            this.btnStart.TabIndex = 9;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImage = global::Izgled.Properties.Resources.prviNaPotezu;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox1.Controls.Add(this.rbtnKomp);
            this.groupBox1.Controls.Add(this.rbtnCovek);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(92, 160);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 141);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Prvi na potezu";
            // 
            // rbtnKomp
            // 
            this.rbtnKomp.AutoSize = true;
            this.rbtnKomp.BackgroundImage = global::Izgled.Properties.Resources.pnpKompjuter;
            this.rbtnKomp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rbtnKomp.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnKomp.Location = new System.Drawing.Point(17, 62);
            this.rbtnKomp.Name = "rbtnKomp";
            this.rbtnKomp.Size = new System.Drawing.Size(142, 33);
            this.rbtnKomp.TabIndex = 0;
            this.rbtnKomp.TabStop = true;
            this.rbtnKomp.Text = "Kompjuter";
            this.rbtnKomp.UseVisualStyleBackColor = true;
            // 
            // rbtnCovek
            // 
            this.rbtnCovek.AutoSize = true;
            this.rbtnCovek.BackgroundImage = global::Izgled.Properties.Resources.pnpCovek;
            this.rbtnCovek.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rbtnCovek.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnCovek.Image = global::Izgled.Properties.Resources.pnpCovek;
            this.rbtnCovek.Location = new System.Drawing.Point(185, 62);
            this.rbtnCovek.Name = "rbtnCovek";
            this.rbtnCovek.Size = new System.Drawing.Size(125, 36);
            this.rbtnCovek.TabIndex = 1;
            this.rbtnCovek.TabStop = true;
            this.rbtnCovek.Text = "Covek";
            this.rbtnCovek.UseVisualStyleBackColor = true;
            // 
            // FormOpen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Izgled.Properties.Resources.red;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(518, 388);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormOpen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormOpen";
            this.Load += new System.EventHandler(this.FormOpen_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnCovek;
        private System.Windows.Forms.RadioButton rbtnKomp;
    }
}