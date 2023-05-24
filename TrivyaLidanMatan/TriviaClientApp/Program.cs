using System.Text.Json.Nodes;

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
            var mainForm = new Login();
            mainForm.Show();
            Thread thread = new Thread(new ThreadStart(() =>
            {
                Thread.Sleep(1000);
                while (Application.OpenForms.Count != 0)
                {
                    Thread.Sleep(1000);
                }
                Application.Exit();
            }));
            thread.Start();
            Application.Run();
        }
    }
}