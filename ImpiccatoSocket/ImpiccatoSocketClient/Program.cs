using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImpiccatoSocketClient
{
    static class Program
    {
        public static Form2 form2 = null;
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Program.form2 = new Form2();
            Program.form2.Hide();
            Application.Run(new Form1());
        }
    }
}
