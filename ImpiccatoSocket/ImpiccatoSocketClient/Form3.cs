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

            Program.socketHelper.OnTryChar += delegate (string @char)
            {
                this.BeginInvoke((Action)(() =>
                {
                    //var ret = txtWord.Text.ToUpper().Contains(@char);
                    //MessageBox.Show(ret.ToString());
                    check_char(@char);
                }));
            };
        }

        private void check_char(string @char)
        {
            List<int> indexes = new List<int>();

            Func<int> lastIndex = delegate ()
            {
                if (indexes.Count == 0)
                    return -1;
                else
                    return indexes.Last();
            };

            int index = 0;

            do
            {
                index = txtWord.Text.ToUpper().IndexOf(@char, lastIndex() + 1);
                if (index >= 0)
                {
                    indexes.Add(index);
                }
            } while (index >= 0);

            ClientMessage clientMessage = new ClientMessage()
            {
                IPDest = Program.IPother,
                TipoMessaggio = TipoMessaggio.checkchar,
                Message = string.Join("|", indexes.Select(i => i.ToString())),
            };

            Thread thread1 = new Thread(Program.socketHelper.StartClient);
            thread1.Start(clientMessage);
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
                Message = $"startgame|{txtWord.Text.Length}",
            };

            Thread thread1 = new Thread(Program.socketHelper.StartClient);
            thread1.Start(clientMessage);
        }
    }
}
