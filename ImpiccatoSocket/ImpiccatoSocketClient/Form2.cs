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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            Program.socketHelper.OnStartGame += delegate (string endpoint)
            {
                this.BeginInvoke((Action)(() =>
                {
                    grpLettere.Enabled = true;
                }));
            };
        }

        private void button19_Click(object sender, EventArgs e)
        {

        }

        private void char_Click(object sender, EventArgs e)
        {
            ClientMessage clientMessage = new ClientMessage()
            {
                IPDest = Program.IPother,
                TipoMessaggio = TipoMessaggio.trychar,
                Message = (sender as Button).Text,
            };

            Thread thread1 = new Thread(Program.socketHelper.StartClient);
            thread1.Start(clientMessage);
        }

        /*
        #region Draw Hangman
        void DrawHangman()
        {
            Graphics g = panel1.CreateGraphics();
            Pen p = new Pen(Color.Black, 10);
            g.DrawLine(p, new Point(130, 220), new Point(150, 5));
            g.DrawLine(p, new Point(135, 5), new Point(150, 5));
            g.DrawLine(p, new Point(60, 0), new Point(150, 5));

        }
        #endregion
        */
    }
}
