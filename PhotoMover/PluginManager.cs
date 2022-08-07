using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoMover
{
    public partial class PluginManager : Form
    {
        private Dictionary<Object, DateExtractorProxy> extractersDict = new Dictionary<Object, DateExtractorProxy>();
        public PluginManager()
        {
            InitializeComponent();
        }

        private void extList_SelectedIndexChanged(object sender, EventArgs e)
        {
            extractersDict.Clear();
            var ext = extList.SelectedItem.ToString();
            var handlers = Program.AppConfig.Extractors[ext];
            if(handlers != null)
            {
                handlerList.Items.Clear();
                foreach(var handler in handlers)
                {
                    if(handler.Instance != null)
                    {
                        int i = handlerList.Items.Add(handler.Name);
                        extractersDict[i] = handler;
                        handlerList.SetItemChecked(i, handler.IsEnabled);
                    }
                }
            }
        }

        private void PluginManager_Load(object sender, EventArgs e)
        {
            var exts = Program.AppConfig.Extractors.Keys;
            foreach(var ext in exts)
            {
                extList.Items.Add(ext);
            }
            extList.SelectedIndex = 0;
        }

        private void handlerList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var i = e.Index;
            extractersDict[i].IsEnabled = e.NewValue.Equals(CheckState.Checked);
        }
    }
}
