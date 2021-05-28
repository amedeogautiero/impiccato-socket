using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImpiccatoSocketClient
{
    public partial class Form1 : Form
    {
        SocketHelper socketHelper = null;
        public Form1()
        {
            InitializeComponent();

            socketHelper = new SocketHelper();
            socketHelper.ListeningCompleted += delegate (string endpoint)
            {
                this.BeginInvoke((Action)(() =>
                {
                    lbMyEndpoint.Text = $"Me: {endpoint}";
                }));
            };

            socketHelper.OnChiediSfida += delegate(string endpoint)
            {
                
                var res = MessageBox.Show("Sfida ??", "", MessageBoxButtons.YesNo);

                if (res == DialogResult.Yes)
                {
                    this.BeginInvoke((Action)(() =>
                    {
                        this.Hide();
                        Program.form2.Show();
                    }));

                    return true;
                }

                return false;
            };


            socketHelper.OnSfidaOk += delegate (string endpoint)
            { 
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread thread1 = new Thread(socketHelper.StartListening);
            thread1.Start();
           
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            ClientMessage clientMessage = new ClientMessage()
            {
                IPDest = txtOtherIP.Text,
                TipoMessaggio = TipoMessaggio.comando,
                Message = "sfida",
            };

            Thread thread1 = new Thread(socketHelper.StartClient);
            thread1.Start(clientMessage);

            //Helper.StartClient(txtOtherIP.Text, txtMessage.Text);
        }
    }
}
