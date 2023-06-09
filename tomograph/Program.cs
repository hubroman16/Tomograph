using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tomograph
{
    static class Program
    {
        public static veer veershem;
        public static parallel parallelshem;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            veershem = new veer();
            parallelshem = new parallel();
            parallelshem.Show();
            Application.Run(veershem);
        }
    }
}
