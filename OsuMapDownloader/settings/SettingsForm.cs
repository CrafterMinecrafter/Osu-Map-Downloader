using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OsuMapDownloader.settings
{
    public partial class SettingsForm : Form
    {
        private static KeyboardHandler keyboardHandler;

        public SettingsForm()
        {
            InitializeComponent();
            keyboardHandler = new KeyboardHandler();
        }

        private void AutoImportCheckBox_CheckedChanged(object sender, EventArgs e)
        {
             Settings.data.AutoImport = (sender as CheckBox).Checked;
             Settings.Save();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            AutoImport.Checked = Settings.data.AutoImport;
        }
    }
}
