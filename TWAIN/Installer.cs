using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace TWAIN
{
    [RunInstaller(true)]
    public partial class Installer : System.Configuration.Install.Installer
    {
        public Installer()
        {
            InitializeComponent();
        }

        protected override void OnAfterRollback(IDictionary savedState)
        {
            RemoveFirewallException();
            RemoveEventLogSource();
            base.OnAfterRollback(savedState);
        }

        protected override void OnAfterUninstall(IDictionary savedState)
        {
            RemoveFirewallException();
            RemoveEventLogSource();
            base.OnAfterUninstall(savedState);
        }

        protected override void OnBeforeInstall(IDictionary savedState)
        {
            var result = MessageBox.Show(
                $"Would you like to add firewall exception for {Properties.Settings.Default.BaseURL}, so that non-administrative users could use this software?",
                "Firewall exception",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly
            );

            switch (result)
            {
                case DialogResult.Yes:
                    CreateFirewallException();
                    break;
                case DialogResult.No:
                    break;
                default:
                    break;
            }

            CreateEventLogSource();

            base.OnBeforeInstall(savedState);
        }

        private void CreateFirewallException()
        {
            var process = CreateProcess();
            process.StartInfo.Arguments = "http add urlacl url=\"http://+:7210/\" user=everyone";
            process.Start();
        }

        private Process CreateProcess()
        {
            Process process = new Process();

            process.StartInfo.FileName = "netsh.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.Verb = "runas";

            return process;
        }

        private void RemoveFirewallException()
        {
            var process = CreateProcess();
            process.StartInfo.Arguments = "http delete urlacl url=\"http://+:7210/\"";
            process.Start();
        }

        private void CreateEventLogSource()
        {
            if (!EventLog.SourceExists("TWAIN Scanner"))
            {
                EventLog.CreateEventSource("TWAIN Scanner", "Application");
            }
        }

        private void RemoveEventLogSource()
        {
            if (EventLog.SourceExists("TWAIN Scanner"))
            {
                EventLog.DeleteEventSource("TWAIN Scanner");
            }
        }
    }
}
