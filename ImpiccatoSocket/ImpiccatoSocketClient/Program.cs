using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImpiccatoSocketClient
{
    static class Program
    {
        public static Form1 form1 = null;
        public static Form2 form2 = null;
        public static Form3 form3 = null;
        public static SocketHelper socketHelper = null;
        public static string IPother = string.Empty;
        public static string IPremote = string.Empty;
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            socketHelper = new SocketHelper();

            Program.form1 = new Form1();

            Program.form2 = new Form2();
            Program.form2.Hide();

            Program.form3 = new Form3();
            Program.form3.Hide();

            Application.Run(Program.form1);
        }
    }
}
