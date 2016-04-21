using System;
using System.Windows.Forms;

namespace Graph_algorithms
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form = new Main_form();
            Application.Run(form);
        }
        static Main_form form;

        public static void disableForm()
        {
            form.Enabled = false;
        }

        public static void enableForm()
        {
            form.Enabled = true;
        }
    }
}
