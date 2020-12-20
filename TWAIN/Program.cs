using System;
using System.Diagnostics;
using System.Web.Http.SelfHost;
using System.Windows.Forms;

namespace TWAIN
{
    static class Program
    {
        public static TWApplicationContext Context { get; private set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (HttpSelfHostServer server = new HttpSelfHostServer(Startup.ConfigureHttpSelfHost()))
            {
                try
                {
                    server.OpenAsync().Wait();
                }
                catch (Exception ex)
                {
                    using (EventLog eventLog = new EventLog("Application"))
                    {
                        eventLog.Source = "Application";
                        eventLog.WriteEntry($"You do not have permission to open HTTP listiner on {Properties.Settings.Default.BaseURL}: {ex.Message} {ex.InnerException.Message}", EventLogEntryType.Error);
                    }

                    MessageBox.Show($"You do not have permission to open HTTP listiner on {Properties.Settings.Default.BaseURL}.");
                }


                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Context = new TWApplicationContext();

                Application.Run(Context);
            }
        }
    }
}
