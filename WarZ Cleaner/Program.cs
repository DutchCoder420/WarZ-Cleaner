namespace WarZ_Cleaner
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            bool nogui = args.Contains("noGui");

            ApplicationConfiguration.Initialize();
            MainForm mainForm = new MainForm(nogui);
            if (nogui)
            {
                mainForm.WindowState = FormWindowState.Minimized;
            }
            Application.Run(mainForm);
        }
    }
}