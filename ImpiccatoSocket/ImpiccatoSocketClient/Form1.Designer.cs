
namespace ImpiccatoSocketClient
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtOtherIP = new System.Windows.Forms.TextBox();
            this.lbMyEndpoint = new System.Windows.Forms.Label();
            this.btn_send = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtOtherIP
            // 
            this.txtOtherIP.Location = new System.Drawing.Point(18, 47);
            this.txtOtherIP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtOtherIP.Name = "txtOtherIP";
            this.txtOtherIP.Size = new System.Drawing.Size(136, 20);
            this.txtOtherIP.TabIndex = 0;
            // 
            // lbMyEndpoint
            // 
            this.lbMyEndpoint.AutoSize = true;
            this.lbMyEndpoint.Location = new System.Drawing.Point(15, 21);
            this.lbMyEndpoint.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbMyEndpoint.Name = "lbMyEndpoint";
            this.lbMyEndpoint.Size = new System.Drawing.Size(0, 13);
            this.lbMyEndpoint.TabIndex = 4;
            // 
            // btn_send
            // 
            this.btn_send.BackColor = System.Drawing.Color.Orange;
            this.btn_send.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_send.Location = new System.Drawing.Point(18, 85);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(75, 23);
            this.btn_send.TabIndex = 5;
            this.btn_send.Text = "Sfida!";
            this.btn_send.UseVisualStyleBackColor = false;
            this.btn_send.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(180, 143);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.lbMyEndpoint);
            this.Controls.Add(this.txtOtherIP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOtherIP;
        private System.Windows.Forms.Label lbMyEndpoint;
        private System.Windows.Forms.Button btn_send;
    }
}

