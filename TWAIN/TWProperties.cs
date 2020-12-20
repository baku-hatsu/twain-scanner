using NTwain;
using NTwain.Data;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TWAIN.Models;

namespace TWAIN
{
    public partial class TWProperties : Form
    {
        private readonly DataSource _dataSource;
        private readonly TWCapabilities _twainCapabilities;
        public TWCapabilities Capabilities { get; private set; } = new TWCapabilities();

        public TWProperties(DataSource dataSource, TWCapabilities twainCapabilities = null)
        {
            InitializeComponent();

            _dataSource = dataSource;
            _twainCapabilities = twainCapabilities;

            LoadSourceCapabilities();
        }

        public void LoadSourceCapabilities()
        {
            var src = _dataSource;

            if (dpi_groupBox.Enabled = src.Capabilities.ICapXResolution.IsSupported && src.Capabilities.ICapYResolution.IsSupported)
            {
                LoadDPI(src.Capabilities.ICapXResolution);
            }

            if (page_groupBox.Enabled = src.Capabilities.ICapSupportedSizes.IsSupported)
            {
                LoadPaperSize(src.Capabilities.ICapSupportedSizes);
            }

            if (autofeeder_checkBox.Enabled = src.Capabilities.CapFeederEnabled.IsSupported)
            {
                LoadFeeder(src.Capabilities.CapFeederEnabled);
            }

            if (duplex_checkBox.Enabled = src.Capabilities.CapDuplexEnabled.IsSupported)
            {
                LoadDuplex(src.Capabilities.CapDuplexEnabled);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_dataSource.IsOpen)
            {
                _dataSource.Close();
            }

            base.OnFormClosing(e);
        }

        private void Autofeeder_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            Capabilities.UseAutoFeed = autofeeder_checkBox.Checked;
        }

        private void Dpi_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Capabilities.DPIX = Capabilities.DPIY = (TWFix32)dpi_comboBox.SelectedItem;
        }

        private void Duplex_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            Capabilities.UseDuplex = duplex_checkBox.Checked;
        }

        private void LoadDPI(ICapWrapper<TWFix32> cap)
        {
            var list = cap.GetValues().Where(dpi => (dpi % 50) == 0).ToList();
            dpi_comboBox.DataSource = list;
            var cur = _twainCapabilities != null ? _twainCapabilities.DPIX : cap.GetCurrent();

            if (list.Contains(cur))
            {
                dpi_comboBox.SelectedItem = Capabilities.DPIX = Capabilities.DPIY = cur;
            }
        }

        private void LoadDuplex(ICapWrapper<BoolType> cap)
        {
            if (_twainCapabilities != null)
            {
                duplex_checkBox.Checked = Capabilities.UseDuplex = _twainCapabilities.UseDuplex;
            }
            else
            {
                duplex_checkBox.Checked = Capabilities.UseDuplex = cap.GetCurrent() == BoolType.True;
            }
        }

        private void LoadFeeder(ICapWrapper<BoolType> cap)
        {
            if (_twainCapabilities != null)
            {
                autofeeder_checkBox.Checked = Capabilities.UseAutoFeed = _twainCapabilities.UseAutoFeed;
            }
            else
            {
                autofeeder_checkBox.Checked = cap.GetCurrent() == BoolType.True;
                Capabilities.UseAutoFeed = cap.GetCurrent() == BoolType.True;
            }
        }

        private void LoadPaperSize(ICapWrapper<SupportedSize> cap)
        {
            var list = cap.GetValues().ToList();
            page_size_comboBox.DataSource = list;
            var cur = _twainCapabilities != null ? _twainCapabilities.PageSize : cap.GetCurrent();

            if (list.Contains(cur))
            {
                page_size_comboBox.SelectedItem = Capabilities.PageSize = cur;
            }
        }

        private void Ok_button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Page_size_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Capabilities.PageSize = (SupportedSize)page_size_comboBox.SelectedItem;
        }
    }
}
