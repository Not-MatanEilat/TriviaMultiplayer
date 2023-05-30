using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace TriviaClientApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            MainForm mainForm = new MainForm();

            mainForm.Show();
            Thread thread = new Thread(() =>
            {
                Thread.Sleep(1000);
                while (Application.OpenForms.Count != 0)
                {
                    Thread.Sleep(1000);
                }
                Application.Exit();
            });
            thread.Start();
            Application.Run();
        }
    }
}