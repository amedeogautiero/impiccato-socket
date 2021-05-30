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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void btn_scrivi_Click(object sender, EventArgs e)
        {
            ClientMessage clientMessage = new ClientMessage()
            {
                IPDest = Program.IPother,
                TipoMessaggio = TipoMessaggio.comando,
                Message = $"startgame|{textBox1.Text.Length}",
            };

            Thread thread1 = new Thread(Program.socketHelper.StartClient);
            thread1.Start(clientMessage);
        }
    }
}
