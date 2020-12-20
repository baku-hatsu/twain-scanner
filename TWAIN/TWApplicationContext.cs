using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace TWAIN
{
    public class TWApplicationContext : ApplicationContext
    {
        private readonly NotifyIcon NotifyIcon;
        public TWSelectDevice _TWSelectDevice;

        public TWApplicationContext()
        {
            NotifyIcon = new NotifyIcon
            {
                Icon = Properties.Resources.Printer_128x,
                ContextMenuStrip = ContextMenuStrip_Initialize(),
                Visible = true
            };

            NotifyIcon.DoubleClick += NotifyIcon_DoubleClick;
        }

        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
        }

        private ContextMenuStrip ContextMenuStrip_Initialize()
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();

            contextMenuStrip.Items.Add("Open localhost", Properties.Resources.OpenWeb_16x, ContextMenuStrip_OpenLocalHost);
            contextMenuStrip.Items.Add("Exit", Properties.Resources.Exit_16x, ContextMenuStrip_Exit);

            return contextMenuStrip;
        }

        private void ContextMenuStrip_Exit(object sender, EventArgs e)
        {
            NotifyIcon.Visible = false;
            Application.Exit();
        }

        private void ContextMenuStrip_OpenLocalHost(object sender, EventArgs e)
        {
            var startupInfo = new ProcessStartInfo("cmd", $"/c start {Properties.Settings.Default.BaseURL}scans/get")
            {
                CreateNoWindow = true
            };

            Process.Start(startupInfo);
        }
    }
}
