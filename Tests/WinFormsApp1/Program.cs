using LH;
using Log = LH.LoggingHelper;


namespace WinFormsApp1
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
            Application.Run(new FormTest());

            //Log.Check();
            //Log.Write("Teste!", 2, null);
            //Log.Write("Teste de log com enum e obs.", Log.Level.INFO, "Teste");

        }
    }
}