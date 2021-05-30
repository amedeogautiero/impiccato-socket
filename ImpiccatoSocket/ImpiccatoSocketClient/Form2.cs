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
        List<Bitmap> bitmaps = new List<Bitmap>();
        int tentativi = 0;
        int tentativiFalliti = 0;
        int tentativiOK = 0;
        int wordLength = 0;
        string lastChar = string.Empty;


        public Form2()
        {
            InitializeComponent();

            bitmaps.Add(global::ImpiccatoSocketClient.Properties.Resources.hangman0);
            bitmaps.Add(global::ImpiccatoSocketClient.Properties.Resources.hangman1);
            bitmaps.Add(global::ImpiccatoSocketClient.Properties.Resources.hangman2);
            bitmaps.Add(global::ImpiccatoSocketClient.Properties.Resources.hangman3);
            bitmaps.Add(global::ImpiccatoSocketClient.Properties.Resources.hangman4);
            bitmaps.Add(global::ImpiccatoSocketClient.Properties.Resources.hangman5);
            bitmaps.Add(global::ImpiccatoSocketClient.Properties.Resources.hangman6);

            Program.socketHelper.OnStartGame += delegate (int _wordLength)
            {
                this.wordLength = _wordLength;
                this.BeginInvoke((Action)(() =>
                {
                    grpLettere.Enabled = true;
                    draw_place_letter(_wordLength);
                }));
            };

            Program.socketHelper.OnTryCharFail += delegate ()
            {
                tentativiFalliti++;

                this.BeginInvoke((Action)(() =>
                {

                    Bitmap bitmap = bitmaps[tentativiFalliti];
                    this.pictureBox1.Image = bitmap;

                    if (tentativiFalliti == 6)
                    {
                        MessageBox.Show("Hai perso");
                        grpLettere.Enabled = false;
                    }
                }));
            };

            Program.socketHelper.OnTryCharSuccess += delegate (List<int> indexes)
            {
                tentativiOK++;

                this.BeginInvoke((Action)(() =>
                {
                    foreach (int index in indexes)
                    {
                        (panel2.Controls[index] as Label).Text = lastChar;
                        (panel2.Controls[index] as Label).Tag = "s";
                    }

                    int charsOK = panel2.Controls.Cast<Control>().Select(c => c is Label && (c as Label).Tag != null &&(c as Label).Tag.ToString() == "s").Count();
                    if (charsOK == this.wordLength)
                    {
                        MessageBox.Show("Hai vinto");
                        grpLettere.Enabled = false;
                    }
                }));
            };
        }

        private void button19_Click(object sender, EventArgs e)
        {

        }

        private void draw_place_letter(int wordLength)
        {
            this.panel2.Controls.Clear();
            for (int x = 0; x < wordLength; x++)
            {
                int location = 24 + (x * 18 + 5);
                var lblChar = new System.Windows.Forms.Label();
                lblChar.AutoSize = true;
                lblChar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                lblChar.Location = new System.Drawing.Point(location, 19);
                lblChar.Name = $"lblChar{x}";
                lblChar.Size = new System.Drawing.Size(18, 19);
                lblChar.Text = "_";
                this.panel2.Controls.Add(lblChar);
            }
        }

        
        private void char_Click(object sender, EventArgs e)
        {
            lastChar = (sender as Button).Text.ToUpper();
            ClientMessage clientMessage = new ClientMessage()
            {
                IPDest = Program.IPother,
                TipoMessaggio = TipoMessaggio.trychar,
                Message = lastChar,
            };
            (sender as Button).Enabled = false;

            Thread thread1 = new Thread(Program.socketHelper.StartClient);
            thread1.Start(clientMessage);

            tentativi++;
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
