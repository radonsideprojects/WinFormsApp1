namespace WinFormsApp1
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Не дозволяє програмі запуститися два раза

            Mutex mutex = new Mutex(false, "TheFunnyAppLol");
            if (mutex.WaitOne(0, false))
            {
                ApplicationConfiguration.Initialize();
                Application.Run(new Forms.GreetingWindow());
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}