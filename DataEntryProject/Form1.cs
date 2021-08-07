using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataEntryProject
{
    public partial class frmDataEntry : Form
    {

        TimeSpan elapsedTime;
        DateTime lastElapsed;


        public frmDataEntry()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtAdress.Clear();
            txtCity.Clear();
            txtState.Clear();
            txtZip.Clear();
            txtName.Focus();
        }

        private void timTimer_Tick(object sender, EventArgs e)
        {
            elapsedTime += DateTime.Now  - lastElapsed;
            lastElapsed = DateTime.Now;

            txtTimer.Text = Convert.ToString(
                new TimeSpan(elapsedTime.Hours, elapsedTime.Minutes, elapsedTime.Seconds));
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnPause.Enabled = true;
            timTimer.Enabled = true;
            grbDataEntry.Enabled = true;
            txtName.Focus();
            lastElapsed = DateTime.Now;
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            btnPause.Enabled = false;
            grbDataEntry.Enabled = false;
            timTimer.Enabled = false;
        }
    }
}
