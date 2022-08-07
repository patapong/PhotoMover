using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoMover
{
    public partial class JobDetailsForm : Form
    {
        private JobUnit jobUnit;
        public JobDetailsForm()
        {
            InitializeComponent();
        }
        public JobDetailsForm(JobUnit unit)
        {
            this.jobUnit = unit;
            InitializeComponent();
        }
        private void bgGoSrc_Click(object sender, EventArgs e)
        {
            jobUnit.GoSrc();
        }

        private void btGoCalculatedDest_Click(object sender, EventArgs e)
        {
            jobUnit.GoDest();
        }

        private void btGoRealDest_Click(object sender, EventArgs e)
        {
            jobUnit.GoDest();
        }

        private void JobDetails_Load(object sender, EventArgs e)
        {
            if(this.jobUnit != null)
            {
                txtSrc.Text = jobUnit.SourcePath;
                txtCalculatedDest.Text = jobUnit.CalculatedTargetPath;
                txtRealDest.Text = jobUnit.RealTargetPath;
                txtStatus.Text = jobUnit.Status.ToString();
                txtLogs.Text = jobUnit.StatusLog;

            }
        }
    }
}
