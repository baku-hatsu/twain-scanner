using NTwain;
using NTwain.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using TWAIN.Models;

namespace TWAIN
{
    public partial class TWSelectDevice : Form
    {
        public TWCapabilities Capabilities { get; private set; }
        public List<Image> Images { get; private set; } = new List<Image>();

        public TWSelectDevice()
        {
            InitializeComponent();

            var sesssion = InitTwain();

            SetupListViewItems(sesssion);
        }

        /// <summary>
        /// Method that initialize TWAIN session.
        /// </summary>
        /// <returns>TWAIN session.</returns>
        public TwainSession InitTwain()
        {
            PlatformInfo.Current.PreferNewDSM = false;
            PlatformInfo.Current.Log = new TWLogger();
            PlatformInfo.Current.Log.Info($"Using {PlatformInfo.Current.ExpectedDsmPath}.");

            var session = new TwainSession(TWIdentity.CreateFromAssembly(DataGroups.Image, Assembly.GetExecutingAssembly()));

            session.TransferError += Session_TransferError;
            session.DataTransferred += Session_DataTransferred;
            session.SourceDisabled += Session_SourceDisabled;

            if (session.State < 3)
            {
                if (session.Open() != ReturnCode.Success)
                {
                    MessageBox.Show("Unable to open TWAIN session connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    session.Close();
                }
            }

            return session;
        }

        /// <summary>
        /// Method that closes twain session connection. Used to shut down session completely.
        /// </summary>
        /// <param name="session">Twain session</param>
        private void CleanupTwain(TwainSession session)
        {
            if (session.State == 4)
            {
                session.CurrentSource.Close();
            }

            if (session.State == 3)
            {
                session.Close();
            }

            if (session.State > 2)
            {
                // normal close down didn't work, do hard kill
                session.ForceStepDown(2);
            }
        }

        /// <summary>
        /// Method that gets selected device in list view.
        /// </summary>
        /// <returns>Selected device from list view.</returns>
        private DataSource GetSelectedItem()
        {
            ListView.SelectedListViewItemCollection selected = selection_listView.SelectedItems;

            if (selected.Count > 0)
            {
                return selected[0].Tag as DataSource;
            }

            return null;
        }

        private void Ok_button_Click(object sender, EventArgs e)
        {
            Enabled = false;

            var dataSource = GetSelectedItem();

            var rc = dataSource?.Open();

            PlatformInfo.Current.Log.Info($"Open datasource return code: {rc}");

            if (rc == ReturnCode.Success)
            {
                SetupCapabilities(dataSource, Capabilities);

                if (dataSource.Capabilities.CapFeederLoaded.IsSupported && dataSource.Capabilities.CapFeederLoaded.GetCurrent() == BoolType.True)
                {
                    dataSource.Enable(SourceEnableMode.NoUI, true, IntPtr.Zero);
                }
                else
                {
                    dataSource.Close();
                    MessageBox.Show("There are no pages in Auto-Feeder. Please insert pages and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Enabled = true;
                }
            }
            else
            {
                var deviceName = dataSource == null ? "unselected" : $"{dataSource.Name}";

                MessageBox.Show($"Unable to connect to {deviceName} device.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Enabled = true;

                DialogResult = DialogResult.Abort;
            }
        }

        private void Properties_button_Click(object sender, EventArgs e)
        {
            var dataSource = GetSelectedItem();

            if (dataSource?.Open() == ReturnCode.Success)
            {
                TWProperties tWProperties = new TWProperties(dataSource, Capabilities);

                var result = tWProperties.ShowDialog();

                if (result == DialogResult.OK)
                {
                    Capabilities = tWProperties.Capabilities;
                }
            }
            else
            {
                MessageBox.Show("Unable to connect to selected device to see properties.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Selection_listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = GetSelectedItem();

            Capabilities = null;

            properties_button.Enabled = ok_button.Enabled = selectedItem != null;

            name_data_label.Text = selectedItem?.Name ?? "";
            manufacturer_data_label.Text = selectedItem?.Manufacturer ?? "";
            description_data_label.Text = selectedItem?.ProductFamily ?? "";

        }

        /// <summary>
        /// NTwain library data transferred handler. Image processing is being handled here.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Session_DataTransferred(object sender, DataTransferredEventArgs e)
        {
            Image img = null;

            if (e.NativeData != IntPtr.Zero)
            {
                var stream = e.GetNativeImageStream();

                if (stream != null)
                {
                    img = Image.FromStream(stream);
                }
            }
            else if (!string.IsNullOrEmpty(e.FileDataPath))
            {
                img = new Bitmap(e.FileDataPath);
            }

            if (img != null)
            {
                Images.Add(img);
            }
        }

        /// <summary>
        /// NTwain library source disabled handler. Source close is being handled here.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Session_SourceDisabled(object sender, EventArgs e)
        {
            var session = sender as TwainSession;

            CleanupTwain(session);

            Invoke((MethodInvoker)delegate
            {
                DialogResult = DialogResult.OK;

                if (IsHandleCreated)
                {
                    Close();
                }
            });
        }

        /// <summary>
        /// NTwain library transfer error handler. Errors are being handlered here.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Session_TransferError(object sender, TransferErrorEventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }

        /// <summary>
        /// Method that sets up currently supported properties.
        /// </summary>
        /// <param name="capabilities">Properties that is going to be set.</param>
        private void SetupCapabilities(DataSource dataSource, TWCapabilities capabilities)
        {
            var src = dataSource;

            if (capabilities != null)
            {
                if (src.Capabilities.ICapXResolution.IsSupported && src.Capabilities.ICapYResolution.IsSupported)
                {
                    src.Capabilities.ICapXResolution.SetValue(capabilities.DPIX);
                    src.Capabilities.ICapYResolution.SetValue(capabilities.DPIY);
                }

                if (src.Capabilities.ICapSupportedSizes.IsSupported)
                {
                    src.Capabilities.ICapSupportedSizes.SetValue(capabilities.PageSize);
                }

                if (src.Capabilities.CapFeederEnabled.IsSupported)
                {
                    src.Capabilities.CapFeederEnabled.SetValue(capabilities.UseAutoFeed ? BoolType.True : BoolType.False);
                }

                if (src.Capabilities.CapDuplexEnabled.IsSupported)
                {
                    src.Capabilities.CapDuplexEnabled.SetValue(capabilities.UseDuplex ? BoolType.True : BoolType.False);
                }
            }
        }

        /// <summary>
        /// Method that populates list view items.
        /// </summary>
        /// <param name="selectableDevices">Items that are going to be populated with.</param>
        private void SetupListViewItems(TwainSession dataSources)
        {
            foreach (var dataSource in dataSources)
            {
                selection_listView.Items.Add(new ListViewItem(dataSource.Name, 0)
                {
                    Tag = dataSource
                });
            }
        }
    }
}
