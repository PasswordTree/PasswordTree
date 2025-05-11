using PasswordTree.Password_Generator;
using System;
using System.Threading;
using System.Windows.Forms;

namespace PasswordTree
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (Mutex mutex = new Mutex(true, "PasswordTree", out bool firstInstance))
            {
                if (firstInstance)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new PasswordGeneratorForm());
                }
                else
                {
                    MessageBox.Show(
                        "Another instance is already running!",
                        "Application is running...",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Stop);
                }
            }
        }
    }
}
