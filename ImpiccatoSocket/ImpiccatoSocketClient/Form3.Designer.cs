
namespace ImpiccatoSocketClient
{
    partial class Form3
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
            this.lbl_scrivi = new System.Windows.Forms.Label();
            this.btn_scrivi = new System.Windows.Forms.Button();
            this.txtWord = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_lunghezza1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_scrivi
            // 
            this.lbl_scrivi.AutoSize = true;
            this.lbl_scrivi.Location = new System.Drawing.Point(16, 25);
            this.lbl_scrivi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_scrivi.Name = "lbl_scrivi";
            this.lbl_scrivi.Size = new System.Drawing.Size(118, 17);
            this.lbl_scrivi.TabIndex = 0;
            this.lbl_scrivi.Text = "Scrivi una parola:";
            // 
            // btn_scrivi
            // 
            this.btn_scrivi.BackColor = System.Drawing.Color.Orange;
            this.btn_scrivi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_scrivi.Location = new System.Drawing.Point(16, 145);
            this.btn_scrivi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_scrivi.Name = "btn_scrivi";
            this.btn_scrivi.Size = new System.Drawing.Size(100, 28);
            this.btn_scrivi.TabIndex = 1;
            this.btn_scrivi.Text = "Invia";
            this.btn_scrivi.UseVisualStyleBackColor = false;
            this.btn_scrivi.Click += new System.EventHandler(this.btn_scrivi_Click);
            // 
            // txtWord
            // 
            this.txtWord.Location = new System.Drawing.Point(16, 58);
            this.txtWord.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtWord.Name = "txtWord";
            this.txtWord.Size = new System.Drawing.Size(259, 22);
            this.txtWord.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 102);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "N. lettere:";
            // 
            // lbl_lunghezza1
            // 
            this.lbl_lunghezza1.AutoSize = true;
            this.lbl_lunghezza1.Location = new System.Drawing.Point(95, 102);
            this.lbl_lunghezza1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_lunghezza1.Name = "lbl_lunghezza1";
            this.lbl_lunghezza1.Size = new System.Drawing.Size(0, 17);
            this.lbl_lunghezza1.TabIndex = 4;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 197);
            this.Controls.Add(this.lbl_lunghezza1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtWord);
            this.Controls.Add(this.btn_scrivi);
            this.Controls.Add(this.lbl_scrivi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_scrivi;
        private System.Windows.Forms.Button btn_scrivi;
        private System.Windows.Forms.TextBox txtWord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_lunghezza1;
    }
}