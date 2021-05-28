using System;
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
                Message = txtMessage.Text,
            };

            Thread thread1 = new Thread(socketHelper.StartClient);
            thread1.Start(clientMessage);

            //Helper.StartClient(txtOtherIP.Text, txtMessage.Text);
        }
    }
}
